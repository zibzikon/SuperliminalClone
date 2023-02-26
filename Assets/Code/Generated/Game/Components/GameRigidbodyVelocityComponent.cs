//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.GamePlay.Components.RigidbodyVelocity rigidbodyVelocity { get { return (Code.GamePlay.Components.RigidbodyVelocity)GetComponent(GameComponentsLookup.RigidbodyVelocity); } }
    public bool hasRigidbodyVelocity { get { return HasComponent(GameComponentsLookup.RigidbodyVelocity); } }

    public void AddRigidbodyVelocity(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.RigidbodyVelocity;
        var component = (Code.GamePlay.Components.RigidbodyVelocity)CreateComponent(index, typeof(Code.GamePlay.Components.RigidbodyVelocity));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceRigidbodyVelocity(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.RigidbodyVelocity;
        var component = (Code.GamePlay.Components.RigidbodyVelocity)CreateComponent(index, typeof(Code.GamePlay.Components.RigidbodyVelocity));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveRigidbodyVelocity() {
        RemoveComponent(GameComponentsLookup.RigidbodyVelocity);
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

    static Entitas.IMatcher<GameEntity> _matcherRigidbodyVelocity;

    public static Entitas.IMatcher<GameEntity> RigidbodyVelocity {
        get {
            if (_matcherRigidbodyVelocity == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RigidbodyVelocity);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRigidbodyVelocity = matcher;
            }

            return _matcherRigidbodyVelocity;
        }
    }
}