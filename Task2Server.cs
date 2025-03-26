using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Cleverence
{
    public static class Task2Server
    {
        private static int _count = 0;
        private static ReaderWriterLockSlim _lockSlim;

        public static int GetCount()
        {
            _lockSlim.EnterReadLock();
            try
            {
                return _count;
            }
            finally
            {
                _lockSlim.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            _lockSlim.EnterWriteLock();

            try
            {
                _count += value;
            }
            finally
            {
                _lockSlim.ExitWriteLock();
            }
        }

        public static void InitServer()
        {
            _lockSlim = new ReaderWriterLockSlim();
        }

        public static void DisposeServer()
        {
            _count = 0;
            _lockSlim.Dispose();
        }
    }
}
