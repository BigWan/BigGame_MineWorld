using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigWorld {
    /// <summary>
    /// Chunk 
    /// </summary>
    public class Chunk : MonoBehaviour {

        /// <summary>
        /// Chunk尺寸(Block为单位)
        /// </summary>
        public int width = 16, height = 128, depth = 16;
                       

        /// <summary>坐标</summary>
        public int x,z;

        /// <summary>
        /// Chunk的坐标,注意区分Block坐标
        /// </summary>
        public Vector2Int coord;

        /// <summary>
        /// 高度图
        /// </summary>
        public int[] heightMap;
        /// <summary>
        /// 生物群ID
        /// </summary>
        public int[] biomes;
        /// <summary>
        /// 最大高度
        /// </summary>
        public int maxHeight;

        /// <summary>
        /// 获取方块ID
        /// </summary>
        public int[] data;


        public int GetBLockID(Vector3Int coord) {
            return data[GetBlockIndex(coord)];
        }

        public void SetBlockID(Vector3Int coord,int value) {
            int index = GetBlockIndex(coord);

        }


        public int GetBlockIndex(Vector3Int coord) {
            return coord.x + coord.z * 16 + coord.y * 16 * 16;
        }

    }




}

