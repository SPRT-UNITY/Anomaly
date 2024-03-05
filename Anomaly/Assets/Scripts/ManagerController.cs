using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerController : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.Init();
        AnormalyController.Instance.Init();
    }
}
