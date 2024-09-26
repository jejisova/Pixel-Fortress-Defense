using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Dictionary<Vector2Int,WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    void Start()
    {
        LoadBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadBlocks()
    {   
        var waypoints = FindObjectsOfType<WayPoint>();
        foreach(WayPoint waypoint in waypoints)
        {
            //Проверить на дубликаты
            
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());

            if (isOverlapping)
            Debug.LogWarning("ПОВТОР БЛОКОВ!"+waypoint);
            else
            grid.Add(waypoint.GetGridPos(),waypoint);

            
            
        }
        



    }


}
