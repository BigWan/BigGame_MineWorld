using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BW.MathUtil;
using System.Threading.Tasks;

public class GenMap : MonoBehaviour {


    public GameObject stone;
    public GameObject water;


    public int seaLevel = 63;


    public OctavedNoise<PerlinNoise> noise;

    public byte oct;
    public float amt;

    public ulong seed;


    private double[,,] density = new double[5, 33, 5];

    private void Awake() {
        noise = new OctavedNoise<PerlinNoise>(new PerlinNoise(seed), oct, amt,densityOffset,dnsityScale);
    }



    /// <summary>
    /// 密度图的Offset
    /// </summary>
    public float densityOffset =864.25f;
    /// <summary>
    /// 密度图的Scale
    /// </summary>
    public float dnsityScale =  0.05f;
    /// <summary>
    /// 生成密度图
    /// </summary>
    /// <returns></returns>
    async Task GenerateDensityMap() {

        for (int x = 0; x < 5; x++) {
            for (int z = 0; z < 5; z++) {
                for (int y = 0; y < 33; y++) {
                    density[x,y,z] = noise.NoiseOS(x, y, z);
                }
            }
             await Task.Delay(2);
        }

    }

    async void Start() {
        await  GenerateDensityMap();
    }


    /// <summary>
    /// 生成chunk 给坐标
    /// </summary>
    /// <param name="x"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    async Task GenerateChunk(int chunkX,int chunkZ) {
        //GenerateDensityMap()

        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {



            }
        }
    }





}
