//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public KinematicRemovedListenerComponent kinematicRemovedListener { get { return (KinematicRemovedListenerComponent)GetComponent(GameComponentsLookup.KinematicRemovedListener); } }
    public bool hasKinematicRemovedListener { get { return HasComponent(GameComponentsLookup.KinematicRemovedListener); } }

    public void AddKinematicRemovedListener(System.Collections.Generic.List<IKinematicRemovedListener> newValue) {
        var index = GameComponentsLookup.KinematicRemovedListener;
        var component = (KinematicRemovedListenerComponent)CreateComponent(index, typeof(KinematicRemovedListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceKinematicRemovedListener(System.Collections.Generic.List<IKinematicRemovedListener> newValue) {
        var index = GameComponentsLookup.KinematicRemovedListener;
        var component = (KinematicRemovedListenerComponent)CreateComponent(index, typeof(KinematicRemovedListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveKinematicRemovedListener() {
        RemoveComponent(GameComponentsLookup.KinematicRemovedListener);
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

    static Entitas.IMatcher<GameEntity> _matcherKinematicRemovedListener;

    public static Entitas.IMatcher<GameEntity> KinematicRemovedListener {
        get {
            if (_matcherKinematicRemovedListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.KinematicRemovedListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherKinematicRemovedListener = matcher;
            }

            return _matcherKinematicRemovedListener;
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

    public void AddKinematicRemovedListener(IKinematicRemovedListener value) {
        var listeners = hasKinematicRemovedListener
            ? kinematicRemovedListener.value
            : new System.Collections.Generic.List<IKinematicRemovedListener>();
        listeners.Add(value);
        ReplaceKinematicRemovedListener(listeners);
    }

    public void RemoveKinematicRemovedListener(IKinematicRemovedListener value, bool removeComponentWhenEmpty = true) {
        var listeners = kinematicRemovedListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveKinematicRemovedListener();
        } else {
            ReplaceKinematicRemovedListener(listeners);
        }
    }
}
