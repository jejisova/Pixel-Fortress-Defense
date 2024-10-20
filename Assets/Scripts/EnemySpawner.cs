using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour

{

    
     [SerializeField]  public float spawnInterval;
    [SerializeField] EnemyMovement enemyPrefab;

    [SerializeField] AudioClip EnemySpawnerFx;

    AudioSource audioSource;

    public bool isActive = true;

    void Start()
    {
        //Запустить сопрограмму 
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(EnemySpawn());
        
        

        
    }

    IEnumerator EnemySpawn()
    {

        while(isActive == true)
        {   
            audioSource.PlayOneShot(EnemySpawnerFx);
            var newEnemy = Instantiate(enemyPrefab, new Vector3(transform.position.x,0,transform.position.y),Quaternion.identity);
            newEnemy.transform.parent = transform;
            yield return new WaitForSeconds(spawnInterval);
        }
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


}
