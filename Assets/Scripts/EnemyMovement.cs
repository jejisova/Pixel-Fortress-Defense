using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{

    PathFinder pathFinder;
    EnemyDamage enemyDamage;
    [SerializeField] float speed = 1;

    Castle castle;

   [SerializeField] float changeSpeed;
   [SerializeField] TMP_Text scoreText;

    Vector3 targetPosition;
    private void Start()
    {  castle = FindObjectOfType<Castle>();
       enemyDamage = GetComponent<EnemyDamage>();
       pathFinder = FindObjectOfType<PathFinder>();
       var path = pathFinder.GetPath();
       StartCoroutine(EnemyMove(path));
       
    }

    void Update()
    {   
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime*changeSpeed);
        
    }

    public void SetSpeed(float currentSpeed)
    {   
        
        speed = currentSpeed;
  
        
    }

    IEnumerator EnemyMove(List<WayPoint> path)
    {        

        foreach(WayPoint wayPoint in path)
        {   
            transform.LookAt(new Vector3(wayPoint.transform.position.x,transform.position.y,wayPoint.transform.position.z));
            targetPosition = wayPoint.transform.position;
            yield return new WaitForSeconds((1f/speed));
        }
        
        enemyDamage.EnemyDestroy(false);
        castle.Damage();




        
    }
}
