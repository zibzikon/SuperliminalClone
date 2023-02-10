using UnityEngine;

namespace Code.Data.ResourcesData
{
    [CreateAssetMenu(fileName = "GameResourcesData", menuName = "Data/Game")]
    public class GameResourcesData : ScriptableObject
    {
        [field: SerializeField] public string MainMenuSceneName { get; private set; }
        [field: SerializeField] public string MainMenuPrefabName { get; private set; }
    }
}