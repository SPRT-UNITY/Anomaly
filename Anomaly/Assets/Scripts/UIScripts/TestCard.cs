using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestCard : UIBase
{
    [SerializeField] private TextMeshProUGUI text;
    private PlaySound sound;

    private string[] texts = new string[]
    {
        "눈을 감아\r\n잠에서 깨고 나면\r\n모든게 괜찮아 질 거야",
        "눈앞에 뭐가 있든 간에\r\n아무것도 믿지마",
        "저들이 너를 감시하고 있어\r\n널 해치려는 거야",
        "옷장에 괴물이 살아",
        "심연이 널 들여다 보고 있어\r\n너도 한번 봐봐"
    };

    private void Start()
    {
        GameManager.Instance.OnAnomalyResolve += Show;

        sound = GetComponent<PlaySound>();

        text.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        base.Show();
        sound.PlaySFX();

        UIManager.Instance.GetCanvas("MainCanvas").gameObject.SetActive(false);

        ShowText();
        Invoke("CloseUI", 1.5f);
    }

    private void ShowText()
    {
        text.gameObject.SetActive(true);
        text.text = texts[Random.Range(0, texts.Length)];

        Invoke("CloseText", 0.5f);
    }

    private void CloseText()
    {
        text.gameObject.SetActive(false);
    }

    public override void CloseUI()
    {
        base.CloseUI();

        if (GameManager.Instance.NowPlaying)
        {
            UIManager.Instance.GetCanvas("MainCanvas").gameObject.SetActive(true);
            UIManager.Instance.GetUI("AfterChecking").Show();
        }
        UIManager.Instance.GetUI("Warning").CloseUI();
    }
}
