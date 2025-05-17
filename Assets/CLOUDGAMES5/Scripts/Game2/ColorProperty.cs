using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorProperty : MonoBehaviour
{
    [SerializeField] protected ColorData colorData;
    [SerializeField] protected MeshRenderer meshRenderer;
    protected Material _material;

    protected void Start()
    {
        _material = meshRenderer.material;

        SetUpColor(colorData);
    }

    protected void SetUpColor(ColorData newColorData)
    {
        colorData = newColorData;

        _material.SetColor("_Color", colorData.color);
    }
}