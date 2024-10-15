  using System;
  using System.Collections;
  using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
        SetTargetEnemy();
        

        if (targetEnemy)
        { towerTop.LookAt(new Vector3(targetEnemy.position.x, towerTop.transform.position.y, targetEnemy.position.z));

          Fire();
        }
        else
        {
          Shoot(false);
        }
        
      

          
      }

      private void SetTargetEnemy()
      {

        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
  
        if (sceneEnemies.Length == 0)
        {return;}
        
        Transform closestEnemy = sceneEnemies[0].transform;

        foreach(EnemyDamage test in sceneEnemies)
        { 
          closestEnemy = GetClosestEnemy(closestEnemy.transform, test.transform);

        }

        targetEnemy = closestEnemy;

      }

      private Transform GetClosestEnemy(Transform EnemyA, Transform EnemyB)
      { 
        var distToA = Vector3.Distance(EnemyA.position, transform.position);
         var distToB = Vector3.Distance(EnemyB.position, transform.position);

         if(distToA < distToB)
         {
          return EnemyA;
         }
         else
         {
          return EnemyB;
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
