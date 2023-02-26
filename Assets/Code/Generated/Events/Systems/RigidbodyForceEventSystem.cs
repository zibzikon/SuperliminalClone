//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class RigidbodyForceEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IRigidbodyForceListener> _listenerBuffer;

    public RigidbodyForceEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IRigidbodyForceListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.RigidbodyForce)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasRigidbodyForce && entity.hasRigidbodyForceListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.rigidbodyForce;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.rigidbodyForceListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnRigidbodyForce(e, component.Value);
            }
        }
    }
}