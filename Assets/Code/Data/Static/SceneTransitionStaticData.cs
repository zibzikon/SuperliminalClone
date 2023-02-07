using Code.Domain.Data.Static;
using UnityEngine;

namespace Code.Data.Static
{
    [CreateAssetMenu(fileName = "SceneChangingTransition", menuName = "Data/Static/SceneChangingTransition")]
    public class SceneTransitionStaticData : ScriptableObject
    {
        [field: SerializeField] public SceneTransitionType TransitionType { get; private set; }
        [field: SerializeField] public string TransitionAssetName { get; private set; }
    }
}