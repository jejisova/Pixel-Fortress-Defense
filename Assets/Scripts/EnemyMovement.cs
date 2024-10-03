using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    PathFinder pathFinder;
    void Start()
    {   
       pathFinder = FindObjectOfType<PathFinder>();
       var path = pathFinder.GetPath();
       StartCoroutine(EnemyMove(path));
        
    }

    void Update()
    {
        
    }

    IEnumerator EnemyMove(List<WayPoint> path)
    {        

        foreach(WayPoint wayPoint in path)
        {   
            transform.LookAt(wayPoint.transform);
            print(wayPoint.transform);
            transform.position = wayPoint.transform.position;
            //print("Персонаж передвинулся на точку:"+ wayPoint.gameObject.name);
            yield return new WaitForSeconds(2f);
        }

        
    }
}
