using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreator : MonoBehaviour
{
    [SerializeField] Tower tower;
    

    public void CreateTower(Vector3 position, WayPoint wayPoint )
    {   
        if(wayPoint.isEmpty == true)
        {   
            position = new Vector3(position.x,5,position.z);
            Instantiate(tower, position, Quaternion.identity);
            wayPoint.isEmpty = false;
            
        }
        

    }


}
