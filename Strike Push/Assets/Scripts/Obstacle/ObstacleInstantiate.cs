using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject ForwardBall;
    [SerializeField] private GameObject Ball;
    [SerializeField] private GameObject ObstacleObj;
    [SerializeField] private GameObject Line;
    [SerializeField] private Transform transfomSession;
    [SerializeField] private List<GameObject> list = new List<GameObject>();
    [SerializeField] private List<GameObject> listLine = new List<GameObject>();
    public int CountObstacle;

    public float minX;
    public float maxX;

    public float minZ;
    public float maxZ;

    bool JumpWhile = true;

    void Start()
    {
        for(int i = 0; i < CountObstacle; i++)
        {
          CreateObj(i);
        }
    }

    void CreateObj(int i)
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(minX, maxX), -2.8f, Random.Range(minZ, maxZ));
        list.Add(Instantiate(ObstacleObj, randomSpawnPosition, Quaternion.identity));
        list[i].transform.SetParent(transfomSession);
        if((list[i].transform.position.x > -(Line.transform.localScale.x * 8f) && list[i].transform.position.x < (Line.transform.localScale.x * 8f)) && (list[i].transform.position.z > 12f && list[i].transform.position.z < 21f))
        {
          listLine.Add(list[i]);
        }
    }

    void Update()
    {
              Debug.Log("line scale = " + Line.transform.localScale.x * 8f);
      for(int i = 0; i < listLine.Count; i++)
      {
        if(listLine[i] == null)
        {
          listLine.Remove(listLine[i]);
          if(listLine.Count == 0)
          {
            EndGame();
          }
        }
        else
        {
          if(listLine[i].transform.position.x < -(Line.transform.localScale.x * 10f) || listLine[i].transform.position.x > (Line.transform.localScale.x * 10f))
          {
            listLine.Remove(listLine[i]);
          }
        }
      }

      if(listLine.Count == 0)
      {
        EndGame();
      }
    }

    void EndGame()
    {
       Debug.Log("endGame");
       GameObject[] enemy;
       enemy = GameObject.FindGameObjectsWithTag("ballPush");

        foreach(GameObject ballPush in enemy)
        {
           Destroy(ballPush);
        }
//      ForwardBall.GetComponent <Rigidbody>().isKinematic = false;
      ForwardBall.GetComponent <Rigidbody>().velocity += new Vector3(0, 0, 0.1f);
      Ball.GetComponent <Animator>().Play("Jump");
//      StartCoroutine(Jump());
    }

//    IEnumerator Jump()
//    {
//      while(JumpWhile)
//      {
//       Ball.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f);
//
//       yield return new WaitForSeconds(0.5f);
//
//       Ball.GetComponent<Rigidbody>().AddForce(Vector3.down * 5f);
//      }
//    }
}