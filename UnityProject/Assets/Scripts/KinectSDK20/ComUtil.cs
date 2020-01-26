// This source code was generated by regenerator"
using System;
using System.Runtime.InteropServices;

using System.Text;

namespace KinectSDK20
{
    public static class ComPtrExtensions
    {
        public static T QueryInterface<T>(this IUnknown self) where T : ComPtr, new()
        {
            var p = new T();
            if (self.QueryInterface(ref p.GetIID(), out p.PtrForNew).Failed())
            {
                return null;
            }
            return p;
        }
    }

    /// <summary>
    /// COMの virtual function table を自前で呼び出すヘルパークラス。
    /// </summary>
    public abstract class ComPtr : IDisposable
    {
        static Guid s_uuid;
        public static ref Guid IID => ref s_uuid;
        public virtual ref Guid GetIID(){ return ref s_uuid; }
 
        /// <summay>
        /// IUnknown を継承した interface(ID3D11Deviceなど) に対するポインター。
        /// このポインターの指す領域の先頭に virtual function table へのポインタが格納されている。
        /// <summay>
        protected IntPtr m_ptr;

        public ref IntPtr PtrForNew
        {
            get
            {
                if (m_ptr != IntPtr.Zero)
                {
                    Marshal.Release(m_ptr);
                }
                return ref m_ptr;
            }
        }

        public ref IntPtr Ptr => ref m_ptr;

        public static implicit operator bool(ComPtr i)
        {
            if (i is null) return false;
            return i.m_ptr != IntPtr.Zero;
        }

        IntPtr VTable => Marshal.ReadIntPtr(m_ptr);

        static readonly int IntPtrSize = Marshal.SizeOf(typeof(IntPtr));

        protected IntPtr GetFunctionPointer(int index)
        {
            return Marshal.ReadIntPtr(VTable, index * IntPtrSize);
        }

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージ状態を破棄します (マネージ オブジェクト)。
                }

                // TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
                // TODO: 大きなフィールドを null に設定します。
                if (m_ptr != IntPtr.Zero)
                {
                    Marshal.Release(m_ptr);
                    m_ptr = IntPtr.Zero;
                }

                disposedValue = true;
            }
        }

        ~ComPtr()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(false);
        }

        // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(true);
            // TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    class CustomMarshaler<T> : ICustomMarshaler
    where T : ComPtr, new()
    {
        public void CleanUpManagedData(object ManagedObj)
        {
            throw new NotImplementedException();
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
            // throw new NotImplementedException();
        }

        public int GetNativeDataSize()
        {
            throw new NotImplementedException();
        }

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            throw new NotImplementedException();
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            // var count = Marshal.AddRef(pNativeData);
            // Marshal.Release(pNativeData);
            var t = new T();
            t.PtrForNew = pNativeData;
            return t;
        }

        public static ICustomMarshaler GetInstance(string src)
        {
            return new CustomMarshaler<T>();
        }
    }

    public static class WindowsAPIExtensions
    {
        public static short HIWORD(this ulong _dw)
        {
            return ((short)((_dw >> 16) & 0xffff));
        }

        public static short LOWORD(this ulong _dw)
        {
            return ((short)(_dw & 0xffff));
        }

        public static short HIWORD(this long _dw)
        {
            return ((short)((_dw >> 16) & 0xffff));
        }

        public static short LOWORD(this long _dw)
        {
            return ((short)(_dw & 0xffff));
        }

        [ThreadStatic]
        static IntPtr ts_ptr = Marshal.AllocHGlobal(4);

        public static IntPtr Ptr(this int value)
        {
            Marshal.WriteInt32(ts_ptr, value);
            return ts_ptr;
        }

        public static IntPtr Ptr(this string src)
        {
            IntPtr strPtr = Marshal.StringToHGlobalUni(src);
            try
            {
                return strPtr;
            }
            finally
            {
                Marshal.FreeHGlobal(strPtr);
            }
        }

        public static void ThrowIfFailed(this int hr)
        {
            if (hr != 0)
            {
                var ex = new ComException(hr);
                throw ex;
            }
        }

        public static bool Succeeded(this int hr) => hr == 0;

        public static bool Failed(this int hr) => hr != 0;

        public static WSTR ToMutableString(this ushort[] src)
        {
            return new WSTR(src);
        }
    }

    public class ComException : Exception
    {
        public readonly int HR;
 
        public ComException(int hr)
        {
            HR = hr;
        }
    }

    public struct WSTR
    {
        // zero terminated
        public byte[] Buffer;

        public int Length => Buffer.Length-2;

        public ref ushort Data
        {
            get
            {
                return ref MemoryMarshal.Cast<byte, ushort>(Buffer.AsSpan())[0];
            }
        }

        public WSTR(string src)
        {
            Buffer = Encoding.Unicode.GetBytes(src + "\0");
        }

        public WSTR(ushort[] src)
        {
            var end = Array.IndexOf<ushort>(src, 0, 0);
            if (end == -1)
            {
                end = src.Length;
            }
            var span = MemoryMarshal.Cast<ushort, byte>(src.AsSpan().Slice(0, end));
            Buffer = new byte[end * 2 + 2];
            span.CopyTo(Buffer.AsSpan());
        }

        public override string ToString()
        {
            return Encoding.Unicode.GetString(Buffer, 0, Buffer.Length - 2);
        }
    }

    public struct STR
    {
        // zero terminated
        public byte[] Buffer;

        static readonly Encoding s_utf8 = new UTF8Encoding(false);

        public STR(string src)
        {
            Buffer = s_utf8.GetBytes(src + "\0");
        }

        public STR(byte[] src)
        {
            var end = Array.IndexOf<byte>(src, 0, 0);
            if (end == -1)
            {
                end = src.Length;
            }
            Buffer = new byte[end * 2 + 2];
            src.AsSpan().CopyTo(Buffer.AsSpan());
        }

        public override string ToString()
        {
            return s_utf8.GetString(Buffer, 0, Buffer.Length - 2);
        }
    }    
}
