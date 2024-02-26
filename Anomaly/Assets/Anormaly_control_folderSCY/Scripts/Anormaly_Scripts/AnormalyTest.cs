using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnormalyTest : AnormalyBase
{
    private void Awake()
    {
        this.A_Location = Anormaly_Location.Living_Room;
        this.A_Type = Anormaly_Type.Object;

        ObjectContainer.instance.testObject = this.gameObject;
    }

    public override void GenerateAnormaly()
    {
        base.GenerateAnormaly();
    }

    public override void ResolveAnormaly()
    {
        base.ResolveAnormaly();
    }
}
