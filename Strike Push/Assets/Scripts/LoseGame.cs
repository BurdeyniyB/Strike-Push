using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    void Update()
    {
        if(Ball.transform.localScale.x < 0.4)
        {
           SceneManager.LoadScene(0);
        }
    }
}
