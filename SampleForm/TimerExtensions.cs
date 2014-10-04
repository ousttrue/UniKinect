using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Forms
{
    public static class TimerExtensions
    {
        public static IObservable<EventArgs> TimerTickAsObservable(this Timer timer)
        {
            return Observable.FromEventPattern<EventHandler, EventArgs>(
                h => h.Invoke,
                h => timer.Tick += h, h => timer.Tick -= h)
              .Select(x => x.EventArgs);
        }
    }
}
