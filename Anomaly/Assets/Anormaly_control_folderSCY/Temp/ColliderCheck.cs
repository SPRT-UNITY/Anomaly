using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //other.GetComponentInParent<AnormalyObject>().anormaly.ResolveAnormaly();
        //Debug.Log(other.GetComponentInParent<AnormalyObject>().anormaly.A_Location);
    }
}
