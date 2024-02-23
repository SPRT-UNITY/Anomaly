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

public class AnormalyBase
{
    public Anormaly_Location A_Location { get; protected set; }
    public Anormaly_Type A_Type { get; protected set; }

    public bool IsAppear;

    public AnormalyBase()
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

    protected GameObject GetNormalObject(GameObject obj)
    {
        return obj.transform.Find("normal").gameObject;
    }

    protected GameObject GetAnormalObject(GameObject obj)
    {
        return obj.transform.Find("anormal").gameObject;
    }
}
