using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject Start_Button;

    public void StartControler()
    {
        BallInstance.instance.InstantiateObject();
        Start_Button.SetActive(false);
    }
}
