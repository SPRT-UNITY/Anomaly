using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AnormalyObject : MonoBehaviour
{
    public event Action anormalResolvedEvent;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        anormalResolvedEvent?.Invoke();
    }

    private void OnDrawGizmos()
    {
        float size = GetComponent<SphereCollider>() ? GetComponent<SphereCollider>().radius : 1f;
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, size);
    }
}
