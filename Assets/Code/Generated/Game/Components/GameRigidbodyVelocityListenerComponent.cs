//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public RigidbodyVelocityListenerComponent rigidbodyVelocityListener { get { return (RigidbodyVelocityListenerComponent)GetComponent(GameComponentsLookup.RigidbodyVelocityListener); } }
    public bool hasRigidbodyVelocityListener { get { return HasComponent(GameComponentsLookup.RigidbodyVelocityListener); } }

    public void AddRigidbodyVelocityListener(System.Collections.Generic.List<IRigidbodyVelocityListener> newValue) {
        var index = GameComponentsLookup.RigidbodyVelocityListener;
        var component = (RigidbodyVelocityListenerComponent)CreateComponent(index, typeof(RigidbodyVelocityListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceRigidbodyVelocityListener(System.Collections.Generic.List<IRigidbodyVelocityListener> newValue) {
        var index = GameComponentsLookup.RigidbodyVelocityListener;
        var component = (RigidbodyVelocityListenerComponent)CreateComponent(index, typeof(RigidbodyVelocityListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveRigidbodyVelocityListener() {
        RemoveComponent(GameComponentsLookup.RigidbodyVelocityListener);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRigidbodyVelocityListener;

    public static Entitas.IMatcher<GameEntity> RigidbodyVelocityListener {
        get {
            if (_matcherRigidbodyVelocityListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RigidbodyVelocityListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRigidbodyVelocityListener = matcher;
            }

            return _matcherRigidbodyVelocityListener;
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
public partial class GameEntity {

    public void AddRigidbodyVelocityListener(IRigidbodyVelocityListener value) {
        var listeners = hasRigidbodyVelocityListener
            ? rigidbodyVelocityListener.value
            : new System.Collections.Generic.List<IRigidbodyVelocityListener>();
        listeners.Add(value);
        ReplaceRigidbodyVelocityListener(listeners);
    }

    public void RemoveRigidbodyVelocityListener(IRigidbodyVelocityListener value, bool removeComponentWhenEmpty = true) {
        var listeners = rigidbodyVelocityListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveRigidbodyVelocityListener();
        } else {
            ReplaceRigidbodyVelocityListener(listeners);
        }
    }
}