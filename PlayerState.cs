using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public Text hpText;
    public int healthPoint = 100;
    public bool isDead = false;
    public Slider slider;
    private void Start()
    {
        hpText.text = "MyHealth : " + healthPoint;
        slider.value = 1.0f;
    }
    public void DamageByEnemy()
    {
        if (isDead) return;
   
        healthPoint--;
        slider.value = (float)healthPoint / 100;
  
        if(healthPoint <= 0)
        {
            hpText.text = "Game Over!";
            SceneManager.LoadScene("Scene4");
            isDead = true;
        }
        else
        {
            hpText.text = "MyHealth : " + healthPoint;
        }
    }
}
