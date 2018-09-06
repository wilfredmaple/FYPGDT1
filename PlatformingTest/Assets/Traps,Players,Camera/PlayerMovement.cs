using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private float JumpSpeed;
    private Vector3 MovementDir;
    private bool m_isAxisInUse = false;

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
            MovementDir *= MovementSpeed;

            if(Input.GetAxis("Vertical") > 0)
            {
                if (!m_isAxisInUse)
                {
                    MovementDir.y = 10.0f;
                    m_isAxisInUse = true;
                }
            }
            else
            {
                m_isAxisInUse = false;
            }
        }
        else
        {
            MovementDir.x = Input.GetAxis("Horizontal") * MovementSpeed * 1.5f;
            MovementDir = transform.TransformDirection(MovementDir);
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
