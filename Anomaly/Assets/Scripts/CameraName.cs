using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraName : MonoBehaviour
{
    public Anomaly_Location location;

    public string GetCameraName()
    {
        string name = "";

        switch (location)
        {
            case Anomaly_Location.Living_Room:
                name = "�Ž�";
                break;
            case Anomaly_Location.Library:
                name = "����";
                break;
            case Anomaly_Location.Bed_Room:
                name = "ħ��";
                break;
            case Anomaly_Location.Bath_Room:
                name = "���";
                break;
            case Anomaly_Location.Hallway:
                name = "����";
                break;
            case Anomaly_Location.Kichen:
                name = "�ξ�";
                break;
        }

        return name;
    }
}
