using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate360 : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * 180 * Time.deltaTime * speed);
    }
}
