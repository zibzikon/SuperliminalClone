using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.UI
{
    public class TextButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler,IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TextMeshProUGUI _text;
    
        [SerializeField] private Color _normalColor = Color.white;
        [SerializeField] private Color _highlitedColor = new (0.71f, 0.71f, 0.71f);
        [SerializeField] private Color _lockedColor = new (0.71f, 0.71f, 0.71f);
        [SerializeField] private Color _pressedColor = new (0.49f, 0.49f, 0.49f);

        private bool _locked;
    
        public event Action Pressed;

        public void Lock()
        {
            _locked = true;
            _text.color = _lockedColor;
        }

        public void Unlock()
        {
            _locked = false;   
            _text.color = _normalColor;
        }
    
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_locked)return;
            Pressed?.Invoke();
        }
    
        public void OnPointerDown(PointerEventData eventData)
        {
            if (_locked)return;
            _text.color = _pressedColor;
        }
    
        public void OnPointerEnter(PointerEventData eventData) 
        {        
            if (_locked)return;
            _text.color = _highlitedColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_locked)return;
            _text.color = _normalColor;
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            if (_locked)return;
            _text.color = _normalColor;
        }
    
    }
}
