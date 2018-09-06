using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnCollide : MonoBehaviour {

    private Rigidbody RigidRef;

	// Use this for initialization
	void Start () {
        RigidRef = GetComponent<Rigidbody>();
        RigidRef.constraints = RigidbodyConstraints.FreezeAll;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            RigidRef.useGravity = true;
            RigidRef.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && RigidRef.useGravity)
        {
            if (other.gameObject.transform.position.y + other.gameObject.transform.lossyScale.y / 2
                <= transform.position.y - transform.lossyScale.y / 2)
            {
                Debug.Log("Die Player!");
            }
        }
    }
}
