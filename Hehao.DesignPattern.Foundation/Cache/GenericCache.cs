﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation.Cache
{
    public class GenericCache<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        /// <summary>
        /// 用于并发同步访问的RW锁对象
        /// </summary>
        private ReaderWriterLock rwLock = new ReaderWriterLock();

        private readonly TimeSpan lockTimeOut = TimeSpan.FromMilliseconds(100);

        public void Add(TKey key, TValue value)
        {
            bool isExisting = false;
            rwLock.AcquireWriterLock(lockTimeOut);
            try
            {
                if (!dictionary.ContainsKey(key))
                {
                    dictionary.Add(key, value);
                }
                else
                {
                    isExisting = true;
                }
            }
            finally
            {
                rwLock.ReleaseWriterLock();
            }
            if (isExisting)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            rwLock.AcquireReaderLock(lockTimeOut);
            bool result;
            try
            {
                result = dictionary.TryGetValue(key, out value);
            }
            finally
            {
                rwLock.ReleaseReaderLock();
            }

            return result;
        }

        public void Clear()
        {
            if (dictionary.Count > 0)
            {
                rwLock.AcquireWriterLock(lockTimeOut);
                try
                {
                    dictionary.Clear();
                }
                finally
                {
                    rwLock.ReleaseWriterLock();
                }
            }
        }

        public bool ContainsKey(TKey key)
        {
            if (dictionary.Count <= 0) return false;

            bool result;
            rwLock.AcquireReaderLock(lockTimeOut);
            try
            {
                result = dictionary.ContainsKey(key);
            }
            finally
            {
                rwLock.ReleaseReaderLock();
            }
            return result;
        }

        public int Count
        {
            get
            {
                return dictionary.Count;
            }
        }
    }
}
