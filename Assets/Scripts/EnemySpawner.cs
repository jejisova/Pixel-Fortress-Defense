using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour

{

    
    [SerializeField] float spawnInterval;
    [SerializeField] EnemyMovement enemyPrefab;
    void Start()
    {
        //Запустить сопрограмму 

        StartCoroutine(EnemySpawn());
        

        
    }

    IEnumerator EnemySpawn()
    {

        while(true)
        {   
            
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
