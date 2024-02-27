using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldMouseUI : UIBase
{
    private int nowCamera;

    private Animator uiAnim;

    [SerializeField] private Image circle;
    [SerializeField] private Image checking;
    [SerializeField] private Image cantInterext;

    private void Start()
    {
        uiAnim = circle.GetComponent<Animator>();

        GameManager.Instance.OnClicking += UpdateClicking;
        GameManager.Instance.CloseUI += CloseUI;

        gameObject.SetActive(false);
    }

    private void UpdateClicking(float clicking)
    {
        gameObject.SetActive(true);
        circle.gameObject.SetActive(true);

        transform.position = GameManager.Instance.newMousePosition;
        circle.fillAmount = clicking / 2f;

        GameManager.Instance.OnCheckingAnomaly += ActiveAnimation;
    }

    public override void CloseUI()
    {
        base.CloseUI();
        checking.gameObject.SetActive(false);

        GameManager.Instance.OnCheckingAnomaly -= ActiveAnimation;
        CameraManager.Instance.CameraChange -= CameraCheck;
    }

    private void ActiveAnimation()
    {
        CameraManager.Instance.CameraChange += CameraCheck;
        nowCamera = CameraManager.Instance.nowCameraNumber;

        checking.gameObject.SetActive(true);
        circle.gameObject.SetActive(false);
    }

    private void CameraCheck()
    {
        if(nowCamera == CameraManager.Instance.nowCameraNumber)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
