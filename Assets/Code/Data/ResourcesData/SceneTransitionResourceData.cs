using System;
using Code.Data.ResourcesData.Enums;
using UnityEngine;

namespace Code.Data.ResourcesData
{
    [Serializable]
    public struct SceneTransitionResourceData 
    {
        [field: SerializeField] public SceneTransitionType TransitionType { get; private set; }
        [field: SerializeField] public string TransitionAssetName { get; private set; }
    }
}