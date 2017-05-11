// PkgCmdID.cs
// MUST match PkgCmdID.h
using System;

namespace hxyUtils
{
    static class PkgCmdIDList
    {
        public const int cmdidAddFileHeaderCommand = 0x100;

        public const int cmdidCreateDependencyCommand = 0x101;
        public const int cmdidDropDependencyCommand = 0x102;
        public const int cmdidFastAttachProcessCommand = 0x103;
        public const int cmdidSetFastAttachProcessNameCommand = 0x104;
        public const int cmdidOpenDebugDirCommand = 0x105;
        public const int cmdidAddProjectVersionCommand = 0x106;
    };
}