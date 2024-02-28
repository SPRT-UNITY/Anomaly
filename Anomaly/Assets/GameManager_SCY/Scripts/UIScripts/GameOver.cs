using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : UIBase
{
    [SerializeField] private TextMeshProUGUI ClearMent;
    [SerializeField] private TextMeshProUGUI ResolvedText;
    [SerializeField] private TextMeshProUGUI ResolvedNumberText;
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button ReportButton;
    [SerializeField] private Button QuitButton;

    [SerializeField] GameObject ReportPop;
    [SerializeField] private TextMeshProUGUI Anomalies;

    private string endComment = "무엇인가 잘못되었다.";

    private void Start()
    {
        GameManager.Instance.OnGameover += Show;

        ClearMent.gameObject.SetActive(false);
        ResolvedText.gameObject.SetActive(false);
        ResolvedNumberText.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        ReportButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);

        ReportPop.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        base.Show();
        UIManager.Instance.GetCanvas("MainCanvas").gameObject.SetActive(false);
        StartCoroutine("GameOverPop");
    }

    public void OnRestartButton()
    {
        
    }

    public void OnReportButton()
    {
        ReportPop.SetActive(true);

        Anomalies.text = "";
        string type = "";
        string location = "";

        foreach (AnormalyBase anomaly in AnormalyController.Instance.anomalyList.FindAll(x => x.IsAppear))
        {
            switch (anomaly.A_Type)
            {
                case Anomaly_Type.Object:
                    type = "물체 이상";
                    break;
                case Anomaly_Type.Camera:
                    type = "카메라 오작동";
                    break;
                case Anomaly_Type.Light:
                    type = "전등 고장";
                    break;
                case Anomaly_Type.Mist:
                    type = "안개 발생";
                    break;
                case Anomaly_Type.Intruder:
                    type = "침입자";
                    break;
                case Anomaly_Type.Abyss:
                    type = "알 수 없는 그림자";
                    break;
            }

            switch (anomaly.A_Location)
            {
                case Anomaly_Location.Living_Room:
                    location = "거실";
                    break;
                case Anomaly_Location.Library:
                    location = "서재";
                    break;
                case Anomaly_Location.Bed_Room:
                    location = "침실";
                    break;
                case Anomaly_Location.Bath_Room:
                    location = "욕실";
                    break;
                case Anomaly_Location.Hallway:
                    location = "복도";
                    break;
                case Anomaly_Location.Kichen:
                    location = "부엌";
                    break;
            }

            Anomalies.text += type + "       " + location + "\n";
        }
    }

    public void OnQuitButton()
    {

    }

    public void OnBackButton()
    {
        ReportPop.gameObject.SetActive(false);
    }

    private IEnumerator GameOverPop()
    {
        ClearMent.gameObject.SetActive(true);
        ClearMent.text = "";

        for (int i = 0; i < endComment.Length; i++)
        {
            ClearMent.text += endComment[i];
            yield return new WaitForSeconds(0.15f);
        }

        WaitForSeconds waitSecond = new WaitForSeconds(0.7f);

        yield return waitSecond;
        ResolvedText.gameObject.SetActive(true);

        yield return waitSecond;
        ResolvedNumberText.gameObject.SetActive(true);
        ResolvedNumberText.text = GameManager.Instance.resolvedAnomaly + " 개";

        yield return waitSecond;
        RestartButton.gameObject.SetActive(true);
        ReportButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);
    }
}
