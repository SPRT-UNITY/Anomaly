using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPointerEnter_Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject OnMouseImage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseImage.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnMouseImage.SetActive(false);
    }

    public void OnMouseImage_ActiveFalse() => OnMouseImage.SetActive(false);
}
