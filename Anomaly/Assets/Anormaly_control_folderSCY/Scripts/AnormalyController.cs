using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class AnormalyController : SingletoneBase<AnormalyController>
{
    public List<AnormalyBase> anomalyList = new List<AnormalyBase>();

    public event System.Action UpdateAnomaly;

    private bool isStart;

    private void Awake()
    {
        isDontDestroy = false;
        Init();
    }

    private void Start()
    {
        isStart = false;
    }

    //------------------------------------------------------------------------------------
    //Test Code
    public void GenerateAnomaly()
    {
        anomalyList[0].GenerateAnomaly();
    }

    public void TempButtoen()
    {
        AnormalyBase anomaly = CheckEnvironmentAnomaly(Anomaly_Location.Living_Room, Anomaly_Type.Object);

        if(anomaly == null)
        {
            Debug.Log("NoAnomaly");
        }
        else
        {
            anomaly.ResolveAnomaly();
        }
    }
    //------------------------------------------------------------------------------------

    public void ShuffleAnomaly()
    {
        anomalyList = ShuffleList(anomalyList);
    }

    public AnormalyBase GetAnomaly(int index)
    {
        var list = anomalyList.FindAll(x => x.IsAppear == false);

        return list[index];
    }

    public void GenerateAnomaly(int index)
    {
        if (!isStart)
        {
            ShuffleAnomaly();
            isStart = true;
        }

        anomalyList[index].GenerateAnomaly();
        UpdateAnomaly?.Invoke();
    }

    public AnormalyBase CheckEnvironmentAnomaly(Anomaly_Location location, Anomaly_Type type)
    {
        AnormalyBase anormaly = anomalyList.Find(x => x.A_Location == location && x.A_Type == type && x.IsAppear);

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
