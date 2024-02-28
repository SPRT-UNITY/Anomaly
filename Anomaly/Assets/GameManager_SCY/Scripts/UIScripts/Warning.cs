using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Warning : UIBase
{
    [SerializeField] private TextMeshProUGUI alertText;
    private string text;

    private void Start()
    {
        UIManager.Instance.UIList.Add(this);

        GameManager.Instance.AnomalyWarning += Show;

        gameObject.SetActive(false);
    }

    public override void Show()
    {
        text = "뭔가 불안한 느낌이 든다. 이상한 점이 한두가지가 아니다...";

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

        yield return new WaitForSeconds(1f);

        CloseUI();
    }
}
