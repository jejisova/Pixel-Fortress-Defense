using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int,WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    [SerializeField] WayPoint startPoint, endPoint;

    WayPoint searchPoint;

    Vector2Int[] directions = {
    Vector2Int.up,
    Vector2Int.right,
    Vector2Int.down,
    Vector2Int.left
    };

    Queue<WayPoint> queue = new Queue<WayPoint>();
    bool isRanning = true;

    public List<WayPoint> path = new List<WayPoint>();

    public List<WayPoint> GetPath()
    {   
        LoadBlocks();
        SetColorStartAndEnd();
        PathFind();
        CreatePath();
        return path;
    }

    private void CreatePath()
    {
        path.Add(endPoint);
        WayPoint prevPoint = endPoint.exploredFrom;
        while (prevPoint != startPoint)
        {   
            prevPoint.SetTopColor(Color.gray);
            path.Add(prevPoint);
           prevPoint = prevPoint.exploredFrom; 
        }
     path.Add(startPoint);
     path.Reverse();

    }

    private void PathFind()
    {
        queue.Enqueue(startPoint);

        while(queue.Count > 0 && isRanning == true)
        {
          searchPoint = queue.Dequeue(); 
          searchPoint.isExplored = true;
          CheckForEndpoint();
          ExploreNearPoints();
        }

    }

    private void CheckForEndpoint()
    {
        if(searchPoint == endPoint)
        {
            isRanning = false;
            endPoint.SetTopColor(Color.red);
        }
        else
        {}
        

    }

    private void LoadBlocks()
    {   
        var waypoints = FindObjectsOfType<WayPoint>();
        foreach(WayPoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();  
            if (grid.ContainsKey(gridPos))
            {}
            else
            grid.Add(gridPos,waypoint);
        }
        

    }

    void SetColorStartAndEnd()
    {
      startPoint.SetTopColor(Color.green);
      
    }

    void ExploreNearPoints()
    {   
        if(isRanning == false)
        return;
        
        foreach(Vector2Int direction in directions)
        {
            Vector2Int nearPointCordinates = (searchPoint.GetGridPos() + direction);
            if(grid.ContainsKey(nearPointCordinates))
            {
                WayPoint nearpoint = grid[nearPointCordinates];
                AddPointToQueue(nearpoint);
            }
        }        
    }

    private void AddPointToQueue(WayPoint nearpoint)
    {   
        if(nearpoint.isExplored || queue.Contains(nearpoint))
        {}
        else
        {
        queue.Enqueue(nearpoint);
        nearpoint.exploredFrom = searchPoint;
        
        }
        
    }
}
