using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnormalyCameraDisappear : AnormalyBase
{
    public override void GenerateAnomaly()
    {
        base.GenerateAnomaly();
        int outCamera = Random.Range(0, CameraManager.Instance.cameras.Count);

        A_Location = CameraManager.Instance.CameraLookLocation(outCamera);
        Debug.Log(A_Location);

        CameraManager.Instance.isProblem = true;
        CameraManager.Instance.outWorkCamera = outCamera;
    }

    public override void ResolveAnomaly()
    {
        base.ResolveAnomaly();

        CameraManager.Instance.isProblem = false;
        CameraManager.Instance.outWorkCamera = -1;
    }
}
