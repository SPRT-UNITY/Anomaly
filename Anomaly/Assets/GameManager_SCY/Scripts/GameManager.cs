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
    private float anomalyGenerateTime;//�̻� ���� �߻� �ð� üũ
    private float anomalyCicle;//�̻� ���� �߻� �ֱ�
    private bool canClick;
    private bool nowPlaying;

    [HideInInspector] public int resolvedAnomaly;
    [HideInInspector] public int anomalyCount;

    [HideInInspector] public Vector2 mouseposition;
    [HideInInspector] public Vector2 newMousePosition;

    [HideInInspector] public Anomaly_Type nowSelectedType;
    [HideInInspector] public Anomaly_Location nowSelectedLocation;

    public LayerMask anomalyLayer;

    AnormalyBase nowCheckingAnomaly;

    public event Action<Vector3> OnRightMouseClick;//������ ���콺 ��ư Ŭ��
    public event Action OnLeftMouseClick;//���� ���콺 ��ư Ŭ��
    public event Action<float> OnClicking;//���� ���콺 ��ư Ŭ�� ��
    public event Action CloseUI;//UI â �ݴ� �̺�Ʈ

    public event Action<int, int> UpdateTimeText;
    public event Action OnCheckingAnomaly;//�̻����� üũ�� �̺�Ʈ
    public event Action AnomalyWarning;//�̻������� 3�� �׿��� �� �̺�Ʈ
    public event Action OnAnomalyResolve;
    public event Action OnNoAnomaly;
    public event Action DontInterect;

    public event Action OnGameClear;//���� Ŭ���� �� �̺�Ʈ
    public event Action OnGameover;//���� ���� �� �̺�Ʈ

    private void Awake()
    {
        UIManager.Instance.UIList.Clear();
        UIManager.Instance.canvasList.Clear();

        time = 0;
        timeSecond = 0;
        timeMinute = 0;
        timeHour = 0;

        index = 0;
        anomalyGenerateTime = 0;
        anomalyCicle = UnityEngine.Random.Range(5f, 15f);

        isDontDestroy = false;
        canClick = true;
        nowPlaying = true;
        Init();
    }

    private void Start()
    {
        AnormalyController.Instance.UpdateAnomaly += UpdateAnomalyCount;

        resolvedAnomaly = 0;

        anomalyLayer = 1 << 31;
    }

    //--------------------------------------------------------------------------------------------------------------------
    //game Update

    private void Update()
    {
        if (nowPlaying)
        {
            MouseInput();

            GenerateAnomaly();

            UpdateTime();
        }
    }

    private void UpdateTime()// ���� �ð� �� 15��
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

        if(anomalyCount == 3)//�̻� ���� 3�� ��ø ��
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
