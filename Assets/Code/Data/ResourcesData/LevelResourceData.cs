using System;
using UnityEngine;

namespace Code.Data.ResourcesData
{
    [CreateAssetMenu(fileName = "LevelResourceData", menuName = "Data/Level")]
    public class LevelResourceData : ScriptableObject
    {
        [field: SerializeField] public int Index { get; private set; }
        [field: SerializeField] public string SceneName { get; private set; }
    }
}