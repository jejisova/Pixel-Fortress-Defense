using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class Castle : MonoBehaviour
{
    
    [SerializeField] int playerLife = 10;
    [SerializeField] int damageCount = 1;

    [SerializeField] TextMeshProUGUI textLife;

    [SerializeField] AudioClip CastleDamageFx;
    GameObject afterGameUI;

    AudioSource audioSource;

    void Update()
    {
      
      ExitGame();

    }

    private void ExitGame()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
          Application.Quit();
        }
    }

    void Start()
    {   afterGameUI = GameObject.Find("AfterGameUI");
        afterGameUI.SetActive(false);
        textLife.text = playerLife.ToString();
        audioSource = GetComponent<AudioSource>();


    }

    public void Damage()
    { 
      audioSource.PlayOneShot(CastleDamageFx);
      playerLife = playerLife  - damageCount;
      textLife.text = playerLife.ToString();
       
       if (playerLife <= 0 )
       {
        GameFinish();
       }



    }

     public  void GameFinish()
    {
          StopEnemies();
          StopTowers();
          StopTowerCreator();
          StopdifficultyChanger();
          //StopMusic();
          ShowScore();
        
    }

    private void StopdifficultyChanger()
    {
        var difficultyChanger = FindObjectOfType<difficultyChanger>();
        difficultyChanger.isActive = false;
    }

    private void StopTowerCreator()
    {
        var towerCreator = FindObjectOfType<TowerCreator>();
        towerCreator.isActive = false;
    }

    private void StopTowers()
    {
       var Towers = FindObjectsOfType<Tower>();
       foreach (Tower tower in Towers)
       {
        tower.isActive = false;
       }
    }

    private void StopEnemies()
    {
      var Enemies = FindObjectsOfType<EnemyMovement>();
      foreach(EnemyMovement enemy in Enemies)
      {
        enemy.isActive = false;
      }

      var EnemySpawner = FindObjectOfType<EnemySpawner>();
      EnemySpawner.isActive = false;



    }

    private void ShowScore()
    {
      var gameUI = GameObject.Find("GameUi");
      var EnemiesDestroyedText = GameObject.Find("Enemies");
      
      var EnemiesDestroyed = int.Parse(EnemiesDestroyedText.GetComponent<TMP_Text>().text);
  

      gameUI.SetActive(false);
      afterGameUI.SetActive(true);

      var ResultScore = GameObject.Find("ResultScore");
      ResultScore.GetComponent<TMP_Text>().text = Convert.ToString(EnemiesDestroyed);
      

    }


}
