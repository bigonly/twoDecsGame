using System;

namespace NTC.Source.Code.Ecs
{
    [Serializable]
    public struct LimitFPSComponent
    {
        public int targetFPS;
    }
}