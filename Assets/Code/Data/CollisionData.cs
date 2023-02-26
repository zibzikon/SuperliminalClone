using System;
using UnityEngine;

namespace Code.Data
{
    [Serializable]
    public class CollisionData
    {
        [field: SerializeField] public LayerMask CollisionableLayers;
    }
}