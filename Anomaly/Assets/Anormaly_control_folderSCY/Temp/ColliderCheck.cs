using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInParent<AnormalyBase>().ResolveAnormaly();
    }
}
