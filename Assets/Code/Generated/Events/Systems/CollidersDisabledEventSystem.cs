//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class CollidersDisabledEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<ICollidersDisabledListener> _listenerBuffer;

    public CollidersDisabledEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<ICollidersDisabledListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.CollidersDisabled)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.isCollidersDisabled && entity.hasCollidersDisabledListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.collidersDisabledListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnCollidersDisabled(e);
            }
        }
    }
}
