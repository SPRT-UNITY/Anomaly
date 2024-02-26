using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldMouseUI : UIBase
{
    private Animator uiAnim;

    private void Start()
    {
        uiAnim = transform.GetComponentInChildren<Animator>();

        GameManager.instance.OnClicking += UpdateClicking;
        GameManager.instance.CloseUI += CloseUI;
        GameManager.instance.OnCheckingAnormaly += ActiveAnimation;
    }

    private void UpdateClicking(float clicking)
    {
        gameObject.SetActive(true);

        transform.position = GameManager.instance.newMousePosition;
        transform.GetComponentInChildren<Image>().fillAmount = clicking / 2f;
    }

    private void ActiveAnimation()
    {
        uiAnim.SetBool("Checking", true);
    }
}
