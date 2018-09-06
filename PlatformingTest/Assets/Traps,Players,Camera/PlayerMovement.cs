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

    Rigidbody RigidRef;

    // Use this for initialization
    void Start () {
		RigidRef = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -20.0f, 0);
    }
	
	// Update is called once per frame
	void Update () {
        bool IsGrounded = Physics.Raycast(transform.position, -transform.up, transform.lossyScale.y + 0.05f);

        if(IsGrounded)
        {
            MovementDir = Vector3.zero;
            MovementDir.x = Input.GetAxis("Horizontal");

            if(Input.GetAxis("Vertical") > 0)
            {
                if(!m_isAxisInUse)
                {
                    RigidRef.AddForce(transform.up * JumpSpeed, ForceMode.VelocityChange);

                    m_isAxisInUse = true;
                }
            }
            else if (Input.GetAxis("Vertical") == 0)
            {
                m_isAxisInUse = false;
            }
        }
        else
        {
            MovementDir.x = Input.GetAxis("Horizontal") * 1.5f;
        }
	}

    void FixedUpdate()
    {
        RigidRef.MovePosition(RigidRef.position + MovementDir * MovementSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.position.y - collision.gameObject.transform.lossyScale.y / 2
            >= transform.position.y + transform.lossyScale.y / 2)
        {
            Vector3 Knockback_Y = RigidRef.velocity;
            Knockback_Y *= -2;

            RigidRef.AddForce(Knockback_Y, ForceMode.VelocityChange);

            PlayerPowerUp PowerUpRef = GetComponent<PlayerPowerUp>();
            if (PowerUpRef != null)
            {
                if(PowerUpRef.GetPowerUp() == POWERUPS.SUPERJUMP)
                {
                    Debug.Log("Instant Die");
                }
            }
        }
    }

    public void SetJumpSpeed(float n_JumpSpeed)
    {
        JumpSpeed = n_JumpSpeed;
    }

    public float GetJumpSpeed()
    {
        return JumpSpeed;
    }
}
