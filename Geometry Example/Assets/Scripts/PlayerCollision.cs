using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    PlayerController playerController;

	// Use this for initialization
	void Start () {
        playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            playerController.CancelTurnCube();
            playerController.CreateRunEffect();
        }
        else if (other.gameObject.CompareTag("SandHighJump"))
        {
            playerController.StartHighJump();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            playerController.Die();
        }
        else if (other.gameObject.CompareTag("WallEnd"))
        {
            playerController.CreateCompleteEffect();
        }
        
    }

    

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            playerController.TurnCube();
        }
        playerController.DestroyRunEffect();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "JumpSymbol")
        {
            playerController.jumpContinue = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "JumpSymbol")
        {
            playerController.jumpContinue = false;
        }
    }
}
