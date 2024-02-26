using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    protected bool isDontDestroy;

    //Property
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;

                if (_instance == null)
                {
                    //Create Object
                    string typeName = typeof(T).Name;
                    GameObject obj = new GameObject(typeName);

                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    public virtual void Init()
    {
        if(_instance == null)
        {
            _instance = this as T;
            if (isDontDestroy)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

        Debug.Log(transform.name + "is Init");
    }
}
