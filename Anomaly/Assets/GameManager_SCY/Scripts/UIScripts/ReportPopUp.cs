using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportPopUp : UIBase
{
    [SerializeField] private GameObject selectType;
    [SerializeField] private GameObject selectLocation;

    private void Start()
    {
        GameManager.Instance.OnRightMouseClick += UpdatePosition;
        GameManager.Instance.OnLeftMouseClick += ResetUI;

        selectLocation.SetActive(false);
        selectType.SetActive(true);

        gameObject.SetActive(false);
    }

    public void UpdatePosition(Vector3 position)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            transform.position = position;

            LimitPosition();
        }
    }

    private void LimitPosition()
    {
        Rect rect = GetComponent<RectTransform>().rect;

        Vector2 rightTop = transform.TransformPoint(rect.max);

        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        float uiWidth = rightTop.x - transform.position.x;
        float uiHeight = rightTop.y - transform.position.y;

        float x = Mathf.Clamp(transform.position.x, 0 + uiWidth, screenSize.x - uiWidth);
        float y = Mathf.Clamp(transform.position.y, 0 + uiHeight, screenSize.y - uiHeight);

        transform.position = new Vector2(x, y);
    }

    public void OnClickAType(int type)
    {
        GameManager.Instance.nowSelectedType = (Anomaly_Type)type;
        selectLocation.SetActive(true);
        selectType.SetActive(false);
    }

    public void OnClickLocation(int location)
    {
        GameManager.Instance.nowSelectedLocation = (Anomaly_Location)location;
        GameManager.Instance.CheckEnvironmentAnomaly();
        selectLocation.SetActive(false);
        selectType.SetActive(true);
        CloseUI();
    }

    public void ResetUI()
    {
        selectLocation.SetActive(false);
        selectType.SetActive(true);
        CloseUI();
    }

    public void OnClickBackButton()
    {
        selectLocation.SetActive(false);
        selectType.SetActive(true);
    }
}
