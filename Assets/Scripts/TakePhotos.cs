using UnityEngine;
using System.Collections;
using System;

public class TakePhotos : MonoBehaviour
{ 
    public void TakePhoto()
    {
        StartCoroutine(TakeAPhoto());
    }

    IEnumerator TakeAPhoto()
    {
        yield return new WaitForEndOfFrame();

        Camera camera = Camera.main;
        if (camera == null)
        {
            Debug.LogError("No main camera found!");
            yield break;
        }

        int width = Screen.width;
        int height = Screen.height;
        RenderTexture rt = new RenderTexture(width, height, 24);
        camera.targetTexture = rt;

        var currentRT = RenderTexture.active;
        RenderTexture.active = rt;

        camera.Render();

        Texture2D image = new Texture2D(width, height, TextureFormat.RGB24, false);
        image.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        image.Apply();

        RenderTexture.active = currentRT;
        camera.targetTexture = null;
        rt.Release();

        // Save to the gallery using Native Gallery
        string filename = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
        NativeGallery.SaveImageToGallery(image, "MyApp Photos", filename);
        Debug.Log("Photo saved to gallery!");

        Destroy(rt);
        Destroy(image);
    }
}
