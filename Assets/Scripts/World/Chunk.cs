using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigWorld {
    /// <summary>
    /// Chunk 
    /// </summary>
    public class Chunk {

        /// <summary>
        /// Chunk尺寸(Block为单位)
        /// </summary>
        public const int xSize = 16, height = 128, zSize = 16;
                       

        /// <summary>坐标</summary>
        public int x,z;

        /// <summary>
        /// Chunk的坐标(chunk只有xz平面坐标)
        /// </summary>
        public Vector2Int coord { get { return new Vector2Int(x, z); } }

        /// <summary>
        /// 高度图
        /// </summary>
        private int[] heightMap = new int[xSize * zSize];
        /// <summary>
        /// 生物群ID
        /// </summary>
        public int[] biomes;
        /// <summary>
        /// 最大高度
        /// </summary>
        public int maxHeight { get; private set; }

        /// <summary>
        /// 获取方块ID
        /// </summary>
        private int[] data;


        public Chunk(Vector2Int coord) {
            x = coord.x;
            z = coord.y;
        }

        public int GetBLockID(Vector3Int coord) {
            return data[GetBlockIndex(coord)];
        }

        public void SetBlockID(Vector3Int coord,int value) {
            int index = GetBlockIndex(coord);
            data[index] = value;
        }


        public int GetBlockIndex(Vector3Int coord) {
            return coord.x + coord.z * 16 + coord.y * 16 * 16;
        }

        public Vector3Int GetBlockCoord( Block block) {
            return new Vector3Int(coord.x * 16 - 8 + block.x, block.y, z * 16 - 8 + block.z);
        }



        public int GetBLockHeight(Vector3Int blockCoord) {
            return heightMap[blockCoord.x + blockCoord.z * 16];
        }

        public void SetHeightMap(int x,int z,int height) {
            heightMap[x + z * xSize] = height;
        }
    }




}

