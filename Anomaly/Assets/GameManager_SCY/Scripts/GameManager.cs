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
    [SerializeField]private int timeHour;

    private int index;
    private float clicking = 0;
    private float anomalyGenerateTime;//이상 현상 발생 시간 체크
    private float anomalyCicle;//이상 현상 발생 주기
    private bool canClick;
    private bool nowPlaying;
    public bool NowPlaying
    {
        get { return nowPlaying; }
    }

    [HideInInspector] public int resolvedAnomaly;
    [HideInInspector] public int anomalyCount;

    [HideInInspector] public Vector2 mouseposition;
    [HideInInspector] public Vector2 newMousePosition;

    [HideInInspector] public Anomaly_Type nowSelectedType;
    [HideInInspector] public Anomaly_Location nowSelectedLocation;

    public LayerMask anomalyLayer;

    AnormalyBase nowCheckingAnomaly;

    public event Action<Vector3> OnRightMouseClick;//오른쪽 마우스 버튼 클릭
    public event Action OnLeftMouseClick;//왼쪽 마우스 버튼 클릭
    public event Action<float> OnClicking;//왼쪽 마우스 버튼 클릭 중
    public event Action CloseUI;//특정 UI 창 닫기 위한 이벤트

    public event Action<int, int> UpdateTimeText;//시간 체크 이벤트
    public event Action OnCheckingAnomaly;//이상현상 체크중 이벤트
    public event Action AnomalyWarning;//이상현상이 3개 쌓였을 때 이벤트
    public event Action OnAnomalyResolve;//이상현상이 해결될 때 이벤트
    public event Action OnNoAnomaly;//이상현상이 없을 때 이벤트
    public event Action DontInterect;//상호작용할 수 없는 이상현상일 때 이벤트
    public event Action OnPause;//일시정시 시

    public event Action OnGameClear;//게임 클리어 시 이벤트
    public event Action OnGameover;//게임 오버 시 이벤트

    private void Awake()
    {
        isDontDestroy = false;

        UIManager.Instance.UIList.Clear();
        UIManager.Instance.canvasList.Clear();

        time = 0;
        timeSecond = 0;
        timeMinute = 0;
        timeHour = 0;

        index = 0;
        anomalyGenerateTime = 0;
        anomalyCicle = UnityEngine.Random.Range(20f, 30f);

        canClick = true;
        nowPlaying = true;
    }

    private void Start()
    {
        AnormalyController.Instance.UpdateAnomaly += UpdateAnomalyCount;

        resolvedAnomaly = 0;

        anomalyLayer = 1 << 31;

        ResumeGame();
    }

    //--------------------------------------------------------------------------------------------------------------------
    //game Update

    private void Update()
    {
        if (nowPlaying)
        {
            Input();

            GenerateAnomaly();

            UpdateTime();
        }
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

            if (timeMinute >= 60)
            {
                timeHour += 1;
                timeMinute -= 60;
            }

            UpdateTimeText?.Invoke(timeHour, timeMinute);
        }

        if(timeHour >= 6)
        {
            GameClear();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    private void Input()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                OnLeftMouseClick?.Invoke();
                newMousePosition = UnityEngine.Input.mousePosition;
            }
        }

        if (canClick && UnityEngine.Input.GetMouseButtonDown(1))
        {
            OnRightMouseClick?.Invoke(UnityEngine.Input.mousePosition);
        }

        if (canClick && UnityEngine.Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            clicking += Time.deltaTime;

            if (clicking >= 0.5f)
            {
                OnClicking?.Invoke(clicking);
                if (clicking >= 2f)
                {
                    CheckObjectAnomaly(newMousePosition);
                }
            }
        }

        if (UnityEngine.Input.GetMouseButtonUp(0))
        {
            clicking = 0;
            if (canClick)
            {
                CloseUI?.Invoke();
            }
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause?.Invoke();
        }
    }

    private void UpdateAnomalyCount()
    {
        anomalyCount = AnormalyController.Instance.anomalyList.FindAll(x => x.IsAppear).Count;
        Debug.Log(anomalyCount);

        if(anomalyCount == 3)//이상 현상 3개 중첩 시
        {
            AnomalyWarning?.Invoke();
        }

        if(anomalyCount >= 4)
        {
            Die();
        }
    }

    public void Die()
    {
        nowPlaying = false;
        OnGameover?.Invoke();
    }

    private void GameClear()
    {
        nowPlaying = false;
        OnGameClear?.Invoke();
    }

    //--------------------------------------------------------------------------------------------------------------------
    //check anoramly
    private void CheckObjectAnomaly(Vector3 mousePosition)
    {
        canClick = false;

        this.mouseposition = mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mouseposition);
        RaycastHit[] hits;
        clicking = 0;

        hits = Physics.RaycastAll(ray, 100f, anomalyLayer);

        nowCheckingAnomaly = null;

        foreach (RaycastHit hit in hits)
        {
            AnormalyBase anomaly = hit.transform.GetComponentInParent<AnormalyBase>();

            if (anomaly.IsAppear)
            {
                nowCheckingAnomaly = anomaly;
                break;
            }
        }

        if (nowCheckingAnomaly != null && nowCheckingAnomaly.A_Type == Anomaly_Type.Abyss)
        {
            DontInterect?.Invoke();
            canClick = true;
        }
        else
        {
            OnCheckingAnomaly?.Invoke();
            Invoke("CheckAnomaly", 3f);
        }
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

        if (nowPlaying)
        {
            if (nowCheckingAnomaly != null && nowCheckingAnomaly.IsAppear)
            {
                nowCheckingAnomaly.ResolveAnomaly();

                OnAnomalyResolve?.Invoke();
                resolvedAnomaly++;
            }
            else
            {
                OnNoAnomaly?.Invoke();
            }
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
        anomalyCicle = UnityEngine.Random.Range(25f, 40f);
    }

}
