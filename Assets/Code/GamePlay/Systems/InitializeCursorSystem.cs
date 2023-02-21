using Entitas;
using UnityEngine;

namespace Code.GamePlay.Systems
{
    public class InitializeCursorSystem : IInitializeSystem
    {
        public void Initialize()
        {
            Cursor.lockState = CursorLockMode.Locked;        
            Cursor.visible = false;
        }
    }
}