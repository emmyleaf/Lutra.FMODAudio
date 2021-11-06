﻿// Based on code from ChaiFoxes.FMODAudio
// Released under the Mozilla Public License Version 2.0

using System;
using Lutra.FMODAudio.Studio;

namespace Lutra.FMODAudio
{
    public enum FMODMode
    {
        Core,
        CoreAndStudio
    }

    public static class FMODManager
    {
        /// <summary>
        /// This is the FMOD version which was tested on this version of the library. 
        /// Other versions may work, but this is not guaranteed.
        /// Visit https://fmod.com/download
        /// </summary>
        public const string RecommendedNativeLibraryVersion = "2.02.03";

        private static FMODMode _mode;

        internal static bool _initialized { get; private set; } = false;

        public static bool UsesStudio =>
            _mode == FMODMode.CoreAndStudio;

        /// <summary>
        /// Initializes systems and loads the native libraries. Can only be called once. 
        /// </summary>
        /// <param name="preInitAction">Executes before initialization, but after the native instance creation.</param>
        public static void Init(
            FMODMode mode,
            int maxChannels = 256,
            uint dspBufferLength = 4,
            int dspBufferCount = 32,
            FMOD.INITFLAGS coreInitFlags = FMOD.INITFLAGS.CHANNEL_LOWPASS | FMOD.INITFLAGS.CHANNEL_DISTANCEFILTER,
            FMOD.Studio.INITFLAGS studioInitFlags = FMOD.Studio.INITFLAGS.NORMAL,
            Action preInitAction = null
        )
        {
            if (_initialized)
            {
                throw new Exception("Manager is already initialized!");
            }
            _initialized = true;
            _mode = mode;

            FMODDllResolver.Register();
            FMODDllResolver.Preload("fmod");

            if (UsesStudio)
            {
                FMODDllResolver.Preload("fmodstudio");

                FMOD.Studio.System.create(out StudioSystem.Native);

                StudioSystem.Native.getCoreSystem(out CoreSystem.Native);

                preInitAction?.Invoke();

                // This also will init core system.
                StudioSystem.Native.initialize(maxChannels, studioInitFlags, coreInitFlags, (IntPtr)0);
            }
            else
            {
                FMOD.Factory.System_Create(out CoreSystem.Native);

                preInitAction?.Invoke();

                CoreSystem.Native.init(maxChannels, coreInitFlags, (IntPtr)0);
            }

            // Too high values will cause sound lag.
            CoreSystem.Native.setDSPBufferSize(dspBufferLength, dspBufferCount);
        }

        public static void Update()
        {
            CheckInitialized();
            if (UsesStudio)
            {
                // This also will update core system.
                StudioSystem.Native.update();
            }
            else
            {
                CoreSystem.Native.update();
            }
        }

        public static void Unload()
        {
            CheckInitialized();
            if (UsesStudio)
            {
                StudioSystem.Native.release();
            }
            else
            {
                CoreSystem.Native.release();
            }
        }

        private static void CheckInitialized()
        {
            if (!_initialized)
            {
                throw new Exception("You need to call Init() before calling this method!");
            }
        }
    }
}
