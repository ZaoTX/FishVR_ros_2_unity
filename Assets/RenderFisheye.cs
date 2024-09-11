using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
public class RenderFisheye : MonoBehaviour {
    public RenderCubemap cubemap_script;
    public Shader shader;
    public float alpha = 4.0f;
    public float chi = 0.0f;
    public float focalLength = 1.0f;

    public TMP_Text alphaVal;
    public TMP_Text chiVal;
    public TMP_Text focalVal;
    private Material _material;
    private Material material {
        get {
            if (_material == null) {
                _material = new Material(shader);
                _material.hideFlags = HideFlags.HideAndDontSave;
            }
            return _material;
        }
    }

    void Start () {
    }

    private void OnDisable() {
        if (_material != null)
            DestroyImmediate(_material);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Debug.Log("OnRenderImage: Fisheye");
        if (shader != null)
        {
            material.SetTexture("_Cube", cubemap_script.cubemap);
            material.SetFloat("_Alpha", alpha);
            material.SetFloat("_Chi", chi);
            material.SetFloat("_FocalLength", focalLength);
            Graphics.Blit(source, destination, material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.A)){
             alpha+=0.01f;
             alphaVal.text = alpha.ToString();
        }
        else if (Input.GetKeyDown(KeyCode.Z)){
             alpha-=0.01f;
             alphaVal.text = alpha.ToString();
        }
        if (Input.GetKeyDown(KeyCode.D)){
             chi+=0.01f;
             chiVal.text = chi.ToString();
        }
        else if (Input.GetKeyDown(KeyCode.C)){
             chi-=0.01f;
             chiVal.text = chi.ToString();
        }
        if (Input.GetKeyDown(KeyCode.F)){
             focalLength+=0.01f;
             focalVal.text = focalLength.ToString();
        }
        else if (Input.GetKeyDown(KeyCode.V)){
             focalLength-=0.01f;
             focalVal.text = focalLength.ToString();
        }
    }
}
