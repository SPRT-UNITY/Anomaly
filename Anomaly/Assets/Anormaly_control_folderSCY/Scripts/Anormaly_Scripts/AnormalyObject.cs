using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnormalyObject : AnormalyBase
{
    public override void GenerateAnomaly()
    {
        base.GenerateAnomaly();
        NormalObject.SetActive(false);
        AnormalObject.SetActive(true);
    }

    public override void ResolveAnomaly()
    {
        base.ResolveAnomaly();
        NormalObject.SetActive(true);
        AnormalObject.SetActive(false);
    }
}
