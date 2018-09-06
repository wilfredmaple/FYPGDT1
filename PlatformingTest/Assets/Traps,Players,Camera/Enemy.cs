using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENEMYTYPES
{
    WALK,               // Walk in one direction only
    PATROL,             // Move from one point to another point
    WALKJUMP,           // Jumps in one direction only
    PATROLJUMP,         // Jumps from one point to another point
    HIDDENWALKJUMP,     // Walks in one direction and jumps only when player is in it's detection radius
    HIDDENPATROLJUMP    // Moves from one point to another point and jumps only when player is in it's detection radius
}

public class Enemy : MonoBehaviour {

    [SerializeField]
    private ENEMYTYPES CurrType;

    [SerializeField]
    private Vector3 WalkDirection;

    [SerializeField]
    private float JumpSpeed;

    [SerializeField]
    private GameObject PatrolPointA;
    [SerializeField]
    private GameObject PatrolPointB;
    [SerializeField]
    private bool PatrolToA;

    private bool HiddenOff = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch(CurrType)
        {
            case (ENEMYTYPES.WALK):
                break;
            case (ENEMYTYPES.PATROL):
                break;
            case (ENEMYTYPES.WALKJUMP):
                break;
            case (ENEMYTYPES.PATROLJUMP):
                break;
            case (ENEMYTYPES.HIDDENWALKJUMP):
                if(HiddenOff)
                {

                }
                else
                {

                }
                break;
            case (ENEMYTYPES.HIDDENPATROLJUMP):
                if(HiddenOff)
                {

                }
                else
                {

                }
                break;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (CurrType.ToString().Contains("HIDDEN"))
            {
                HiddenOff = true;
            }
        }
        else
        {
            if (CurrType.ToString().Contains("PATROL"))
            {
                if(other.gameObject == PatrolPointA || other.gameObject == PatrolPointB)
                {

                }
            }
        }
    }
}
