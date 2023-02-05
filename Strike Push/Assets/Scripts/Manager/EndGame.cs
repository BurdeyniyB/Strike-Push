using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public static EndGame instance;
    [SerializeField] private GameObject Ball;
    [SerializeField] private GameObject Ball_Instantiate;
    [SerializeField] private GameObject Obstacle_Instantiate;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject WinPanel;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    public void LoseGame()
    {
           LosePanel.SetActive(true);
           if(Ball != null)
           {
             Destroy(Ball);
           }

           if(Ball_Instantiate != null)
           {
             Destroy(Ball_Instantiate);
           }
           PlayerPrefs.SetInt("cry", 1);
    }

    public void WinGame()
    {
           WinPanel.SetActive(true);
           Destroy(Ball);
           Destroy(Ball_Instantiate);
           Destroy(Obstacle_Instantiate);
           PlayerPrefs.SetInt("yea", 1);
    }

    public void Restart()
    {
      PlayerPrefs.SetInt("Level manager click", 1);
      SceneManager.LoadScene(0);
    }
}
