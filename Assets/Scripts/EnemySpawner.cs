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

    public bool isGameActive = false;
    int i = 1;

    void Start()
    {   
        //Запустить сопрограмму 
        audioSource = GetComponent<AudioSource>();
        print(isGameActive);
    }

     void Update()
    {
         
        
    }

    public void StartGame()
    { 
     
     isGameActive = true;
     if(isGameActive == true && i == 1)
      { 
        StartCoroutine(EnemySpawn());  
        i++;
      }
        

    }

    IEnumerator EnemySpawn()
    {

        while(isGameActive == true)
        {   
            audioSource.PlayOneShot(EnemySpawnerFx);
            var newEnemy = Instantiate(enemyPrefab, new Vector3(transform.position.x,0,transform.position.y),Quaternion.identity);
            newEnemy.transform.parent = transform;
            yield return new WaitForSeconds(spawnInterval);
        }
        
       
        
    }

    // Update is called once per frame
   

    


}
