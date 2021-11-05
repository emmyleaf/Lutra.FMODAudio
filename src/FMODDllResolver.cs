using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Lutra.FMODAudio
{
    internal static class FMODDllResolver
    {
        internal static void Register()
        {
            NativeLibrary.SetDllImportResolver(typeof(FMODManager).Assembly, MapAndLoad);
        }

        private static IntPtr MapAndLoad(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            string mappedName = libraryName;

            if (mappedName == FMOD.VERSION.dll || mappedName == FMOD.Studio.STUDIO_VERSION.dll)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    mappedName = $"lib{mappedName}.so";
                }

                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    mappedName = $"lib{mappedName}.dylib";
                }

                // Join path with arch directory name
                if (RuntimeInformation.OSArchitecture == Architecture.X64)
                {
                    mappedName = Path.Join("lib/x64/", mappedName);
                }

                if (RuntimeInformation.OSArchitecture == Architecture.X86)
                {
                    mappedName = Path.Join("lib/x86/", mappedName);
                }
            }

            return NativeLibrary.Load(mappedName, assembly, searchPath);
        }
    }
}
