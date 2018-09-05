using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Vector3 MovementDir;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CharacterController ControlRef = GetComponent<CharacterController>();
        if(ControlRef.isGrounded)
        {
            MovementDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            MovementDir = transform.TransformDirection(MovementDir);
            MovementDir *= 5;

            if(Input.GetAxis("Vertical") > 0)
            {
                MovementDir.y = 10.0f;
                MovementDir.x *= 1.5f;
            }
        }
        else
        {
            MovementDir.x = Mathf.Lerp(MovementDir.x, 0, Time.deltaTime);
        }

        MovementDir.y -= 20.0f * Time.deltaTime;
        ControlRef.Move(MovementDir * Time.deltaTime);
	}

    public Vector3 GetMovementDir()
    {
        return MovementDir;
    }

    public void SetMovementDir(Vector3 n_MovementDir)
    {
        MovementDir = n_MovementDir;
    }
}
