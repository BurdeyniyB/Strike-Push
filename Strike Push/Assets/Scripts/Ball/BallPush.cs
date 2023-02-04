using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPush : MonoBehaviour
{
    [HideInInspector] private Rigidbody rb;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject Ball;
    [SerializeField] private GameObject line;
    float distance = 1.1f;

    bool isDragging = false;
    bool NoPush = true;


	void Start()
	{
	  rb = GetComponent<Rigidbody> ();
	  door = GameObject.Find("door");
	  Ball = GameObject.Find("Ball");
	  line = GameObject.Find("Line");

	}

    void Update()
    {
		if (Input.GetMouseButtonDown (0)) {
          Debug.Log("crya");
          if(NoPush)
          {
		    Ball.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
		    transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            isDragging = true;
            line.transform.localScale -= new Vector3(0.005f, 0, -0.00005f);
          }
		}
		if (Input.GetMouseButtonUp (0)) {
          Debug.Log("push");
          if(NoPush)
          {
          OnDrag ();
          isDragging = false;
          NoPush = false;
          }
		}

		if(isDragging)
		{
		  transform.localScale += new Vector3(0.006f, 0.006f, 0.006f);
		  Ball.transform.localScale -= new Vector3(0.006f, 0.006f, 0.006f);
		  line.transform.localScale -= new Vector3(0.0003f, 0, -0.00005f);
		  distance += 0.01f * distance;
		}
    }

	void OnDrag ()
	{
       rb.AddForce(door.transform.forward * 1200f);
       Invoke("InstantiateObject", 1.3f);
       GetComponent <ColisionBall>().distance = distance;
	}
	void InstantiateObject()
	{
	   BallInstance.instance.InstantiateObject();
	}
}
