using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class UIManager : SingletoneBase<UIManager>
{
    public List<UIBase> UIList;
    public List<CanvasBase> canvasList; 

    //[SerializeField] private Canvas canvas;

    private void Awake()
    {
        isDontDestroy = true;
        Init();

        if (SoundManager.Instance == null)
        {
            SoundManager.Instance.Init();
        }

        UIList = new List<UIBase>();
        canvasList = new List<CanvasBase>();
    }

    public void OpenUI(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void CloseUI(GameObject obj)
    {
        obj.SetActive(false);
    }

    public CanvasBase GetCanvas(string CanvasName)
    {
        CanvasBase canvas = canvasList.Find(canvas => canvas.name == CanvasName);

        if(canvas == null)
        {
            return null;
        }

        return canvas;
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

    //public void InitiateUI(string UIName)
    //{
    //    UIBase ui = UIList.Find(ui => ui.name == UIName);

    //    if (ui == null)
    //    {
    //        return;
    //    }

    //    ui.InstantiateUI(canvas);
    //}

    //public void Show(string UIName)
    //{
    //    UIBase ui = UIList.Find(ui => ui.name == UIName);

    //    if (ui == null)
    //    {
    //        return;
    //    }

    //    ui.Show();
    //}
}
