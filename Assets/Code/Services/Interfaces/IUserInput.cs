using UnityEngine;

namespace Code.Services.Interfaces
{
    public interface IUserInput
    {
        public Vector2 GetMouseAxis();

        public bool IsKeyPressed(KeyCode keyCode);
        public bool IsLeftMousePressed();
        public bool IsRightMousePressed();
        
    }
}