using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class difficultyChanger : MonoBehaviour
{
    TMP_Text scoreText;
    [SerializeField] float StartSpeed = 1f;
    [SerializeField] float StartSpawnInterval = 2f;
    int score = 0;
    [SerializeField] int EnemiesToChangeSpeed = 5;
    [SerializeField] float changeSpeed = 0.1f;
    [SerializeField] float changeSpawnInterval = 0.1f;

    [SerializeField] float minimumSpawnInterval;
    [SerializeField] float changeSpawnIntervalafter100 = 0.05f;
    [SerializeField] int EnemiesToNewTower = 10;

    [SerializeField] int startTowerLimit = 3;

    public bool isActive = true;

    

    void Update()
    {   
        if(isActive == false)
        return;
        
        scoreText = GameObject.Find("Enemies").GetComponent<TMP_Text>();
        score = int.Parse(scoreText.text);   
        changeDifficulty();
    }

    private void changeDifficulty()
    {    
        SetNewSpeed(CalculateSpeed());
        SetNewSpawnTime(CalculateSpawnTime());
        SetNewTowerLimit(CalculateTowerLimit());
    }

    private void SetNewSpeed(float newSpeed)
    {
        var Enemies = FindObjectsOfType<EnemyMovement>();

        foreach(EnemyMovement enemy in Enemies)
        {   if (enemy)
            enemy.SetSpeed(newSpeed);
        }

    }

    private float CalculateSpeed()
    {
        float speed = StartSpeed + score / EnemiesToChangeSpeed * changeSpeed;

        return speed;
    }

    private float CalculateSpawnTime()
    {   
        var newSpawnInterval = StartSpawnInterval - (score/EnemiesToChangeSpeed)*changeSpawnInterval;
        if(newSpawnInterval > minimumSpawnInterval)
        {
          return newSpawnInterval;
        }
        else if(score > 100)
        {
            return minimumSpawnInterval - changeSpawnIntervalafter100 * (score/EnemiesToChangeSpeed - 10);
        
        }
        else
        {
            return minimumSpawnInterval;
        }
        
        
    }

    private void SetNewSpawnTime(float NewSpawnInterval)
    {   
        var spawner = FindObjectOfType<EnemySpawner>();
        spawner.spawnInterval = NewSpawnInterval;
        
    }

    private int CalculateTowerLimit()
    {
        var newTowerLimit = startTowerLimit + score / EnemiesToNewTower;
        return newTowerLimit;


    }
    private void SetNewTowerLimit(int newTowerLimit)
    {   
        var towerCreator = FindObjectOfType<TowerCreator>();
        towerCreator.towerLimit = newTowerLimit;

    }

    

    

    

    
}
