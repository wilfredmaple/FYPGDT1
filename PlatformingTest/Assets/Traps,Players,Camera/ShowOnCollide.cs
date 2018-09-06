﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnCollide : MonoBehaviour {

    private Renderer RendRef;

	// Use this for initialization
	void Start () {
        RendRef = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        if(!RendRef.isVisible)
        {
            if (Player.transform.position.y + Player.transform.lossyScale.y / 2 > transform.position.y - transform.lossyScale.y / 2)
            {
                Physics.IgnoreCollision(Player.GetComponent<CharacterController>(), GetComponent<Collider>());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.transform.position.y + other.gameObject.transform.lossyScale.y / 2
                <= transform.position.y - transform.lossyScale.y / 2)
            {
                if(!RendRef.isVisible)
                {
                    Physics.IgnoreCollision(other.GetComponent<CharacterController>(), GetComponent<Collider>(), false);

                    Vector3 Reversed = other.GetComponent<PlayerMovement>().GetMovementDir();
                    Reversed.y = -Reversed.y;
                    other.GetComponent<PlayerMovement>().SetMovementDir(Reversed);
                    RendRef.enabled = true;
                }
                else
                {
                    Vector3 Reversed = other.GetComponent<PlayerMovement>().GetMovementDir();
                    Reversed.y = -Reversed.y;
                    other.GetComponent<PlayerMovement>().SetMovementDir(Reversed);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Debug.Log("Test");
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>(), false);
        }
    }
}