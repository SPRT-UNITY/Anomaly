using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    protected void CloseUI()
    {
        gameObject.SetActive(false);
    }
}