// This source code was generated by regenerator"
using System;
using System.Runtime.InteropServices;

namespace KinectSDK20 {
    public class IStream: ISequentialStream
    {
        static Guid s_uuid = new Guid("0000000c-0000-0000-c000-000000000046");
        public static new ref Guid IID =>ref s_uuid;
        public override ref Guid GetIID(){ return ref s_uuid; }
                
        public virtual int Seek(
            _LARGE_INTEGER dlibMove,
            uint dwOrigin,
            out _ULARGE_INTEGER plibNewPosition
        ){
            var fp = GetFunctionPointer(5);
            if(m_SeekFunc==null) m_SeekFunc = (SeekFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(SeekFunc));
            
            return m_SeekFunc(m_ptr, dlibMove, dwOrigin, out plibNewPosition);
        }
        delegate int SeekFunc(IntPtr self, _LARGE_INTEGER dlibMove, uint dwOrigin, out _ULARGE_INTEGER plibNewPosition);
        SeekFunc m_SeekFunc;

        public virtual int SetSize(
            _ULARGE_INTEGER libNewSize
        ){
            var fp = GetFunctionPointer(6);
            if(m_SetSizeFunc==null) m_SetSizeFunc = (SetSizeFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(SetSizeFunc));
            
            return m_SetSizeFunc(m_ptr, libNewSize);
        }
        delegate int SetSizeFunc(IntPtr self, _ULARGE_INTEGER libNewSize);
        SetSizeFunc m_SetSizeFunc;

        public virtual int CopyTo(
            IStream pstm,
            _ULARGE_INTEGER cb,
            out _ULARGE_INTEGER pcbRead,
            out _ULARGE_INTEGER pcbWritten
        ){
            var fp = GetFunctionPointer(7);
            if(m_CopyToFunc==null) m_CopyToFunc = (CopyToFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(CopyToFunc));
            
            return m_CopyToFunc(m_ptr, pstm!=null ? pstm.Ptr : IntPtr.Zero, cb, out pcbRead, out pcbWritten);
        }
        delegate int CopyToFunc(IntPtr self, IntPtr pstm, _ULARGE_INTEGER cb, out _ULARGE_INTEGER pcbRead, out _ULARGE_INTEGER pcbWritten);
        CopyToFunc m_CopyToFunc;

        public virtual int Commit(
            uint grfCommitFlags
        ){
            var fp = GetFunctionPointer(8);
            if(m_CommitFunc==null) m_CommitFunc = (CommitFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(CommitFunc));
            
            return m_CommitFunc(m_ptr, grfCommitFlags);
        }
        delegate int CommitFunc(IntPtr self, uint grfCommitFlags);
        CommitFunc m_CommitFunc;

        public virtual int Revert(
        ){
            var fp = GetFunctionPointer(9);
            if(m_RevertFunc==null) m_RevertFunc = (RevertFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(RevertFunc));
            
            return m_RevertFunc(m_ptr);
        }
        delegate int RevertFunc(IntPtr self);
        RevertFunc m_RevertFunc;

        public virtual int LockRegion(
            _ULARGE_INTEGER libOffset,
            _ULARGE_INTEGER cb,
            uint dwLockType
        ){
            var fp = GetFunctionPointer(10);
            if(m_LockRegionFunc==null) m_LockRegionFunc = (LockRegionFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(LockRegionFunc));
            
            return m_LockRegionFunc(m_ptr, libOffset, cb, dwLockType);
        }
        delegate int LockRegionFunc(IntPtr self, _ULARGE_INTEGER libOffset, _ULARGE_INTEGER cb, uint dwLockType);
        LockRegionFunc m_LockRegionFunc;

        public virtual int UnlockRegion(
            _ULARGE_INTEGER libOffset,
            _ULARGE_INTEGER cb,
            uint dwLockType
        ){
            var fp = GetFunctionPointer(11);
            if(m_UnlockRegionFunc==null) m_UnlockRegionFunc = (UnlockRegionFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(UnlockRegionFunc));
            
            return m_UnlockRegionFunc(m_ptr, libOffset, cb, dwLockType);
        }
        delegate int UnlockRegionFunc(IntPtr self, _ULARGE_INTEGER libOffset, _ULARGE_INTEGER cb, uint dwLockType);
        UnlockRegionFunc m_UnlockRegionFunc;

        public virtual int Stat(
            out tagSTATSTG pstatstg,
            uint grfStatFlag
        ){
            var fp = GetFunctionPointer(12);
            if(m_StatFunc==null) m_StatFunc = (StatFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(StatFunc));
            
            return m_StatFunc(m_ptr, out pstatstg, grfStatFlag);
        }
        delegate int StatFunc(IntPtr self, out tagSTATSTG pstatstg, uint grfStatFlag);
        StatFunc m_StatFunc;

        public virtual int Clone(
            out IStream ppstm
        ){
            var fp = GetFunctionPointer(13);
            if(m_CloneFunc==null) m_CloneFunc = (CloneFunc)Marshal.GetDelegateForFunctionPointer(fp, typeof(CloneFunc));
            ppstm = new IStream();
            return m_CloneFunc(m_ptr, out ppstm.PtrForNew);
        }
        delegate int CloneFunc(IntPtr self, out IntPtr ppstm);
        CloneFunc m_CloneFunc;

    }
}
