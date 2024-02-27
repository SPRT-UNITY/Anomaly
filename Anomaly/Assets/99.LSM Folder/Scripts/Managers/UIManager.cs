using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class UIManager : SingletoneBase<UIManager>
{
    public List<UIBase> UIList = new List<UIBase>();
    [SerializeField] private Canvas canvas;

    private void Awake()
    {
        isDontDestroy = true;
        Init();
    }

    public void OpenUI(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void CloseUI(GameObject obj)
    {
        obj.SetActive(false);
    }

    public UIBase GetUI(string UIName)
    {
        UIBase ui = UIList.Find(ui => ui.name == UIName);

        if (ui == null)
        {
            return null;
        }

        return ui;
    }

    public void InitiateUI(string UIName)
    {
        UIBase ui = UIList.Find(ui => ui.name == UIName);

        if (ui == null)
        {
            return;
        }

        ui.InstantiateUI(canvas);
    }

    public void Show(string UIName)
    {
        UIBase ui = UIList.Find(ui => ui.name == UIName);

        if (ui == null)
        {
            return;
        }

        ui.Show();
    }
}
