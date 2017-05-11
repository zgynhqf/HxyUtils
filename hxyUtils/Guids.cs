// Guids.cs
// MUST match guids.h
using System;

namespace hxyUtils
{
    static class GuidList
    {
        public const string guidhxyUtilsPkgString = "10f23e66-4203-49c1-8a50-cc2358372e49";
        public const string guidhxyUtilsCmdSetString = "23148ab5-fd14-4ebe-806d-959c92bbbdcf";

        public static readonly Guid guidhxyUtilsCmdSet = new Guid(guidhxyUtilsCmdSetString);
    };
}