using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

    public float powerJump;
    public float maxJumpDistance;
    public float speedMover;
    public float speedTurning;
    public bool canJump;
    public float gravityJump;
    public GameObject explosion;
    public GameObject runEffect;

    private float origin;
    private Rigidbody2D r2d;
    private float posY;
    private float angle;
    private bool canTurn;
    private bool isTurning;

	// Use this for initialization
	void Start () {
        r2d = GetComponent<Rigidbody2D>();
        canJump = false;
        angle = 0;
        canTurn = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            StartCoroutine(Jump());
        }
        /*r2d.AddForce(Vector2.right * speed);
        if(r2d.velocity.x > maxSpeed)
        {
            r2d.velocity = new Vector2(maxSpeed, r2d.velocity.y);
        }*/
        r2d.velocity = new Vector2(speedMover, r2d.velocity.y);
    }

    //fake jump
    IEnumerator Jump()
    {
        r2d.gravityScale = gravityJump;
        canJump = false;
        origin = transform.position.y;
        //StartCoroutine(Turning());
        while (true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + powerJump * Time.deltaTime);
            if(transform.position.y > origin + maxJumpDistance)
            {
                transform.position = new Vector2(transform.position.x,origin + maxJumpDistance);
                break;
            }
            yield return null;
        }
    }

    public void Die()
    {
        Instantiate(explosion, transform.position,transform.rotation);
        Destroy(gameObject);
    }


    IEnumerator Turning()
    {
        if (canTurn)
        {
            //canTurn = false;
            angle = angle - 90;
            Debug.Log(angle);
            transform.DORotate(new Vector3(0, 0, angle), 0.3f);
            yield return new WaitForSecondsRealtime(0.3f);
            //transform.rotation = new Quaternion(0, 0, angle, 1);
            angle = transform.eulerAngles.z;
            //StartCoroutine(WaitToTurn());
        }
    }

    IEnumerator WaitToTurn()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        canTurn = true;
    }

    public void CreateRunEffect()
    {
        Instantiate(runEffect, transform);
    }


    public void DestroyRunEffect()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
