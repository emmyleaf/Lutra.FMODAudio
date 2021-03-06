// Based on code from ChaiFoxes.FMODAudio
// Released under the Mozilla Public License Version 2.0

using System.Numerics;

namespace Lutra.FMODAudio
{
    /// <summary>
    /// Extensions for conversion between FMOD.VECTOR and System.Numerics Vectors.
    /// </summary>
    public static class VectorExtensions
    {
        public static FMOD.VECTOR ToFmodVector(this Vector3 v)
        {
            return new FMOD.VECTOR
            {
                x = v.X,
                y = v.Y,
                z = v.Z
            };
        }

        public static FMOD.VECTOR ToFmodVector(this Vector2 v)
        {
            return new FMOD.VECTOR
            {
                x = v.X,
                y = v.Y,
                z = 0
            };
        }

        public static Vector3 ToVector3(this FMOD.VECTOR v)
        {
            return new Vector3(v.x, v.y, v.z);
        }

        public static Vector2 ToVector2(this FMOD.VECTOR v)
        {
            return new Vector2(v.x, v.y);
        }
    }
}
