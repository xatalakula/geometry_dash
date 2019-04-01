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
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 4;
            playerController.CreateRunEffect();
            playerController.canJump = true;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            playerController.Die();
        }
        
    }

    

    void OnCollisionExit2D(Collision2D other)
    {
        /*if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("1234");
            GetComponent<PlayerController>().Turning();
        }*/
        playerController.DestroyRunEffect();
        playerController.canJump = false;
    }
}
