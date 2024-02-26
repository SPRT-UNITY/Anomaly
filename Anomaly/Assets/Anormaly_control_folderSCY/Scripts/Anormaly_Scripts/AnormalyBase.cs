using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Anormaly_Location
{
    Living_Room,
    Bed_Room,
    Kichen,
    Library,
    Collider,
    Bath_Room
}

public enum Anormaly_Type
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
    [field: SerializeField] public Anormaly_Location A_Location { get; protected set; }
    [field: SerializeField] public Anormaly_Type A_Type { get; protected set; }
    [field: SerializeField] public GameObject normalObject { get; private set; }
    [field: SerializeField] public GameObject anormalObject { get; private set; }

    [HideInInspector] public bool IsAppear;

    private void Awake()
    {
        IsAppear = false;
    }


    public virtual void GenerateAnormaly()
    {
        IsAppear = true;
    }

    public virtual void ResolveAnormaly()
    {
        IsAppear = false;
    }
}
