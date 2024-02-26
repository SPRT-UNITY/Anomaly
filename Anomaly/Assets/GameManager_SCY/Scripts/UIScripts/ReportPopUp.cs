using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportPopUp : UIBase
{
    [SerializeField] private GameObject selectType;
    [SerializeField] private GameObject selectLocation;

    private void Start()
    {
    }

    public void OnClickAType(int type)
    {
        GameManager.instance.nowSelectedType = (Anormaly_Type)type;
        selectLocation.SetActive(true);
        selectType.SetActive(false);
    }

    public void OnClickLocation(int location)
    {
        GameManager.instance.nowSelectedLocation = (Anormaly_Location)location;
        GameManager.instance.CheckEnvironmentAnormaly();
        CloseUI();
    }

    public void OnClickBackButton()
    {
        selectLocation.SetActive(false);
        selectType.SetActive(true);
    }
}
