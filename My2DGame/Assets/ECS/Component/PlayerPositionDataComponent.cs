using System;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    [Serializable]
    public struct PlayerPositionDataComponent
    {
        public Transform transform;
        public PlayerPositionData playerPositionData;
    }
}