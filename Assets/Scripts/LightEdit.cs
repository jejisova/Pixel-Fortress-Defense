using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class LightEdit : MonoBehaviour
{   [SerializeField][Range(100,200)] int frequency;
    [SerializeField] float waitingtime;
    
    void Start()
    {
      
    }
    void Update()
    {   
        
        StartCoroutine(Scale());
        
    }

    IEnumerator Scale()
    {  
       float count = 0;
       while(count < waitingtime*frequency)
       {
        transform.localScale = new Vector3(0.1f,0.1f,0.1f);
        count++;
        yield return new WaitForSeconds(waitingtime/frequency);

       }
       while(count < waitingtime*frequency)
       { 
        transform.localScale = new Vector3(1.1f,1.1f,1.1f);
        count++;
        yield return new WaitForSeconds(waitingtime/frequency);

       }

       

    }



}
