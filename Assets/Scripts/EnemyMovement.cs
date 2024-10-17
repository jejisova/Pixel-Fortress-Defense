using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    PathFinder pathFinder;
    EnemyDamage enemyDamage;
    [SerializeField][Range(1,5)] int speed = 1;

    Castle castle;
    private void Start()
    {  castle = FindObjectOfType<Castle>();
    enemyDamage = GetComponent<EnemyDamage>();
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
            transform.LookAt(new Vector3(wayPoint.transform.position.x,transform.position.y,wayPoint.transform.position.z));
            transform.position = wayPoint.transform.position;
            
            yield return new WaitForSeconds((1f/speed));
        }
        
        enemyDamage.EnemyDestroy();
        castle.Damage();




        
    }
}
