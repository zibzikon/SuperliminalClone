using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlActions : IControlActions
{
    private Dictionary<KeyCode, ControlActionType> _actions;
    private Dictionary<ControlActionType, KeyCode> _keyCodes;

    public ControlActions(ControlAction[] actions)
    {
        _actions = actions.ToDictionary(x => x.KeyCode, x => x.ActionType);
        _keyCodes = actions.ToDictionary(x => x.ActionType, x => x.KeyCode);
    }

    public ControlActionType GetAction(KeyCode keyCode)
        => _actions[keyCode];

    public KeyCode GetKeyCode(ControlActionType actionType)
        => _keyCodes[actionType];
}