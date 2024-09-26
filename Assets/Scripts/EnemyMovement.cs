using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<WayPoint> WayPoints;
    
    void Start()
    {   
        //print("Персонаж начал движение");
       // StartCoroutine(PrintWayPointName());
        
    }

    void Update()
    {
        
    }

    IEnumerator PrintWayPointName()
    {

        

        foreach(WayPoint wayPoint in WayPoints)
        {   
            transform.position = wayPoint.transform.position;
            print("Персонаж передвинулся на точку:"+ wayPoint.gameObject.name);
            yield return new WaitForSeconds(1f);
        }

        
    }
}
