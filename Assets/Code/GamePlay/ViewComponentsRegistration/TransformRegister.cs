using Code.GamePlay.Interfaces;
using UnityEngine;

namespace Code.GamePlay.ViewComponentsRegistration
{
    public class TransformRegister : MonoBehaviour, IViewComponentRegister
    {
        public void Register(GameEntity entity)
            => entity.AddTransform(transform);
    }
} 