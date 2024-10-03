using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour
{
     TextMesh label;
     WayPoint wayPoint;
    
    void Awake()
    {
    wayPoint = GetComponent<WayPoint>();
    }
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }
    private void UpdateLabel()
    {   int gridSize = wayPoint.GetGridSize();
        label = GetComponentInChildren<TextMesh>();
        string labelName = wayPoint.GetGridPos().x+","+wayPoint.GetGridPos().y;
        label.text = labelName;
        gameObject.name = labelName;
    }
    private void SnapToGrid()
    {   int gridSize = wayPoint.GetGridSize();
        transform.position = new Vector3(wayPoint.GetGridPos().x*gridSize,0f,wayPoint.GetGridPos().y*gridSize);
    }   
}
