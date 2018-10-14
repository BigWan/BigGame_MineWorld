using UnityEngine;
using System.Collections;

using BW.MathUtil;

public class TestPerlin : MonoBehaviour {

    public int seed;

    public Transform tempGO;

    public int size = 100;

    double[,] value;

    Texture2D tex;

    public int octaves;
    public double amplitude;
    public double persistance;
    public double frequence;
    public double lacunarity;

    double max = 0;
    double min = 0;

    private void Awake() {

        StartCoroutine(Test());
    }

    IEnumerator SHowTEmp() {

        PerlinNoise noise = new PerlinNoise();
        value = new double[size, size];

        this.tex = new Texture2D(size, size);
        tempGO.GetComponent<MeshRenderer>().material.mainTexture = this.tex;

        double temp;

        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                //temp = BW.Noise.ImprovedNoise.Value3D((double)i/(double)100, (double)j/(double)100,0);
                temp = noise.Noise((double) i / (double) 100, (double) j / (double) 100, 1);
                if (temp < min) min = temp;
                if (temp > max) max = temp;
                this.tex.SetPixel(i, j, Color.white * (float) temp);
            }

            yield return null;
        }

        Debug.Log(min + "/" + max);

        this.tex.Apply();
    }


    IEnumerator Test() {
        PerlinNoise noise = new PerlinNoise();
        double temp;
        double min=0, max=0;
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                temp = noise.Noise((double) i / (double) 100, (double) j / (double) 100, 1);
                if (temp < min) min = temp;
                if (temp > max) max = temp;
                
            }
            yield return null;
        }

        Debug.Log(min+"/"+ max);

    }
}
