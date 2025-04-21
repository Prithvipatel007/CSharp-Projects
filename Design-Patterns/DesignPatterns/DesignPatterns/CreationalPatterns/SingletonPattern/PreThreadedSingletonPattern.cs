using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns.SingletonPattern
{
    public sealed class PerThreadSingleton
    {
        // Provides one singleton instance per thread
        private static ThreadLocal<PerThreadSingleton> threadInstane = new ThreadLocal<PerThreadSingleton>(
                () => new PerThreadSingleton()
            );

        public int Id;

        private PerThreadSingleton()
        {
            Id = Thread.CurrentThread.ManagedThreadId;
        }

        public static PerThreadSingleton Instance => threadInstane.Value;

    }

}


