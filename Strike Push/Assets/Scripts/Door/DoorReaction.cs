using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReaction : MonoBehaviour
{
     private Animator anim;
     [SerializeField] private GameObject ball;

     void Update()
     {
       if(ball != null && Vector3.Distance(ball.transform.position, transform.position) < 5f)
       {
         GetComponent <Animator> ().Play("doorOpen");
       }
     }
}
