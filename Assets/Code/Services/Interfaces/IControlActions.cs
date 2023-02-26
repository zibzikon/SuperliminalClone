using UnityEngine;

namespace Code.Services.Interfaces
{
    public interface IControlActions
    {
        ControlActionType GetAction(KeyCode keyCode);
        KeyCode GetKeyCode(ControlActionType actionType);
    }
}