using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : SingletoneBase<GameManager>
{
    private float time;
    private int timeSecond;
    private int timeMinute;
    private int timeHour;

    private float clicking = 0;
    private float anomalyGenerateTime;//이상 현상 발생 시간 체크
    private float anomalyCicle;//이상 현상 발생 주기
    private bool canClick;
    private int index;

    [HideInInspector] public int resolvedAnomaly;
    [HideInInspector] public int anomalyCount;

    [HideInInspector] public Vector2 mouseposition;
    [HideInInspector] public Vector2 newMousePosition;

    [HideInInspector] public Anomaly_Type nowSelectedType;
    [HideInInspector] public Anomaly_Location nowSelectedLocation;

    public LayerMask anomalyLayer;

    AnormalyBase nowCheckingAnomaly;

    public event Action<Vector3> OnRightMouseClick;
    public event Action OnLeftMouseClick;
    public event Action<float> OnClicking;
    public event Action CloseUI;

    public event Action OnCheckingAnomaly;
    public event Action AnomalyWarnning;

    public event Action OnGameClear;
    public event Action OnGameover;

    private void Awake()
    {
        time = 0;
        timeSecond = 0;
        timeMinute = 0;
        timeHour = 0;

        index = 0;
        anomalyGenerateTime = 0;
        anomalyCicle = UnityEngine.Random.Range(5f, 15f);

        isDontDestroy = false;
        canClick = true;
        Init();
    }

    private void Start()
    {
        AnormalyController.Instance.UpdateAnomaly += UpdateAnomalyCount;

        UIManager.Instance.InitiateUI("HoldMouseUI");
        UIManager.Instance.InitiateUI("ReportPopUp");
        UIManager.Instance.InitiateUI("ArrowButtons");
        UIManager.Instance.InitiateUI("CheckingText");
    }

    //--------------------------------------------------------------------------------------------------------------------
    //game Update

    private void Update()
    {
        MouseInput();

        GenerateAnomaly();

        UpdateTime();
    }

    private void UpdateTime()// 게임 시간 약 15분
    {
        time += Time.deltaTime;

        if (time >= 1f)
        {
            timeSecond += 24;
            time = 0f;
        }

        if (timeSecond >= 60)
        {
            timeMinute += 1;
            timeSecond -= 60;
        }

        if (timeMinute >= 60)
        {
            timeHour += 1;
            timeMinute -= 60;
        }

        if(timeHour >= 6)
        {
            GameClear();
        }
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                OnLeftMouseClick?.Invoke();
                newMousePosition = Input.mousePosition;
            }
        }

        if (canClick && Input.GetMouseButtonDown(1))
        {
            OnRightMouseClick?.Invoke(Input.mousePosition);
        }

        if (canClick && Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            clicking += Time.deltaTime;

            if (clicking >= 0.5f)
            {
                OnClicking?.Invoke(clicking);
                if (clicking >= 2f)
                {
                    Debug.Log("Checking");
                    CheckObjectAnomaly(newMousePosition);
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

    private void UpdateAnomalyCount()
    {
        anomalyCount = AnormalyController.Instance.anomalyList.FindAll(x => x.IsAppear).Count;
        Debug.Log(anomalyCount);

        if(anomalyCount == 3)//이상 현상 3개 중첩 시
        {
            Debug.Log("Warnning");
            AnomalyWarnning?.Invoke();
        }

        if(anomalyCount >= 4)
        {
            Die();
        }
    }

    public void Die()
    {
        OnGameover?.Invoke();
    }

    private void GameClear()
    {
        Time.timeScale = 0;
        Debug.Log("GameClear");

        OnGameClear?.Invoke();
    }

    //--------------------------------------------------------------------------------------------------------------------
    //check anoramly
    private void CheckObjectAnomaly(Vector3 mousePosition)
    {
        canClick = false;

        this.mouseposition = mousePosition;
        OnCheckingAnomaly?.Invoke();

        Ray ray = Camera.main.ScreenPointToRay(mouseposition);
        RaycastHit hit;
        clicking = 0;

        if (Physics.Raycast(ray, out hit, 100f, anomalyLayer))
        {
            nowCheckingAnomaly = hit.transform.GetComponentInParent<AnormalyBase>();
        }
        else
        {
            nowCheckingAnomaly = null;
        }

        Invoke("CheckAnomaly", 3f);
    }

    public void CheckEnvironmentAnomaly()
    {
        canClick = false;
        OnCheckingAnomaly?.Invoke();

        nowCheckingAnomaly = AnormalyController.Instance.CheckEnvironmentAnomaly(nowSelectedLocation, nowSelectedType);

        Invoke("CheckAnomaly", 3f);
    }

    private void CheckAnomaly()
    {
        CloseUI?.Invoke();

        if (nowCheckingAnomaly != null && nowCheckingAnomaly.IsAppear)
        {
            nowCheckingAnomaly.ResolveAnomaly();
            Debug.Log("Success");
        }
        else
        {
            Debug.Log("NoAnormaly");
        }

        canClick = true;
    }

    //--------------------------------------------------------------------------------------------------------------------
    //generate anomary
    private void GenerateAnomaly()
    {
        anomalyGenerateTime += Time.deltaTime;

        if(anomalyGenerateTime >= anomalyCicle)
        {
            SetGenerateTime();
            anomalyGenerateTime = 0;
            AnormalyController.Instance.GenerateAnomaly(index);
            index++;

            if(index >= AnormalyController.Instance.anomalyList.Count)
            {
                index = 0;
            }
        }
    }

    private void SetGenerateTime()
    {
        anomalyCicle = UnityEngine.Random.Range(10f, 20f);
    }

}
