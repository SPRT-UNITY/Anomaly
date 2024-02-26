using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportPopUp : UIBase
{
    [SerializeField] private GameObject selectType;
    [SerializeField] private GameObject selectLocation;

    private void Start()
    {
        GameManager.Instance.OnRightMouseClick += UpdatePosition;
        GameManager.Instance.OnLeftMouseClick += CloseUI;

        gameObject.SetActive(false);
    }

    public void UpdatePosition(Vector3 position)
    {
        gameObject.SetActive(true);
        transform.position = position;
    }

    public void OnClickAType(int type)
    {
        GameManager.Instance.nowSelectedType = (Anormaly_Type)type;
        selectLocation.SetActive(true);
        selectType.SetActive(false);
    }

    public void OnClickLocation(int location)
    {
        GameManager.Instance.nowSelectedLocation = (Anormaly_Location)location;
        GameManager.Instance.CheckEnvironmentAnormaly();
        selectLocation.SetActive(false);
        selectType.SetActive(true);
        CloseUI();
    }

    public void OnClickBackButton()
    {
        selectLocation.SetActive(false);
        selectType.SetActive(true);
    }
}
