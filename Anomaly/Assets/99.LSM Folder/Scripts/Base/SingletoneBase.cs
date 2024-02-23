using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    //Property
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                //Create Object
                string typeName = typeof(T).Name;
                GameObject obj = new GameObject(typeName);

                _instance = obj.AddComponent<T>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public virtual void Init()
    {
        Debug.Log(transform.name + "is Init");
    }
}
