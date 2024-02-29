using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCard : UIBase
{
    private void Start()
    {
        GameManager.Instance.OnAnomalyResolve += Show;

        gameObject.SetActive(false);
    }

    public override void Show()
    {
        base.Show();

        UIManager.Instance.GetCanvas("MainCanvas").gameObject.SetActive(false);

        Invoke("CloseUI", 1.5f);
    }

    public override void CloseUI()
    {
        base.CloseUI();

        UIManager.Instance.GetCanvas("MainCanvas").gameObject.SetActive(true);
        UIManager.Instance.GetUI("AfterChecking").Show();
        UIManager.Instance.GetUI("Warning").CloseUI();
    }
}
