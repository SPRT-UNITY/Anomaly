using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBase : MonoBehaviour
{
    [SerializeField] private List<GameObject> UIgoList = new List<GameObject>();

    private void Start()
    {
        foreach(GameObject go in UIgoList)
        {
            GameObject obj = Instantiate(go, transform);
            obj.name = obj.name.Replace("(Clone)", "");
        }

        UIManager.Instance.canvasList.Add(this);
    }
}
