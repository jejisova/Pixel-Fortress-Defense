using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{   
    [SerializeField] int hitPoints = 5;
    

    void Update()
    {
        DeleteEnemy();
       
    }

    private void DeleteEnemy()
    {
        if(hitPoints <= 0)
        {
          
          Destroy(gameObject);

        }
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();


    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        
    }


}
