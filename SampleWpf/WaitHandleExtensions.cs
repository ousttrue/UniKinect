using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleWpf
{
    public static class WaitHandleExtensions
    {
        public static Task WaitTask(this WaitHandle handle, int timeoutMs)
        {
            return Task<WaitHandle>.Run(() =>
            {
                if (!handle.WaitOne(timeoutMs))
                {
                    throw new InvalidOperationException("handle is not signal");
                }
            });
        }
    }
}
