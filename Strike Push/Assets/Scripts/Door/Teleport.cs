using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                EndGame.instance.WinGame();
            }
        }
}
