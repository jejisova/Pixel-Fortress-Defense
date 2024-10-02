using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class WayPoint : MonoBehaviour
{   const int gridSize = 10;
    Vector2Int gridPos;

    public bool isExplored = false;
    public WayPoint exploredFrom;

    public int GetGridSize ()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x/gridSize),
        Mathf.RoundToInt(transform.position.z/gridSize)
        );
    }
    public void SetTopColor(Color color)
    {
      MeshRenderer topMeshRender = transform.Find("Top").GetComponent<MeshRenderer>();
      topMeshRender.material.color = color;
      

    }
}
