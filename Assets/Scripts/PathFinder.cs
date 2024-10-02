using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Dictionary<Vector2Int,WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
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
    
    
    void Start()
    {   
        LoadBlocks();
        SetColorStartAndEnd();
        PathFind();
        

    }

    private void PathFind()
    {
        queue.Enqueue(startPoint);

        while(queue.Count > 0 && isRanning == true)
        {
          searchPoint = queue.Dequeue(); 
          print("Точка которая проверяется:" + searchPoint);
          searchPoint.isExplored = true;
          CheckForEndpoint();
          ExploreNearPoints();
                 
          
        }
        
        // Сгенерировать путь


    }

    private void CheckForEndpoint()
    {
        if(searchPoint == endPoint)
        {
            print("Алгоритм нашел ендпоинт");
            isRanning = false;
            endPoint.SetTopColor(Color.red);
        }
        else
        print("Ендпоинт не найден");

    }

    private void LoadBlocks()
    {   
        var waypoints = FindObjectsOfType<WayPoint>();
        foreach(WayPoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();  
            if (grid.ContainsKey(gridPos))
            Debug.LogWarning("ПОВТОР БЛОКОВ: "+ waypoint);
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
            try{
                WayPoint nearpoint = grid[nearPointCordinates];
                AddPointToQueue(nearpoint);
            }
            catch{
                // Debug.LogWarning("Блок:"+nearPointCordinates+"Отсутствует:");
                
            }
        }        


    }

    private void AddPointToQueue(WayPoint nearpoint)
    {   
        if(nearpoint.isExplored || queue.Contains(nearpoint))
        {}
        else
        {
        nearpoint.SetTopColor(Color.blue);
        queue.Enqueue(nearpoint);
        print("Добавить в очередь: " + nearpoint);
        }
        
    }
}
