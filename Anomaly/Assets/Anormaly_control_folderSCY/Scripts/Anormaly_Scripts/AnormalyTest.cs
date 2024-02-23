using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnormalyTest : AnormalyBase
{

    public AnormalyTest()
    {
        this.A_Location = Anormaly_Location.Living_Room;
        this.A_Type = Anormaly_Type.Object;

        ObjectContainer.instance.testObject.GetComponent<AnormalyObject>().anormaly = this;
    }

    public override void GenerateAnormaly()
    {
        base.GenerateAnormaly();
        GetAnormalObject(ObjectContainer.instance.testObject).SetActive(true);
        GetNormalObject(ObjectContainer.instance.testObject).SetActive(false);
    }

    public override void ResolveAnormaly()
    {
        base.ResolveAnormaly();
        GetAnormalObject(ObjectContainer.instance.testObject).SetActive(false);
        GetNormalObject(ObjectContainer.instance.testObject).SetActive(true);
    }
}
