namespace TouchCafe
{
    using System;

    [Flags]
    public enum DigitizerStatus : byte
    {
        IntegratedTouch = 1,
        ExternalTouch = 2,
        IntegratedPan = 4,
        ExternalPan = 8,
        MultiInput = 64,
        StackReady = 128
    }
}
