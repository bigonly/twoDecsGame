using System;

namespace NTC.Source.Code.Ecs
{
    [Serializable]
    public struct PlatformAvailabilityDuration
    {
        public float DelayDuration;
        public float Timer;
        public bool IsDelayFinished;
    }
}