using System;

namespace NTC.Source.Code.Ecs
{
    [Serializable]
    public struct PlatformAvailabilityDurationComponent
    {
        public float DelayDuration;
        public float Timer;
        public bool IsDelayFinished;
    }
}