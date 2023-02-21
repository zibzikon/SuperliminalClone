using UnityEngine;

public interface IControlActions
{
    ControlActionType GetAction(KeyCode keyCode);
    KeyCode GetKeyCode(ControlActionType actionType);
}