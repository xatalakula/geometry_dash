using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [Header("Jump")]
    public Vector2 speedJump;
    public float timeJump;
    [Space(10)]
    [Header("Jump Further")]
    public Vector2 speedJumpFurther;
    public float timeJumpFurther;
    [Space(10)]
    [Header("High Jump")]
    public Vector2 speedHighJump;
    public float timeHighJump;
    [Space(10)]
    [Header("Flying")]
    public bool isFlying;
    public Vector2 powerFly;
    [Space(10)]
    [Header("General Parameters")]
    public GameObject explosion;
    public GameObject runEffect;
    public GameObject completeEffect;
    public float speedMover;
    public bool canJump;
    public bool isHighJump;
    public bool jumpContinue;
    

    private Rigidbody2D r2d;
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
        if (isFlying)
        {
            if (Input.GetKey(KeyCode.K))
            {
                Fly();
            }
        }
        else
        {
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
        canJump = false;
        speed = speedJump;
        yield return new WaitForSecondsRealtime(timeJump);
        r2d.velocity = new Vector2(speedJump.x, -5);
        isJumping = false;
    }

    IEnumerator JumpFurther()
    {
        isJumping = true;
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
        canJump = false;
        yield return new WaitForSecondsRealtime(timeHighJump);
        r2d.velocity = new Vector2(speedHighJump.x, -5);
        isJumping = false;
        isHighJump = false;
    }

    public void Die()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().StartRepeatScene();
        Instantiate(explosion, transform.position,transform.rotation);
        Destroy(gameObject);
        //SceneManager.LoadScene(sceneOrder);
        //StartCoroutine(RepeatLevel());
    }

    public void TurnCube()
    {
        if (GetComponentInChildren<Turning>() != null)
            GetComponentInChildren<Turning>().StartTurn();
    }

    public void CancelTurnCube()
    {
        if(GetComponentInChildren<Turning>()!=null)
        GetComponentInChildren<Turning>().CancelTurning();
    }
    

    public void StartHighJump()
    {
        StartCoroutine(HighJump());
    }

    public void CreateRunEffect()
    {
        if (!isFlying)
        {
            canJump = true;
            GetComponent<Rigidbody2D>().gravityScale = 4;
            Instantiate(runEffect, transform);
        }
    }


    public void DestroyRunEffect()
    {
        if (!isFlying)
        {
            if (transform.childCount > 1)
            {
                Destroy(transform.GetChild(1).gameObject);
            }
            canJump = false;
        }
    }

    public void Fly()
    {
        r2d.AddForce(powerFly);
    }

    public void CreateCompleteEffect()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<UIManager>().ShowPauseMenu(true);
        GameObject effect = Instantiate(completeEffect) as GameObject;
        effect.transform.position = gameObject.transform.position;
        Destroy(gameObject, 0.01f);
    }
}
