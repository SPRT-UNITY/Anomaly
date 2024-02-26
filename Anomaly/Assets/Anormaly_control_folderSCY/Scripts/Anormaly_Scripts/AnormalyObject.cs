using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnormalyObject : AnormalyBase
{
    public override void GenerateAnormaly()
    {
        base.GenerateAnormaly();
        normalObject.SetActive(false);
        anormalObject.SetActive(true);
    }

    public override void ResolveAnormaly()
    {
        base.ResolveAnormaly();
        normalObject.SetActive(true);
        anormalObject.SetActive(false);
    }
}
