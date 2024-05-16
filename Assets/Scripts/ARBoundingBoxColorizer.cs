using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARBoundingBox))]
public class ARBoundingBoxColorizer : MonoBehaviour
{
    MeshRenderer _meshRenderer;
    ARBoundingBox _boundingBox;
    
    void Reset()
    {
        _boundingBox = GetComponent<ARBoundingBox>();
    }

    void Awake()
    {
        _boundingBox = GetComponent<ARBoundingBox>();
        _meshRenderer  = GetComponentInChildren<MeshRenderer>();

        if (_meshRenderer == null)
            Debug.LogError($"{nameof(_meshRenderer)} is null.");

        UpdateBoxColor();
    }

    void Start()
    {

    }

    void Update()
    {
        //Update Transforms
        if (_meshRenderer != null)
        {
            _meshRenderer.transform.localScale = _boundingBox.size;
        }
    }

    void UpdateBoxColor()
    {
        Color boxMatColor = GetColorByClassification(_boundingBox.classifications);

        boxMatColor.a = 0.0f;
        _meshRenderer.material.color = boxMatColor;
    }

    private Color GetColorByClassification(BoundingBoxClassifications classifications)
    {
        if (classifications.HasFlag(BoundingBoxClassifications.Couch)) return Color.blue;
        if (classifications.HasFlag(BoundingBoxClassifications.Table)) return Color.yellow;
        if (classifications.HasFlag(BoundingBoxClassifications.Bed)) return Color.cyan;
        if (classifications.HasFlag(BoundingBoxClassifications.Lamp)) return Color.magenta;
        if (classifications.HasFlag(BoundingBoxClassifications.Plant)) return Color.green;     
        if (classifications.HasFlag(BoundingBoxClassifications.Screen)) return Color.white;
        if (classifications.HasFlag(BoundingBoxClassifications.Storage)) return Color.red;

        return Color.gray; // Other - Default color 
    }
}


