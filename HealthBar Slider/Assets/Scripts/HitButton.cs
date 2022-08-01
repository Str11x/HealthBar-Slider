using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class HitButton : MonoBehaviour, IPointerClickHandler
{
    public event Action Hitted;

    public void OnPointerClick(PointerEventData eventData)
    {
        Hitted?.Invoke();
    }
}