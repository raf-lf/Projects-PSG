using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class WebCam : MonoBehaviour
{
    public RawImage cameraOutput;
    public WebCamTexture camTexture;
    Texture2D texture;


    private void Start()
    {
        cameraOutput = GetComponent<RawImage>();
        camTexture = new WebCamTexture();
        camTexture.Play();
        texture = new Texture2D(camTexture.width, camTexture.height);
        cameraOutput.texture = texture;
    }

    private void Update()
    {
        Color[] pixels = camTexture.GetPixels();

        texture.SetPixels(pixels);
        texture.Apply();
    }
}
