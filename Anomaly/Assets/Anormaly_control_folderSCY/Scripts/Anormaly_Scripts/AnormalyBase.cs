using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum Anormaly_Location
{
    Living_Room,
    Bed_Room,
    Kichen,
    Library,
    Collider,
    Bath_Room
}


[Serializable]
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
    [field: SerializeField]
    public Anormaly_Location A_Location { get; protected set; }
    [field: SerializeField]
    public Anormaly_Type A_Type { get; protected set; }

    [field: SerializeField]
    public GameObject normalObject { get; private set; }

    [field: SerializeField]
    public AnormalyObject anormalObject { get; private set; }

    private void Awake()
    {
        normalObject = gameObject.transform.Find("normal").gameObject;
        anormalObject = gameObject.transform.Find("anormal").GetComponent<AnormalyObject>();
        anormalObject.anormalResolvedEvent += ResolveAnormaly;
    }

    public virtual void GenerateAnormaly()
    {
        normalObject.SetActive(true);
        anormalObject.gameObject.SetActive(false);
    }

    public virtual void ResolveAnormaly()
    {
        normalObject.SetActive(false);
        anormalObject.gameObject.SetActive(true);
    }
}
