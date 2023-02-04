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
       if(Input.touchCount > 0)
       {
		if (Input.GetTouch(0).phase == TouchPhase.Began) {
          Debug.Log("crya");
          if(NoPush)
          {
		    Ball.transform.localScale -= new Vector3(0.07f, 0.07f, 0.07f);
		    transform.localScale += new Vector3(0.07f, 0.07f, 0.07f);
            isDragging = true;
            line.transform.localScale -= new Vector3(0.007f, 0, -0.00007f);
          }
		}
		if (Input.GetTouch(0).phase == TouchPhase.Ended) {
          Debug.Log("push");
          if(NoPush)
          {
          isDragging = false;
          NoPush = false;
          OnDrag ();
          }
		}
		}
		if(isDragging)
		{
		  transform.localScale += new Vector3(0.008f, 0.008f, 0.008f);
		  Ball.transform.localScale -= new Vector3(0.008f, 0.008f, 0.008f);
		  line.transform.localScale -= new Vector3(0.0005f, 0, -0.00007f);
		  distance += 0.0085f * distance;
		}
    }

	void OnDrag ()
	{
       rb.AddForce(door.transform.forward * 1200f);
       Invoke("InstantiateObject", 1.2f);
       GetComponent <ColisionBall>().distance = distance;
	}
	void InstantiateObject()
	{
	   BallInstance.instance.InstantiateObject();
	}
}
