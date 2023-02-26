using Code.GamePlay.Interfaces;
using UnityEngine;

namespace Code.GamePlay.Unity.ViewListeners
{
    public class ScaleListener: MonoBehaviour, IEventListener, IScaleListener
    {
        public void Register(GameEntity entity) => entity.AddScaleListener(this);

        public void Unregister(GameEntity entity) => entity.RemoveScaleListener(this);

        public void OnScale(GameEntity entity, Vector3 value) => transform.localScale = value;
    }
}