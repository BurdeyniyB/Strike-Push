using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleContact : MonoBehaviour
{
       private Animator anim;
       GameObject BallPush;

       public void OnCollision()
       {
           anim = GetComponent <Animator> ();
           anim.Play("boom");
           //Invoke("Delete", 1.2f);
           StartCoroutine(Delete());
       }

       IEnumerator Delete()
       {
         yield return new WaitForSeconds(1f);
         PlayerPrefs.SetInt("boom", 1);
         yield return new WaitForSeconds(0.2f);
         Destroy(this.gameObject);
       }
}