namespace TouchCafe
{
    using System.Runtime.InteropServices;

    public static class DigitizerCapabilities
    {
        public static DigitizerStatus Status
        {
            get
            {
                return (DigitizerStatus)GetDigitizerCapabilities(DigitizerIndex.SM_DIGITIZER);
            }
        }

        public static bool IsMultiTouchReady
        {
            get
            {
                return (DigitizerCapabilities.Status & (DigitizerStatus.MultiInput | DigitizerStatus.StackReady)) != 0;
            }
        }

        [DllImport("user32", EntryPoint = "GetSystemMetrics")]
        public static extern int GetDigitizerCapabilities(DigitizerIndex index);
    }


}
