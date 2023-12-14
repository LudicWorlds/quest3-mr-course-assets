using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARPlane))]
[RequireComponent(typeof(MeshRenderer))]

public class ARPlaneColorizer : MonoBehaviour
{
        ARPlane m_ARPlane;
        MeshRenderer m_PlaneMeshRenderer;
        
        void Awake()
        {
            m_ARPlane = GetComponent<ARPlane>();
            m_PlaneMeshRenderer = GetComponent<MeshRenderer>();
        }

        void Start()
        {
           UpdatePlaneColor();
        }
        
        void UpdatePlaneColor()
        {
            Color planeMatColor = Color.gray; //i.e. 'None'

            switch (m_ARPlane.classification)
            {
                case PlaneClassification.Floor:
                    planeMatColor = Color.green;
                    break;
                case PlaneClassification.Wall:
                    planeMatColor = Color.white;
                    break;
                case PlaneClassification.Ceiling:
                    planeMatColor = Color.red;
                    break;
                case PlaneClassification.Table:
                    planeMatColor = Color.yellow;
                    break;
                case PlaneClassification.Seat:
                    planeMatColor = Color.blue;
                    break;
                case PlaneClassification.Door:
                    planeMatColor = Color.magenta;
                    break;
                case PlaneClassification.Window:
                    planeMatColor = Color.cyan;
                    break;
            }

            planeMatColor.a = 0.33f;
            m_PlaneMeshRenderer.material.color = planeMatColor;
        }
}
