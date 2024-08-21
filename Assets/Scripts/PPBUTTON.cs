using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PPBUTTON : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action PPPRESS;

    private bool PPisTouching = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        PPisTouching = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PPisTouching = false;
    }

    void Update()
    {
        if (PPisTouching)
            PPPRESS?.Invoke();
    }
}