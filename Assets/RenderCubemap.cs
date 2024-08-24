using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RenderCubemap : MonoBehaviour {
    public RenderTexture cubemap;
    public int resolution = 512;
    Camera cam ;
    void Initialize() {
      if(cubemap == null) {
        cubemap = new RenderTexture(resolution, resolution, 16);
            cubemap.dimension = TextureDimension.Cube;
            cubemap.Create();
        }
    }
    
    void Awake () {
        cam = GetComponent<Camera>();
        Initialize();
    }

    void LateUpdate () {
          
          cam.RenderToCubemap(cubemap);
    }
    
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
       Graphics.Blit(source, destination);
    }

}
