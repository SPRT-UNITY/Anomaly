using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestCard : UIBase
{
    [SerializeField] private TextMeshProUGUI text;

    private string[] texts = new string[]
    {
        "���� ����\r\n�ῡ�� ���� ����\r\n���� ������ �� �ž�",
        "���տ� ���� �ֵ� ����\r\n�ƹ��͵� ������",
        "������ �ʸ� �����ϰ� �־�\r\n�� ��ġ���� �ž�",
        "���忡 ������ ���",
        "�ɿ��� �� �鿩�� ���� �־�\r\n�ʵ� �ѹ� ����"
    };

    private void Start()
    {
        GameManager.Instance.OnAnomalyResolve += Show;

        text.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        base.Show();

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

        UIManager.Instance.GetCanvas("MainCanvas").gameObject.SetActive(true);
        UIManager.Instance.GetUI("AfterChecking").Show();
        UIManager.Instance.GetUI("Warning").CloseUI();
    }
}
