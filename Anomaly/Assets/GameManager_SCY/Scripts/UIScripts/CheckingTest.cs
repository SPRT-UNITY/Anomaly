using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckingTest : UIBase
{
    [SerializeField] private TextMeshProUGUI checkingText;

    private string[] text = new string[]
    {
        "Checking",
        "Checking.",
        "Checking..",
        "Checking...",
    };
    private int index;
    private float time;

    private void Start()
    {
        GameManager.Instance.CloseUI += CloseUI;
        GameManager.Instance.OnCheckingAnomaly += Show;

        gameObject.SetActive(false);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= 0.5)
        {
            UpdateText();
            time = 0;
        }
    }

    private void OnEnable()
    {
        index = 0;
        time = 0;
        UpdateText();
    }

    private void UpdateText()
    {
        checkingText.text = text[index % text.Length];
        index++;
    }
}
