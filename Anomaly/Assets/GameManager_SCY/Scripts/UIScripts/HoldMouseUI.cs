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

        GameManager.Instance.OnClicking += UpdateClicking;
        GameManager.Instance.CloseUI += CloseUI;
        GameManager.Instance.OnCheckingAnormaly += ActiveAnimation;

        gameObject.SetActive(false);
    }

    private void UpdateClicking(float clicking)
    {
        gameObject.SetActive(true);

        transform.position = GameManager.Instance.newMousePosition;
        transform.GetComponentInChildren<Image>().fillAmount = clicking / 2f;
    }

    private void ActiveAnimation()
    {
        uiAnim.SetBool("Checking", true);
    }
}
