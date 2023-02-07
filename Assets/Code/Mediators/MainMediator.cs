using UnityEngine;

namespace Code.Domain.Mediators
{
    public class MainMediator : MonoBehaviour
    {
        [SerializeField] private Transform _mainMenuWindowTransform;
        
        public void ShowMainMenu() => _mainMenuWindowTransform.gameObject.SetActive(true);
        public void HideMainMenu() => _mainMenuWindowTransform.gameObject.SetActive(true);
    }
}