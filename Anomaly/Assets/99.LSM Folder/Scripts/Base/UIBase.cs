using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    public void InstantiateUI(Canvas canvas)
    {
        Instantiate(gameObject, canvas.transform);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void DestroyUI()
    {
        Destroy(gameObject);
    }

    public virtual void CloseUI()
    {
        gameObject.SetActive(false);
    }
}
