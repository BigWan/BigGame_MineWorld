using UnityEngine;
using System.Collections;
using System;
namespace BigWorld {

    /// <summary>
    /// 生物群系ID
    /// </summary>
    public enum BiomeID {

        /// <summary> 平原 </summary>
        Plains = 0,
        /// <summary> 沙漠 </summary>
        Desert = 1,
        /// <summary> 森林 </summary>
        Forest = 2,
        /// <summary> 雨林 </summary>
        Rainforest = 3,
        /// <summary> 季节性森林 </summary>
        SeasonalForest = 4,
        /// <summary> 热带大草原 </summary>
        Savanna = 5,
        /// <summary> 灌木林 </summary>
        Shrubland = 6,
        /// <summary> 沼泽地 </summary>
        Swampland = 7,
        /// <summary> 低洼地带 </summary>
        Hell = 8,
        /// <summary> 天空 </remarks>
        Sky = 9,
        /// <summary> 北方针叶林 </summary>
        Taiga = 10,
        /// <summary> 冻原 </summary>
        Tundra = 11,
        /// <summary> 冰漠 </remarks>
        IceDesert = 12,
        /// <summary> 海洋 </summary>
        Ocean = 13,
        /// <summary> 河流 </remarks>
        River = 14,
        /// <summary> 沙滩 </remarks>
        Beach = 15,
        /// <summary> 冻海 </summary>
        FrozenOcean = 16,
        /// <summary> 冻河 </summary>
        FrozenRiver = 17,
    }


    /// <summary>
    /// 生物群系
    /// </summary>
    public class Biome {

        public bool spawn;
        public byte id;

        public int elevation;
        public float temperature;
        public float rainfall;

        public TreeSpecies[] trees;
        public PlantSpecies[] plants;
        public OreTypes[] ores;

        public float treeDensity;

        public byte waterBlock;
        public byte surfaceBlock;
        public byte fillerBlock;

        public int surfaceDepth;
        public int fillerDepth;

    }


}
