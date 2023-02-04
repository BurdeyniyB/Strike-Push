using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionBall : MonoBehaviour
{
        [SerializeField] private GameObject BallPush;
        [SerializeField] private GameObject[] enemy;
        public float distance;

        void OnCollisionEnter(Collision col)
        {
            Debug.Log("collision.gameObject.tag ==" + col.gameObject.tag);
            if (col.gameObject.tag == "Obstacle")
            {
               BallPush.GetComponent<Rigidbody> ().isKinematic = true;
               enemy = GameObject.FindGameObjectsWithTag("Obstacle");
               foreach(GameObject ObstacleObj in enemy)
               {
                 if(Vector3.Distance(ObstacleObj.transform.position, transform.position) < distance)
                 {
                   ObstacleObj.GetComponent <ObstacleContact>().OnCollision();
                 }
               }
               Invoke("Delete", 1.2f);
            }

            if (col.gameObject.tag == "door")
            {
               BallInstance.instance.InstantiateObject();
               Destroy(BallPush);
            }
        }


       void Delete()
       {
         Destroy(BallPush);
       }
}
