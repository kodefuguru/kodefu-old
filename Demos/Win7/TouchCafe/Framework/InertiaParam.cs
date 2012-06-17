namespace TouchCafe.Framework
{
    using Windows7.Multitouch.Manipulation;

    class InertiaParam
    {
        public VectorF InitialVelocity { get; set; }
        public float InitialAngularVelocity { get; set; }
        public float InitialExpansionVelocity { get; set; }
        public System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        public void Reset()
        {
            InitialVelocity = new VectorF(0, 0);
            InitialAngularVelocity = 0;
            InitialExpansionVelocity = 0;
            stopwatch.Reset();
            stopwatch.Start();
        }
        public void Stop()
        {
            stopwatch.Stop();
        }
        //update velocities, velocity = distance/time
        public void Update(ManipulationDeltaEventArgs e, float history)
        {
            float elappsedMS = stopwatch.ElapsedMilliseconds;
            if (elappsedMS == 0)
                elappsedMS = 1;
            InitialVelocity = InitialVelocity * history + ((VectorF)e.TranslationDelta * (1F - history)) / elappsedMS;
            InitialAngularVelocity = InitialAngularVelocity * history + (e.RotationDelta * (1F - history)) / elappsedMS;
            InitialExpansionVelocity = InitialExpansionVelocity * history + (e.ExpansionDelta * (1F - history)) / elappsedMS;
            stopwatch.Reset();
            stopwatch.Start();
        }

    }
}
