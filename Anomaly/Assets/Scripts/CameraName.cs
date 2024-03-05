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
                name = "거실";
                break;
            case Anomaly_Location.Library:
                name = "서재";
                break;
            case Anomaly_Location.Bed_Room:
                name = "침실";
                break;
            case Anomaly_Location.Bath_Room:
                name = "욕실";
                break;
            case Anomaly_Location.Hallway:
                name = "복도";
                break;
            case Anomaly_Location.Kichen:
                name = "부엌";
                break;
        }

        return name;
    }
}
