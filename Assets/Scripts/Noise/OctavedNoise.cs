namespace BW.MathUtil {

    /// <summary>
    /// 振幅叠加的噪声
    /// </summary>
    public class OctavedNoise<T>:INoise where T : INoise {

        /// <summary> 频率 </summary>
        private byte octaves;

        /// <summary> 振幅叠加常数 </summary>
        private float persistence;

        /// <summary> 基础噪声函数 </summary>
        private T noise;

        public OctavedNoise(T noise,byte octaves,float persistence ) {
            this.noise = noise;
            this.octaves = octaves;
            this.persistence = persistence;
        }

        public double Noise(double x, double y, double z) {
            double total = 0;
            int frequency = 1;
            double amplitude = 1;
            double maxValue = 0;

            for (int i = 0; i < octaves; i++) {
                total += noise.Noise(x * frequency, y * frequency, z * frequency) * amplitude;
                maxValue += amplitude;
                amplitude *= persistence;
                frequency *= 2;
            }

            return total / maxValue;


        }


    }

}