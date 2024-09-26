using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Dictionary<Vector2Int,WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    [SerializeField] WayPoint startPoint, endPoint;

    Vector2Int[] directions = {
    Vector2Int.up,
    Vector2Int.right,
    Vector2Int.down,
    Vector2Int.left
    };
    
    void Start()
    {   
        LoadBlocks();
        SetColorStartAndEnd();
        ExploreNearPoints();

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
            Vector2Int gridPos = waypoint.GetGridPos();  
            if (grid.ContainsKey(gridPos))
            Debug.LogWarning("ПОВТОР БЛОКОВ: "+ waypoint);
            else
            grid.Add(gridPos,waypoint);
        }
        print(grid.Count);

    }

    void SetColorStartAndEnd()
    {
      startPoint.SetTopColor(Color.green);
      endPoint.SetTopColor(Color.red);
    }

    void ExploreNearPoints()
    {   // Добавить в очередь ближайшие клетки
        // Проверить ближайшие клетки  на то, являются ли они концем и существуют ли они
        // Если нет
        // Оставить хлебные крошки
        // Добавить в очередь ближайшие клетки от тех, что мы проверили
        // повторить цикл
        
        foreach(Vector2Int direction in directions)
        {
            Vector2Int nearPointCordinates = (startPoint.GetGridPos() + direction);

            try{
                grid[nearPointCordinates].SetTopColor(Color.blue);
            }
            catch{
                Debug.LogWarning("Блок:"+nearPointCordinates+"Отсутствует:");
                
            }
        }        


    }



}
