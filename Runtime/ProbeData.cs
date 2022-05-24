using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[System.Serializable]
public class SerializableHarmonics
{
    [SerializeField]
    public float[] coefficients = new float[27];
}

[CreateAssetMenu(fileName = "ProbeData", menuName = "ScriptableObjects/ProbeData", order = 1)]
public class ProbeData : ScriptableObject
{

    [SerializeField]
    public SerializableHarmonics[] harmonics;

    public void SerializeLightProbes(SphericalHarmonicsL2[] toSerialize)
    {
        harmonics = new SerializableHarmonics[toSerialize.Length];

        for (int k = 0; k < toSerialize.Length; k++)
        {
           SerializableHarmonics sHarmonics = new SerializableHarmonics();
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    sHarmonics.coefficients[j * 9 + i] = toSerialize[k][j, i];
                }
            }

            harmonics[k] = sHarmonics;
        }
    }

    public SphericalHarmonicsL2[] DeserializeLightProbes()
    {
        SphericalHarmonicsL2[] deserialized = new SphericalHarmonicsL2[harmonics.Length];

        for (int i = 0; i < deserialized.Length; i++)
        {
            var sphericalHarmonics = new SphericalHarmonicsL2();

            // j is coefficient
            for (int j = 0; j < 3; j++)
            {
                //k is channel ( r g b )
                for (int k = 0; k < 9; k++)
                {
                    sphericalHarmonics[j, k] = harmonics[i].coefficients[j * 9 + k];
                }
            }

            deserialized[i] = sphericalHarmonics;
        }

        return deserialized;
    }

}

