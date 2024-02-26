using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class AnormalyController : SingletoneBase<AnormalyController>
{
    public List<AnormalyBase> anormalyList = new List<AnormalyBase>();

    public event System.Action UpdateAnormaly;

    private void Awake()
    {
        isDontDestroy = false;
        Init();
    }

    private void Start()
    {
        ShuffleAnormaly();
    }

    //------------------------------------------------------------------------------------
    //Test Code
    public void GenerateAnormaly()
    {
        anormalyList[0].GenerateAnormaly();
    }

    public void TempButtoen()
    {
        AnormalyBase anormaly = CheckEnvironmentAnormaly(Anormaly_Location.Living_Room, Anormaly_Type.Object);

        if(anormaly == null)
        {
            Debug.Log("NoAnormaly");
        }
        else
        {
            anormaly.ResolveAnormaly();
        }
    }
    //------------------------------------------------------------------------------------

    public void ShuffleAnormaly()
    {
        anormalyList = ShuffleList(anormalyList);
    }

    public AnormalyBase GetAnormaly(int index)
    {
        var list = anormalyList.FindAll(x => x.IsAppear == false);

        return list[index];
    }

    public void GenerateAnormaly(int index)
    {
        anormalyList[index].GenerateAnormaly();
        UpdateAnormaly?.Invoke();
    }

    public AnormalyBase CheckEnvironmentAnormaly(Anormaly_Location location, Anormaly_Type type)
    {
        AnormalyBase anormaly = anormalyList.Find(x => x.A_Location == location && x.A_Type == type && x.IsAppear);

        return anormaly;
    }
    

    //-------------------------------------------------------------------------------------------------------------------------
    private List<T> ShuffleList<T>(List<T> list)
    {
        int random1, random2;
        T temp;

        for (int i = 0; i < list.Count; ++i)
        {
            random1 = Random.Range(0, list.Count);
            random2 = Random.Range(0, list.Count);

            temp = list[random1];
            list[random1] = list[random2];
            list[random2] = temp;
        }

        return list;
    }
}
