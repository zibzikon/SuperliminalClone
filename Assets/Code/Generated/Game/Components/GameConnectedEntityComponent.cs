//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.GamePlay.Components.ConnectedEntity connectedEntity { get { return (Code.GamePlay.Components.ConnectedEntity)GetComponent(GameComponentsLookup.ConnectedEntity); } }
    public bool hasConnectedEntity { get { return HasComponent(GameComponentsLookup.ConnectedEntity); } }

    public void AddConnectedEntity(GameEntity newValue) {
        var index = GameComponentsLookup.ConnectedEntity;
        var component = (Code.GamePlay.Components.ConnectedEntity)CreateComponent(index, typeof(Code.GamePlay.Components.ConnectedEntity));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceConnectedEntity(GameEntity newValue) {
        var index = GameComponentsLookup.ConnectedEntity;
        var component = (Code.GamePlay.Components.ConnectedEntity)CreateComponent(index, typeof(Code.GamePlay.Components.ConnectedEntity));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveConnectedEntity() {
        RemoveComponent(GameComponentsLookup.ConnectedEntity);
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

    static Entitas.IMatcher<GameEntity> _matcherConnectedEntity;

    public static Entitas.IMatcher<GameEntity> ConnectedEntity {
        get {
            if (_matcherConnectedEntity == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ConnectedEntity);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherConnectedEntity = matcher;
            }

            return _matcherConnectedEntity;
        }
    }
}