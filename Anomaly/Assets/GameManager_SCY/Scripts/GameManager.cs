using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float clicking = 0;
    private bool canClick;
    [HideInInspector] public int resolvedAnormaly;
    [HideInInspector] public int anormalyCount;

    [HideInInspector] public Vector2 mouseposition;
    [HideInInspector] public Vector2 newMousePosition;

    [HideInInspector] public Anormaly_Type nowSelectedType;
    [HideInInspector] public Anormaly_Location nowSelectedLocation;

    public LayerMask anormalyLayer;

    AnormalyBase nowCheckingAnormaly;

    public event Action<float> OnClicking;
    public event Action CloseUI;
    public event Action OnCheckingAnormaly;
    public event Action OnGameover;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        canClick = true;
    }

    private void Start()
    {
        AnormalyController.instance.UpdateAnormaly += UpdateAnormalyCount;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                newMousePosition = Input.mousePosition;
            }
        }

        if (canClick && Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            clicking += Time.deltaTime;

            if (clicking >= 0.5f)
            {
                OnClicking?.Invoke(clicking);
                if (clicking >= 2f)
                {
                    canClick = false;
                    Debug.Log("Checking");
                    CheckObjectAnormaly(newMousePosition);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            clicking = 0;
            if (canClick)
            {
                CloseUI?.Invoke();
            }
        }
    }

    private void UpdateAnormalyCount()
    {
        anormalyCount = AnormalyController.instance.anormalyList.FindAll(x => x.IsAppear).Count;

        if(anormalyCount >= 4)
        {
            Die();
        }
    }

    public void Die()
    {
        OnGameover?.Invoke();
    }

    private void CheckObjectAnormaly(Vector3 mousePosition)
    {
        this.mouseposition = mousePosition;
        OnCheckingAnormaly?.Invoke();

        Ray ray = Camera.main.ScreenPointToRay(mouseposition);
        RaycastHit hit;
        clicking = 0;

        if (Physics.Raycast(ray, out hit, 100f, anormalyLayer))
        {
            nowCheckingAnormaly = hit.transform.GetComponentInParent<AnormalyBase>();
        }
        else
        {
            nowCheckingAnormaly = null;
        }

        Invoke("CheckAnormaly", 3f);
    }

    public void CheckEnvironmentAnormaly()
    {
        CloseUI?.Invoke();
        nowCheckingAnormaly = AnormalyController.instance.CheckEnvironmentAnormaly(nowSelectedLocation, nowSelectedType);

        Invoke("CheckAnormaly", 3f);
    }

    private void CheckAnormaly()
    {
        CloseUI?.Invoke();

        if (nowCheckingAnormaly != null && nowCheckingAnormaly.IsAppear)
        {
            nowCheckingAnormaly.ResolveAnormaly();
            Debug.Log("Success");
        }
        else
        {
            Debug.Log("NoAnormaly");
        }

        canClick = true;
    }

}
