using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;


public class LightmapSwitcher : MonoBehaviour
{
    public Texture2D[] directionTextures1;
    public Texture2D[] colorTextures1;

    public Texture2D[] directionTextures2;
    public Texture2D[] colorTextures2;

    public ProbeData probes1;
    public ProbeData probes2;

    private LightmapData[] lightmaps;
    private LightmapData[] lightmaps2;


    private bool mismatch = false;
    private bool started = false;

    private void Update()
    {
      if(!started && LightmapSettings.lightProbes != null)
        {
            started = true;
            SetStartingProbes();
        }
    }

    

    /* void Update()
     {
         if (Input.GetKeyDown(KeyCode.L))
         {

             blendMaterial.SetTexture("_TextureA", color1);
             blendMaterial.SetTexture("_TextureB", color2);
             blendMaterial.SetFloat("_Blend", 0.5f);

             Graphics.Blit(color1, dest, blendMaterial);

             Graphics.CopyTexture(dest, mixedColorText);

             Texture2D temp = (Texture2D)mixedColorText;
             temp.Apply(true);

             lightmaps2[0].lightmapDir = dir1; //ignore this, just using the original light direction
             lightmaps2[0].lightmapColor = temp;

             LightmapSettings.lightmaps = lightmaps2;
         }
     }*/

    public void SetStartingProbes()
    {
       
        if (directionTextures1.Length != colorTextures1.Length ||
            directionTextures1.Length != directionTextures2.Length ||
            colorTextures1.Length != colorTextures2.Length)
        {
            Debug.LogError("Lightmap switcher error! Direction and color textures mismatch!");

            mismatch = true;
            return;
        }

        lightmaps = new LightmapData[colorTextures1.Length];
        lightmaps2 = new LightmapData[colorTextures1.Length];

        for (int i = 0; i < lightmaps.Length; i++)
        {
            lightmaps[i] = new LightmapData();
            lightmaps[i].lightmapDir = directionTextures1[i];
            lightmaps[i].lightmapColor = colorTextures1[i];
        }

        for (int i = 0; i < lightmaps.Length; i++)
        {
            lightmaps2[i] = new LightmapData();
            lightmaps2[i].lightmapDir = directionTextures2[i];
            lightmaps2[i].lightmapColor = colorTextures2[i];
        }


        LightmapSettings.lightmaps = lightmaps;
        LightmapSettings.lightProbes.bakedProbes = probes1.DeserializeLightProbes();

    }

    public void ChangeLightmaps()
    {
        if(mismatch)
        {
            Debug.LogError("Lightmap switcher error! Direction and color textures mismatch!");
            return;
        }
        LightmapSettings.lightmaps = lightmaps2;
        LightmapSettings.lightProbes.bakedProbes = probes2.DeserializeLightProbes();
    }

    /* IEnumerator ChangeLightmap()
     {
         float i = 0;
         while (i < fadeTime)
         {
             Color[] mixedDir = new Color[dirPixels1.Length];
             Color[] mixedColor = new Color[dirPixels1.Length];

             //Change directional texture
             for (int x = 0; x < mixedDir.Length; x++)
             {
                 mixedDir[x] = Color.Lerp(dirPixels1[x], dirPixels2[x], i/fadeTime);
             }
             mixedDirText.SetPixels(mixedDir);
             mixedDirText.Apply(true);



             //Change color texture
             for (int x = 0; x < mixedColor.Length; x++)
             {
                 mixedColor[x] = Color.Lerp(colorPixels1[x], colorPixels2[x], i / fadeTime);
             }
             mixedColorText.SetPixels(mixedColor);
             mixedColorText.Apply(true);

             lightmaps2[0].lightmapDir = mixedDirText;
             lightmaps2[0].lightmapColor = mixedColorText;

             LightmapSettings.lightmaps = lightmaps2;
             i += Time.deltaTime;
             yield return null;
         }


     }*/



}
