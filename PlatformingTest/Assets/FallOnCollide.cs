using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnCollide : MonoBehaviour {

    private Rigidbody RigidRef;

	// Use this for initialization
	void Start () {
        RigidRef = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            RigidRef.useGravity = true;
        }
    }
}
