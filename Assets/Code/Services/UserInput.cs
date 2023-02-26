using Code.Services.Interfaces;
using UnityEngine;

namespace Code.Services
{
    public class UserInput : IUserInput
    {
        public Vector2 GetMouseAxis() => new (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        
        public bool IsKeyPressed(KeyCode keyCode) => Input.GetKey(keyCode);

        public bool IsLeftMousePressed() => Input.GetMouseButton(0);

        public bool IsRightMousePressed() => Input.GetMouseButton(1);
    }
}