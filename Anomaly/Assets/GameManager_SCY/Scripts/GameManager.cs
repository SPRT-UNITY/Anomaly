using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float clicking = 0;
    private bool canClick;

    [HideInInspector] public Vector2 mouseposition;
    [HideInInspector] public Vector2 newMousePosition;

    public LayerMask anormalyLayer;

    //-------------------------------------------------
    //UIManager로 옮길 예정
    [SerializeField] GameObject clickingUI;
    private Animator uiAnim;
    //-------------------------------------------------

    AnormalyBase nowCheckingAnormaly;

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
        uiAnim = clickingUI.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            newMousePosition = Input.mousePosition;
        }

        if (canClick && Input.GetMouseButton(0))
        {
            clicking += Time.deltaTime;

            if (clicking >= 0.5f)
            {
                Debug.Log("input");
                UpdateClicking();
                if (clicking >= 2f)
                {
                    canClick = false;
                    Debug.Log("Checking");
                    CheckAnormaly(newMousePosition);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            clicking = 0;
            if (canClick)
            {
                clickingUI.SetActive(false);
            }
        }
    }

    //-------------------------------------------------
    //UIManager로 옮길 예정
    private void UpdateClicking()
    {
        clickingUI.SetActive(true);

        clickingUI.transform.position = newMousePosition;
        clickingUI.transform.GetComponentInChildren<Image>().fillAmount = clicking / 2f;
    }
    //-------------------------------------------------

    private void CheckAnormaly(Vector3 mousePosition)
    {
        this.mouseposition = mousePosition;
        uiAnim.SetBool("Checking", !canClick);

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

    private void CheckAnormaly()
    {
        clickingUI.SetActive(false);

        if(nowCheckingAnormaly != null && nowCheckingAnormaly.IsAppear)
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
