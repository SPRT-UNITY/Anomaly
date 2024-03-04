using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEmission : MonoBehaviour
{
    [SerializeField] private MeshRenderer _MeshRenderer;

    private void OnEnable()
    {
        Disable(_MeshRenderer.material);
    }

    //Disable Emission
    public static void Disable(Material _material)
    {
        _material.DisableKeyword("_EMISSION");
    }
}
