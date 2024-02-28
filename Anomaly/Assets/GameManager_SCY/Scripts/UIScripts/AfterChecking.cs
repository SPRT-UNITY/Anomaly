using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AfterChecking : UIBase
{
    [SerializeField] private TextMeshProUGUI alertText;
    private string text;

    private void Start()
    {
        UIManager.Instance.UIList.Add(this);

        GameManager.Instance.OnNoAnomaly += ShowNoAnomaly;

        gameObject.SetActive(false);
    }

    private void ShowNoAnomaly()
    {
        text = "아무 이상이 없는 것 같다...";

        gameObject.SetActive(true);
        StartCoroutine("ShowText");
    }

    public override void Show()
    {
        text = "문제가 해결되었다.   ";

        gameObject.SetActive(true);
        StartCoroutine("ShowText");
    }

    private IEnumerator ShowText()
    {
        alertText.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            alertText.text += text[i];
            yield return new WaitForSeconds(0.15f);
        }

        yield return new WaitForSeconds(0.5f);

        CloseUI();
    }
}
