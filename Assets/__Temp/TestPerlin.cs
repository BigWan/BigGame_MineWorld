using UnityEngine;
using System.Collections;

public class TestPerlin : MonoBehaviour {

    public int seed ;

    public Transform tempGO;

    public int size = 100;

    double[,] value;

    Texture2D temp;

    public int octaves;
    public double amplitude;
    public double persistance;
    public double frequence;
    public double lacunarity;

    double max = 0;
    double min = 0;

    private void Awake() {
        StartCoroutine(SHowTEmp());
    }

    IEnumerator SHowTEmp() {
        Perlin CaveNoise = new Perlin(seed);
        CaveNoise.Octaves = octaves;
        CaveNoise.Amplitude = amplitude;
        CaveNoise.Persistance = persistance;
        CaveNoise.Frequency = frequence;
        CaveNoise.Lacunarity = lacunarity;
        value = new double[size, size];

        this.temp = new Texture2D(size, size);
        tempGO.GetComponent<MeshRenderer>().material.mainTexture = this.temp;
        double temp;
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size ; j++) {
                temp = CaveNoise.Value2D((float)i/(float)size, (float)j/(float)size);
                if (temp<min) min= temp;
                if (temp >max) max = temp;
            }
            yield return null;
        }

        Debug.Log(min + "/"+ max);


        this.temp.Apply();
    }


}
