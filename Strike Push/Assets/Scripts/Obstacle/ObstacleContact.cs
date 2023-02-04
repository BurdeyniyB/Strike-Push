using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleContact : MonoBehaviour
{
       private Animator anim;

       public void OnCollision()
       {
           anim = GetComponent <Animator> ();
           anim.Play("boom");
           Invoke("Delete", 1.2f);
       }

       void Delete()
       {
         Destroy(this.gameObject);
       }
}
