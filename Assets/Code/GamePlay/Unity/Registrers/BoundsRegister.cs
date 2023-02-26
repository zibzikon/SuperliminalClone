using Code.GamePlay.Unity.Behaviours;
using UnityEngine;

namespace Code.GamePlay.Unity.Registrers
{
    public class BoundsRegister : EntityBehaviour
    {
        protected override void OnStart()
        {
            Entity.AddObjectBounds(CalculateBounds());
        }

        private Bounds CalculateBounds()
        {
            var bounds = new Bounds();
            
            foreach (var objectCollider in Controller.Colliders)
                bounds.Encapsulate(objectCollider.bounds);

            return bounds;
        }
    }
}