using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDeleteObstacle : MonoBehaviour
{
    [SerializeField] private string Tag;
    [SerializeField] private float distance;
    [SerializeField] private GameObject[] enemy;
     void Update()
     {
        enemy = GameObject.FindGameObjectsWithTag(Tag);
        foreach(GameObject ObstacleObj in enemy)
         {
           if(Vector3.Distance(ObstacleObj.transform.position, transform.position) < distance)
             {
               Debug.Log("Destroy for door");
               Destroy(ObstacleObj);
             }
        }
     }
}
