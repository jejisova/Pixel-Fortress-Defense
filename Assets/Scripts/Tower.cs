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

      [SerializeField] float distanceToEnemy;
  
      void Update()
      { 

      
        SetTargetEnemy();

        if (targetEnemy)
        { distanceToEnemy =  Vector3.Distance(targetEnemy.position,transform.position);
          
          if (distanceToEnemy > shootRange)
          { Shoot(false);
            return;}
          towerTop.LookAt(new Vector3(targetEnemy.position.x, towerTop.transform.position.y, targetEnemy.position.z));
        }
       
        Fire();
      

          
      }

      private void SetTargetEnemy()
      { 
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0)
        { distanceToEnemy = 100f;
          return; }
        
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
        if(bulletParticle.isPlaying == false && isActive == true)
        {bulletParticle.Play();}
        else if(bulletParticle.isPlaying == true && isActive == false)
        {bulletParticle.Play();}


        
        

      }
  }
