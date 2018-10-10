using UnityEngine;
using System.Collections;

namespace BigWorld {

    /// <summary>
    /// Chunk 地形生成器
    /// </summary>
    public class MapGeneration  {

        /// <summary>
        /// 随机种子
        /// </summary>
        public int seed;

        /// <summary>
        /// 生成半径
        /// </summary>
        public int range;

        Chunk Generation(World world,Vector2Int chunkCoord) {

            Chunk chunk = new Chunk();

            for (int x = 0; x < chunk.width; x++) {
                for (int z = 0; z < chunk.depth; z++) {

                }

            }


        }
    }
}