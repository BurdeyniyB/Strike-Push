using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInstance : MonoBehaviour
{
    public static BallInstance instance;
    [SerializeField] private GameObject SpawnObjPrefab;
    [SerializeField] private Transform transformInstantiate;

	void Awake () {
        if (instance == null)
            instance = this;
	}

    void Start()
    {
        InstantiateObject();
    }

    public void InstantiateObject()
    {
        Instantiate(SpawnObjPrefab, transformInstantiate);
    }
}
