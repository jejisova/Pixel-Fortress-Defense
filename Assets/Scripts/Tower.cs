using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class Tower : MonoBehaviour
{   
    [SerializeField] Transform towerTop;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float shootRange;
    [SerializeField] ParticleSystem bulletParticle;
 
    void Update()
    { 

      
      towerTop.LookAt(targetEnemy);
      if (targetEnemy)
      {
        Fire();
      }
      else
      {
        Shoot(false);
      }
      
     

        
    }

    private void Fire()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, transform.position);
        if (distanceToEnemy < shootRange)
        {
          Shoot(true);
        }
        else{
          Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
      var emission = bulletParticle.emission;   
      emission.enabled = isActive;
    }
}
