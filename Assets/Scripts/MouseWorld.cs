using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    [SerializeField] private LayerMask mousePlaneLayerMask;
    public static MouseWorld instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit rayCastHit, float.MaxValue, instance.mousePlaneLayerMask);
        return rayCastHit.point;
    
    }
}
