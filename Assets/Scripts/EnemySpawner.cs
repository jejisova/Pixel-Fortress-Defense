using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour

{

    
    [SerializeField] float spawnInterval;
    [SerializeField] EnemyMovement enemyPrefab;

    [SerializeField] AudioClip EnemySpawnerFx;

    AudioSource audioSource;

    void Start()
    {
        //Запустить сопрограмму 
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(EnemySpawn());
        
        

        
    }

    IEnumerator EnemySpawn()
    {

        while(true)
        {   
            audioSource.PlayOneShot(EnemySpawnerFx);
            var newEnemy = Instantiate(enemyPrefab,transform.position,Quaternion.identity);
            newEnemy.transform.parent = transform;
            yield return new WaitForSeconds(spawnInterval);
        }
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


}
