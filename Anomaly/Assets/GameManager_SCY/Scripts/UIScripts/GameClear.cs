using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameClear : UIBase
{
    [SerializeField] private TextMeshProUGUI ClearMent;
    [SerializeField] private TextMeshProUGUI ResolvedText;
    [SerializeField] private TextMeshProUGUI ResolvedNumberText;
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button QuitButton;

    private string endComment = "문제를 모두 해결했다.\r\n오늘은 안심하고 잘 수 있을 것 같다.";

    private void Start()
    {
        GameManager.Instance.OnGameClear += Show;

        ClearMent.gameObject.SetActive(false);
        ResolvedText.gameObject.SetActive(false);
        ResolvedNumberText.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }

    public override void Show()
    {
        base.Show();
        UIManager.Instance.GetCanvas("MainCanvas").gameObject.SetActive(false);
        StartCoroutine("GameClearPop");
    }

    public void OnRestartButton()
    {

    }

    public void OnQuitButton()
    {

    }

    private IEnumerator GameClearPop()
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
        QuitButton.gameObject.SetActive(true);
    }
}
