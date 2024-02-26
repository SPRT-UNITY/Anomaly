using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnormalyObject : AnormalyBase
{
    public override void GenerateAnormaly()
    {
        base.GenerateAnormaly();
        NormalObject.SetActive(false);
        AnormalObject.SetActive(true);
    }

    public override void ResolveAnormaly()
    {
        base.ResolveAnormaly();
        NormalObject.SetActive(true);
        AnormalObject.SetActive(false);
    }
}
