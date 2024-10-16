using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[SelectionBase]

public class WayPoint : MonoBehaviour
{   const int gridSize = 10;
    Vector2Int gridPos;
    TowerCreator towerCreator;

    public bool isExplored = false;
    [SerializeField] public WayPoint exploredFrom;
    public bool isPlaceble = true;
    public bool isEmpty = true;
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

    void OnMouseOver()
    {   
        WayPoint currentWaypoint = this;
        if(Input.GetMouseButtonDown(0) && isPlaceble == true )
        {   towerCreator = FindObjectOfType<TowerCreator>();
            towerCreator.CreateTower(transform.position, currentWaypoint);
        }
        

    }
}
