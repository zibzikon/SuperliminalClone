using UnityEngine;

namespace Code.Domain.Data.Static
{
    [CreateAssetMenu(fileName = "GameStaticData", menuName = "Data/Static/GameStaticData")]
    public class GameStaticData : ScriptableObject
    {
        [field: SerializeField] public string MainMenuSceneName { get; private set; }
        [field: SerializeField] public string MainMenuPrefabName { get; private set; }
    }
}