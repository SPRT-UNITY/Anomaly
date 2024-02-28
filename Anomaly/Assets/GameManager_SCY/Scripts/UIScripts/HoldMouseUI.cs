using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldMouseUI : UIBase
{
    private int nowCamera;

    [SerializeField] private Image circle;
    [SerializeField] private Image checking;
    [SerializeField] private Image cantInterect;

    private void Start()
    {
        GameManager.Instance.OnClicking += UpdateClicking;
        GameManager.Instance.CloseUI += CloseUI;

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.Instance.OnCheckingAnomaly += ActiveCheckingAnimation;
    }

    private void UpdateClicking(float clicking)
    {
        gameObject.SetActive(true);
        circle.gameObject.SetActive(true);

        transform.position = GameManager.Instance.newMousePosition;
        circle.fillAmount = clicking / 2f;
    }

    public override void CloseUI()
    {
        base.CloseUI();
        checking.gameObject.SetActive(false);

        GameManager.Instance.OnCheckingAnomaly -= ActiveCheckingAnimation;
        CameraManager.Instance.CameraChange -= CameraCheck;
    }

    private void ActiveCheckingAnimation()
    {
        CameraManager.Instance.CameraChange += CameraCheck;
        nowCamera = CameraManager.Instance.nowCameraNumber;

        checking.gameObject.SetActive(true);
        circle.gameObject.SetActive(false);
    }

    private void ActiveCantInterectAnimation()
    {
        cantInterect.gameObject.SetActive(true);
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
