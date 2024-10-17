using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{   
    [SerializeField] int hitPoints = 5;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] ParticleSystem deathParticles;

    void Update()
    {
        DeleteEnemy();
       
    }

    public void DeleteEnemy()
    {
        if(hitPoints <= 0)
        {
          EnemyDestroy();
          

        }
    }

    public void EnemyDestroy()
    {
        var destroyFx = Instantiate(deathParticles,transform.position, Quaternion.identity);
          destroyFx.Play();
          Destroy(destroyFx.gameObject,destroyFx.main.duration);
          Destroy(gameObject);
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        
        


    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticles.Play();
        
        
    }


}
