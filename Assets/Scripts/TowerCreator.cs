using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class TowerCreator : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] public int towerLimit = 4;

    public bool isActive = true;
    
    Tower newTower;
    

    Queue<Tower> TowerQueue = new Queue<Tower>();

    Dictionary<Tower,WayPoint> TowersWaypoints = new Dictionary<Tower, WayPoint>();
    
    public void Update()
    {   
        if(isActive == false)
        return;

        DisplayTowerLimit();

    }

    private void DisplayTowerLimit()
    {   
        
        var textTowerLimit = GameObject.Find("TowerLimit");
        var textMeshPro = textTowerLimit.GetComponent<TextMeshProUGUI>();
        textMeshPro.text = Convert.ToString(towerLimit - TowerQueue.Count);
    }

    public void CreateTower(Vector3 position, WayPoint wayPoint )

    {    
         position = new Vector3(position.x,5,position.z);
              
        int towerCount = 0;
        towerCount = TowerQueue.Count;

        if(wayPoint.isPlaceble == true && towerCount < towerLimit)
        {   
            towerInstantiate(position,wayPoint);
            

        }
        else
        {   

            MoveTowerPosition(position, wayPoint);
        }

        FindObjectOfType<EnemySpawner>().StartGame();
        
        

    }

    

    private void towerInstantiate(Vector3 position,WayPoint wayPoint)
    { 
        newTower = Instantiate(tower, position, Quaternion.identity);
        newTower.transform.parent = transform;
        wayPoint.isPlaceble = false;
        TowersWaypoints.Add(newTower,wayPoint);   
        TowerQueue.Enqueue(newTower);

             
    }

    private void MoveTowerPosition(Vector3 position, WayPoint wayPoint)
    {   

        Tower oldTower = TowerQueue.Dequeue();
        TowersWaypoints[oldTower].isPlaceble = true;
        TowerQueue.Enqueue(oldTower);
        TowersWaypoints[oldTower] = wayPoint;
        TowersWaypoints[oldTower].isPlaceble = false;
        oldTower.transform.position = position;
     

                        
    }




}
