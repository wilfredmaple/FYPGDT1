using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnOnCollide : MonoBehaviour {

    [SerializeField]
    private Vector3 ForceDirection;

    [SerializeField]
    private GameObject EnemyToSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
