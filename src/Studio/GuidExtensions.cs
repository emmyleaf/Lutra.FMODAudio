using System;

namespace Lutra.FMODAudio.Studio;

public static class GuidExtensions
{
    public static Guid ToSystemGuid(this FMOD.GUID fmodGuid)
    {
        byte[] bytes = new byte[16];
        BitConverter.GetBytes(fmodGuid.Data1).CopyTo(bytes, 0);
        BitConverter.GetBytes(fmodGuid.Data2).CopyTo(bytes, 4);
        BitConverter.GetBytes(fmodGuid.Data3).CopyTo(bytes, 8);
        BitConverter.GetBytes(fmodGuid.Data4).CopyTo(bytes, 12);
        return new Guid(bytes);
    }

    public static FMOD.GUID ToFmodGuid(this Guid systemGuid)
    {
        byte[] bytes = systemGuid.ToByteArray();
        return new FMOD.GUID()
        {
            Data1 = BitConverter.ToInt32(bytes, 0),
            Data2 = BitConverter.ToInt32(bytes, 4),
            Data3 = BitConverter.ToInt32(bytes, 8),
            Data4 = BitConverter.ToInt32(bytes, 12)
        };
    }
}
