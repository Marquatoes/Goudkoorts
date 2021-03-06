﻿using System;

namespace Goudkoorts
{
    public static class RandomNumber
    {
        private static readonly Random Global = new Random();
        [ThreadStatic] private static Random _local;

        public static int Next(int max)
        {
            var localBuffer = _local;
            if (localBuffer == null)
            {
                int seed;
                lock (Global) seed = Global.Next();
                localBuffer = new Random(seed);
                _local = localBuffer;
            }
            return localBuffer.Next(max);
        }
    }
}
