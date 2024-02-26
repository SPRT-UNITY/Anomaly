using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float clicking = 0;
    private bool canClick;

    [HideInInspector] public Vector2 mouseposition;

    public LayerMask anormalyLayer;

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

    private void Update()
    {
        if (canClick && Input.GetMouseButtonDown(0))
        {
            mouseposition = Input.mousePosition;
        }

        if (canClick && Input.GetMouseButton(0))
        {
            clicking += Time.deltaTime;

            if (clicking >= 0.5f)
            {
                Debug.Log("input");
                if (clicking >= 2f)
                {
                    canClick = false;
                    clicking = 0;
                    Debug.Log("Checking");
                    Invoke("CheckAnormaly", 3f);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            clicking = 0;
        }
    }

    private void CheckAnormaly()
    {
        Debug.Log("1");

        Ray ray = Camera.main.ScreenPointToRay(mouseposition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, anormalyLayer))
        {
            hit.transform.GetComponentInParent<AnormalyBase>().ResolveAnormaly();
            Debug.Log("Success");
        }
        else
        {
            Debug.Log("NoAnormaly");
        }

        canClick = true;
    }
}
