using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler,IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI _text;
    
    [SerializeField] private Color _normal = Color.white;
    [SerializeField] private Color _highlited = new (0.71f, 0.71f, 0.71f);
    [SerializeField] private Color _pressed = new (0.49f, 0.49f, 0.49f);

    public event Action Click;
    
    public void OnPointerClick(PointerEventData eventData) => Click?.Invoke();
    
    public void OnPointerDown(PointerEventData eventData) => _text.color = _pressed;
    
    public void OnPointerEnter(PointerEventData eventData) => _text.color = _highlited;

    public void OnPointerExit(PointerEventData eventData) => _text.color = _normal;
    
    public void OnPointerUp(PointerEventData eventData) => _text.color = _normal;
    
}
