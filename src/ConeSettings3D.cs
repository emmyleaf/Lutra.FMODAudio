// Based on code from ChaiFoxes.FMODAudio
// Released under the Mozilla Public License Version 2.0

namespace Lutra.FMODAudio
{
    public struct ConeSettings3D
    {
        public float InsideConeAngle;
        public float OutsideConeAngle;
        public float OutsideVolume;

        public ConeSettings3D(
            float insideConeAngle,
            float outsideConeAngle,
            float outsideVolume
        )
        {
            InsideConeAngle = insideConeAngle;
            OutsideConeAngle = outsideConeAngle;
            OutsideVolume = outsideVolume;
        }
    }
}
