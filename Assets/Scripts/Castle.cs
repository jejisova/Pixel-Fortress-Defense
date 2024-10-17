using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Castle : MonoBehaviour
{
    
    [SerializeField] int playerLife = 10;
    [SerializeField] int damageCount = 1;

    [SerializeField] TextMeshProUGUI textLife;

    
    void Start()
    {
        textLife.text = playerLife.ToString();


    }

    public void Damage()
    {
      playerLife = playerLife  - damageCount;
      textLife.text = playerLife.ToString();


    }
}
