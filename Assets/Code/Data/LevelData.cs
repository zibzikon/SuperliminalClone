using System;
using UnityEngine;

namespace Code.Domain
{
    [Serializable]
    public struct LevelData 
    {
        [field: SerializeField] public string SceneName { get; private set; }
        [field: SerializeField] public int Index { get; private set; }
        [field: SerializeField] public LevelState State { get; set; }
    }
}