using System;

namespace NTC.Source.Code.Ecs
{
    [Serializable]
    public struct MultiJumpComponent
    {
        public sbyte jumpCount, saveJumpCount;
    }
}