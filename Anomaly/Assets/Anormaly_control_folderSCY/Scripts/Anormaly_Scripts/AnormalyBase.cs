using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Anomaly_Location
{
    Living_Room,
    Bed_Room,
    Kichen,
    Library,
    Collider,
    Bath_Room
}

public enum Anomaly_Type
{
    Object,
    Camera,
    Light,
    Mist,
    Intruder,
    Abyss
}

public class AnormalyBase : MonoBehaviour
{
    [field: SerializeField] public Anomaly_Location A_Location { get; protected set; }
    [field: SerializeField] public Anomaly_Type A_Type { get; protected set; }
    [field: SerializeField] public GameObject NormalObject { get; private set; }
    [field: SerializeField] public GameObject AnormalObject { get; private set; }

    [HideInInspector] public bool IsAppear;

    private void Awake()
    {
        IsAppear = false;
    }


    public virtual void GenerateAnomaly()
    {
        IsAppear = true;
    }

    public virtual void ResolveAnomaly()
    {
        IsAppear = false;
    }
}
