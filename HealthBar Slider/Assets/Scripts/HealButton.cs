using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class HealButton : MonoBehaviour, IPointerClickHandler
{
    public event Action Healed;
    public void OnPointerClick(PointerEventData eventData)
    {
        Healed?.Invoke();
    }
}