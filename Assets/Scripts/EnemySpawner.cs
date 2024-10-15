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
            Instantiate(enemyPrefab,transform.position,Quaternion.identity);
            
            yield return new WaitForSeconds(spawnInterval);

        }
        
         //Спавинть бесконечно
            //Заспавнить врага
            //Вернуть ничего с ожиданием 1 сек
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


}
