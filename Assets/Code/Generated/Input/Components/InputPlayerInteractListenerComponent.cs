//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public PlayerInteractListenerComponent playerInteractListener { get { return (PlayerInteractListenerComponent)GetComponent(InputComponentsLookup.PlayerInteractListener); } }
    public bool hasPlayerInteractListener { get { return HasComponent(InputComponentsLookup.PlayerInteractListener); } }

    public void AddPlayerInteractListener(System.Collections.Generic.List<IPlayerInteractListener> newValue) {
        var index = InputComponentsLookup.PlayerInteractListener;
        var component = (PlayerInteractListenerComponent)CreateComponent(index, typeof(PlayerInteractListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePlayerInteractListener(System.Collections.Generic.List<IPlayerInteractListener> newValue) {
        var index = InputComponentsLookup.PlayerInteractListener;
        var component = (PlayerInteractListenerComponent)CreateComponent(index, typeof(PlayerInteractListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerInteractListener() {
        RemoveComponent(InputComponentsLookup.PlayerInteractListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherPlayerInteractListener;

    public static Entitas.IMatcher<InputEntity> PlayerInteractListener {
        get {
            if (_matcherPlayerInteractListener == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.PlayerInteractListener);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherPlayerInteractListener = matcher;
            }

            return _matcherPlayerInteractListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public void AddPlayerInteractListener(IPlayerInteractListener value) {
        var listeners = hasPlayerInteractListener
            ? playerInteractListener.value
            : new System.Collections.Generic.List<IPlayerInteractListener>();
        listeners.Add(value);
        ReplacePlayerInteractListener(listeners);
    }

    public void RemovePlayerInteractListener(IPlayerInteractListener value, bool removeComponentWhenEmpty = true) {
        var listeners = playerInteractListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemovePlayerInteractListener();
        } else {
            ReplacePlayerInteractListener(listeners);
        }
    }
}
