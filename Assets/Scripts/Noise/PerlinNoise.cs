using System;

/// <summary>
/// 增强的数学库
/// </summary>
namespace BW.MathUtil {
    /// <summary>
    /// 改进的柏林噪声
    /// https://mrl.nyu.edu/~perlin/noise/
    /// </summary>
    public class PerlinNoise : INoise {

        /// <summary>
        /// 随机序列
        /// </summary>
        private readonly int[] p = new int[512];

        /// <summary>
        /// Seed 为0时用这个做随机数据序列源
        /// </summary>
        static short[] permutation = {
            151, 160, 137, 91, 90, 15,
            131, 13, 201, 95, 96, 53, 194, 233, 7, 225, 140, 36, 103, 30, 69, 142, 8, 99, 37, 240, 21, 10, 23,
            190, 6, 148, 247, 120, 234, 75, 0, 26, 197, 62, 94, 252, 219, 203, 117, 35, 11, 32, 57, 177, 33,
            88, 237, 149, 56, 87, 174, 20, 125, 136, 171, 168, 68, 175, 74, 165, 71, 134, 139, 48, 27, 166,
            77, 146, 158, 231, 83, 111, 229, 122, 60, 211, 133, 230, 220, 105, 92, 41, 55, 46, 245, 40, 244,
            102, 143, 54, 65, 25, 63, 161, 1, 216, 80, 73, 209, 76, 132, 187, 208, 89, 18, 169, 200, 196,
            135, 130, 116, 188, 159, 86, 164, 100, 109, 198, 173, 186, 3, 64, 52, 217, 226, 250, 124, 123,
            5, 202, 38, 147, 118, 126, 255, 82, 85, 212, 207, 206, 59, 227, 47, 16, 58, 17, 182, 189, 28, 42,
            223, 183, 170, 213, 119, 248, 152, 2, 44, 154, 163, 70, 221, 153, 101, 155, 167, 43, 172, 9,
            129, 22, 39, 253, 19, 98, 108, 110, 79, 113, 224, 232, 178, 185, 112, 104, 218, 246, 97, 228,
            251, 34, 242, 193, 238, 210, 144, 12, 191, 179, 162, 241, 81, 51, 145, 235, 249, 14, 239, 107,
            49, 192, 214, 31, 181, 199, 106, 157, 184, 84, 204, 176, 115, 121, 50, 45, 127, 4, 150, 254,
            138, 236, 205, 93, 222, 114, 67, 29, 24, 72, 243, 141, 128, 195, 78, 66, 215, 61, 156, 180
        };

        public PerlinNoise(ulong seed = 0) {

            if (seed == 0) {
                for (int i = 0; i < 256; i++)
                    p[256 + i] = p[i] = permutation[i];
            } else {
                PseudoRandom rnd = new PseudoRandom(seed);
                for (int i = 0; i < 256; i++)
                    p[256 + i] = p[i] = (short)rnd.Range(256);
            }
        }

        /// <summary>
        /// 3维噪声值
        /// </summary>
        public double Noise(double x, double y, double z) {

            // FIND UNIT CUBE THAT CONTAINS POINT.
            int X = (int)Math.Floor(x) & 255;
            int Y = (int)Math.Floor(y) & 255;
            int Z = (int)Math.Floor(z) & 255;
            // FIND RELATIVE X,Y,Z OF POINT IN CUBE.
            // 各点的小数部分,用来计算梯度向量
            x -= Math.Floor(x);
            y -= Math.Floor(y);
            z -= Math.Floor(z);

            // COMPUTE FADE CURVESFOR EACH OF X,Y,Z.
            // 计算梯度向量前再次平滑这个xyz
            double u = Fade(x);
            double v = Fade(y);
            double w = Fade(z);

            // HASH COORDINATES OF THE 8 CUBE CORNERS,
            int A = p[X] + Y;
            int AA = p[A] + Z;
            int AB = p[A + 1] + Z;
            int B = p[X + 1] + Y;
            int BA = p[B] + Z;
            int BB = p[B + 1] + Z;

            // AND ADD// BLENDED// RESULTS// FROM  8// CORNERS// OF CUBE
            return Lerp(
                Lerp(
                    Lerp(
                        Grad(p[AA], x, y, z),
                        Grad(p[BA], x - 1, y, z),
                        u),
                    Lerp(
                        Grad(p[AB], x, y - 1, z),
                        Grad(p[BB], x - 1, y - 1, z),
                        u),
                    v),
                Lerp(
                    Lerp(
                        Grad(p[AA + 1], x, y, z - 1),
                        Grad(p[BA + 1], x - 1, y, z - 1),
                        u),
                    Lerp(
                        Grad(p[AB + 1], x, y - 1, z - 1),
                        Grad(p[BB + 1], x - 1, y - 1, z - 1),
                        u),
                    v)
                , w);
        }

        double Fade(double t) {
            return t * t * t * (t * (t * 6 - 15) + 10);
        }

        double Lerp(double a, double b, double t) {
            return a + t * (b - a);
        }

        // CONVERT LO 4 BITS OF HASH CODEINTO 12 GRADIENT DIRECTIONS.
        // 梯度函数
        double Grad(int hash, double x, double y, double z) {
            int h = hash & 15;
            double u = h < 8 ? x : y;
            double v = h < 4 ? y : h == 12 || h == 14 ? x : z;
            return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
        }


    }


}