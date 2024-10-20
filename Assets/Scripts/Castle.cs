using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Castle : MonoBehaviour
{
    
    [SerializeField] int playerLife = 10;
    [SerializeField] int damageCount = 1;

    [SerializeField] TextMeshProUGUI textLife;

    [SerializeField] AudioClip CastleDamageFx;

    AudioSource audioSource;

    
    void Start()
    {
        textLife.text = playerLife.ToString();
        audioSource = GetComponent<AudioSource>();


    }

    public void Damage()
    { 
      audioSource.PlayOneShot(CastleDamageFx);
      playerLife = playerLife  - damageCount;
      textLife.text = playerLife.ToString();


    }
}
