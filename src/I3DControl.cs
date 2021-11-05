﻿// Based on code from ChaiFoxes.FMODAudio
// Released under the Mozilla Public License Version 2.0

using System.Numerics;

namespace Lutra.FMODAudio
{
    public interface I3DControl
    {
        /// <summary>
        /// Sound's position in 3D space. Can be used only if 3D positioning is enabled.
        /// </summary>
        Vector3 Position3D { get; set; }

        /// <summary>
        /// Sound's velocity in 3D space. Can be used only if 3D positioning is enabled.
        /// </summary>
        Vector3 Velocity3D { get; set; }

        float MinDistance3D { get; set; }
        float MaxDistance3D { get; set; }

        ConeSettings3D ConeSettings3D { get; set; }
    }
}
