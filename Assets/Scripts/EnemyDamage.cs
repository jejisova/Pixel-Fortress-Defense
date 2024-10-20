using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting.AssemblyQualifiedNameParser;


public class EnemyDamage : MonoBehaviour
{   
    [SerializeField] int hitPoints = 5;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] ParticleSystem deathParticles;

    [SerializeField] TMP_Text scoreText;
    int currentScore;

    [SerializeField] AudioClip EnemyDamageFx;
    [SerializeField] AudioClip EnemyDestroyFx;

    AudioSource audioSource;

    void Start()
    {   
        scoreText = GameObject.Find("Enemies").GetComponent<TMP_Text>();
        
        
 

    }

    void Update()
    {
        DeleteEnemy();
       
    }

    public void DeleteEnemy()
    {
        if(hitPoints <= 0)
        {
          EnemyDestroy(true);
          

        }
    }

    public void EnemyDestroy(bool addToScore)
    {   
        if(addToScore == true)
        {
        currentScore = int.Parse(scoreText.text);
        currentScore++;
        scoreText.text = currentScore.ToString();

        }
        
        var destroyFx = Instantiate(deathParticles,transform.position, Quaternion.identity);
          destroyFx.Play();
          var MainCamera = GameObject.Find("Main Camera");
          AudioSource.PlayClipAtPoint(EnemyDestroyFx,MainCamera.transform.position);
          
          Destroy(destroyFx.gameObject,destroyFx.main.duration);
          Destroy(gameObject);
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(EnemyDamageFx);
        


    }

    private void ProcessHit()
    {   
        
        hitPoints = hitPoints - 1;
        hitParticles.Play();
        
        
    }


}
