using System;
using UnityEngine;

namespace Code.Data.ResourcesData
{
    [Serializable]
    public struct LevelPreviewResourceData
    {
        [field: SerializeField] public int LevelIndex { get; private set; }

        [field: SerializeField] public string SpriteName { get; private set; }
    }
}