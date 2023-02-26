using UnityEngine;

namespace Code.Services
{
    public struct ControlAction
    {
        public KeyCode KeyCode;
        public ControlActionType ActionType;

        public ControlAction(KeyCode keyCode, ControlActionType actionType)
        {
            KeyCode = keyCode;
            ActionType = actionType;
        }
    }
}