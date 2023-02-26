using Code.GamePlay.Interfaces;
using UnityEngine;

namespace Code.GamePlay.Unity.Registrers
{
    public class TransformationsRegister : MonoBehaviour, IViewComponentRegister
    {
        public void Register(GameEntity entity)
        {
            entity.AddPosition(transform.position);
            entity.AddRotation(transform.rotation.eulerAngles);
            entity.AddScale(transform.localScale);
            entity.AddTransform(transform);
        }
    }
} 