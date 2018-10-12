using UnityEngine;
using System.Collections;

namespace BW.MathUtil {

    /// <summary>
    /// 伪随机数发生器,module 2^32
    /// </summary>
    public class PseudoRandom {

        // https://en.wikipedia.org/wiki/Linear_congruential_generator

        readonly ulong a = 6364136223846793005;
        readonly ulong c = 1442695040888963407;

        public ulong seed;

        public ulong state;
        public uint count;

        public PseudoRandom(ulong seed) {
            this.seed = seed;
            count = 0;
            state = seed;
        }

        /// <summary>
        /// seed值
        /// </summary>
        public ulong Next() {
            unchecked {state = state * a + c;}
            return (ulong)state;
        }

        /// <summary>
        /// next value in [0,1)
        /// </summary>
        public double value {
            get {
                Next();
                return (double)state / double.MaxValue;
            }
        }

        /// <summary>
        /// [a,b)之间的一个值(不可能等于b)
        /// </summary>
        public long Range(long a, long b = 0) {
            return (long)(a + (b - a) * value);
        }




    }




}