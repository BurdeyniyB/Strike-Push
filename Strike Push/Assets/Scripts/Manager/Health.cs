using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    [SerializeField] private Text healthText;
    private int health;
    private float size;
    bool health_no_Lose = true;
    void Update()
    {
        if(Ball != null)
        {
         size = Ball.transform.localScale.x;
        }

        health = (int)((size -  0.4f) * 100f / 1.6);
        if(health == 99)
        {
          health = 100;
        }

        if(health < 0)
        {
          health = 0;
        }

        if(health == 0 && health_no_Lose)
        {
          PlayerPrefs.SetInt("cry", 1);
          EndGame.instance.LoseGame();
          health_no_Lose = false;
        }

        healthText.text = health.ToString();
    }
}
