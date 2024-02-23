using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletoneBase<UIManager>
{
    public void OpenUI(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void CloseUI(GameObject obj)
    {
        obj.SetActive(false);
    }
}
