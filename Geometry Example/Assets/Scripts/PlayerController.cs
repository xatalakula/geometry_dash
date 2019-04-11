using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [Header("Jump")]
    public float powerJump;
    public float maxJumpDistance;
    public float gravityJump;
    public Vector2 speedJump;
    public float timeJump;
    [Space(10)]
    [Header("Jump Further")]
    public Vector2 speedJumpFurther;
    public float timeJumpFurther;
    [Space(10)]
    [Header("High Jump")]
    public float powerHighJump;
    public float maxHighJumpDistance;
    public float gravityHighJump;
    public Vector2 speedHighJump;
    public float timeHighJump;
    [Space(10)]
    public float speedMover;
    public float speedTurning;
    public bool canJump;
    public bool isHighJump;
    //public GameObject cube;
    public GameObject explosion;
    public GameObject runEffect;
    public int sceneOrder;
    public bool jumpContinue;

    private float origin1;
    private float origin2;
    private Rigidbody2D r2d;
    private float posY;
    private bool isJumping;
    private Vector2 speed;
    
    

	// Use this for initialization
	void Start () {
        r2d = GetComponent<Rigidbody2D>();
        canJump = false;
        isHighJump = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.J) && canJump)
        {
            StartCoroutine(HighJump());
        }
        if (Input.GetKeyDown(KeyCode.K) && jumpContinue)
        {
            StartCoroutine(JumpFurther());
        }
        if (Input.GetKeyDown(KeyCode.K) && canJump)
        {
            StartCoroutine(Jump());
        }
        if (isJumping && !isHighJump)
        {
            r2d.velocity = speed;
        }else if (isHighJump)
        {
            r2d.velocity = speedHighJump;
        }
        else
        {
            r2d.velocity = new Vector2(speedMover, r2d.velocity.y);
        }
    }

    //fake jump
    IEnumerator Jump()
    {
        isJumping = true;
        r2d.gravityScale = gravityJump;
        canJump = false;
        speed = speedJump;
        yield return new WaitForSecondsRealtime(timeJump);
        r2d.velocity = new Vector2(speedJump.x, -5);
        isJumping = false;
    }

    IEnumerator JumpFurther()
    {
        isJumping = true;
        r2d.gravityScale = gravityJump;
        canJump = false;
        jumpContinue = false;
        speed = speedJumpFurther;
        yield return new WaitForSecondsRealtime(timeJumpFurther);
        r2d.velocity = new Vector2(speedJumpFurther.x, -5);
        isJumping = false;
    }

    IEnumerator HighJump()
    {
        isJumping = true;
        isHighJump = true;
        r2d.gravityScale = gravityJump;
        canJump = false;
        yield return new WaitForSecondsRealtime(timeHighJump);
        r2d.velocity = new Vector2(speedHighJump.x, -5);
        isJumping = false;
        isHighJump = false;
    }

    public void Die()
    {
        Instantiate(explosion, transform.position,transform.rotation);
        Destroy(gameObject);
        SceneManager.LoadScene(sceneOrder);
    }

    public void TurnCube()
    {
        GetComponentInChildren<Turning>().StartTurn();
    }

    public void CancelTurnCube()
    {
        GetComponentInChildren<Turning>().CancelTurning();
    }
    

    public void StartHighJump()
    {
        StartCoroutine(HighJump());
    }

    public void CreateRunEffect()
    {
        canJump = true;
        GetComponent<Rigidbody2D>().gravityScale = 4;
        Instantiate(runEffect, transform);
    }


    public void DestroyRunEffect()
    {
        if (transform.childCount > 1)
        {
            Destroy(transform.GetChild(1).gameObject);
        }
        canJump = false;
    }
}
