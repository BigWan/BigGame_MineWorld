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


        public float noiseScale = 0.05f;

        Chunk Generation(World world,Vector2Int chunkCoord) {

            Chunk chunk = new Chunk(chunkCoord);

            Vector2 blockCoord = Vector2.zero;

            // 生成高度图
            for (int x = 0; x < Chunk.xSize; x++) {
                for (int z = 0; z < Chunk.zSize; z++) {

                    blockCoord = GetBlockWorldCoord(chunk, new Vector2Int(x, z));

                    chunk.SetHeightMap (x, z, 
                        (int)(Mathf.PerlinNoise(blockCoord.x* noiseScale, blockCoord.y* noiseScale) * 128)
                        );
                }
            }

            // 从高度图建立基础地形





            return chunk;
        }



        Vector2Int GetBlockWorldCoord(Chunk chunk,Vector2Int blockCoord) {

            return new Vector2Int(chunk.x * 16 + blockCoord.x, chunk.z * 16 + blockCoord.y);

        }
        

    }
}