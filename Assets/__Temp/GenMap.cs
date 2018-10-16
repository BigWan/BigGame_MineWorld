using System;
using UnityEngine;
using BW.MathUtil;

public class GenMap : MonoBehaviour {


    private OctavedNoise<PerlinNoise> noise;

    public GameObject stone;
    public GameObject water;
    public ulong seed;
    double[,,] heightMap = new double[16, 16, 16];
    private void Awake() {

        noise = new OctavedNoise<PerlinNoise>(new PerlinNoise(seed), 8, 0.5f);
    }



    void GenHeightMap() {
        
        for (int x = 0; x < 16; x++) {
            for (int y = 0; y < 16; y++) {
                for (int z = 0; z < 16; z++) {
                    heightMap[x, y, z] = noise.Noise(x, y, z);
                }
            }
        }


    }


    void GenMap() {
        double height;
        for (int x = 0; x < 16; x++) {
            for (int y = 0; y < 16; y++) {
                for (int z = 0; z < 16; z++) {
                    height = heightMap[x, y, z];
                }
            }
        }
    }

}