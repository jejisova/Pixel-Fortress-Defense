using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class Tower : MonoBehaviour
{   
    [SerializeField] Transform towerTop;
    [SerializeField] Transform targetEnemy;

    void Update()
    { 

      
      towerTop.LookAt(targetEnemy);
     

        
    }





}
