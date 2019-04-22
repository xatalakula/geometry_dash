using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float minOffset;
    public float lowerBound;
    public float uperBound;

    private GameObject player;
    private float offset;
    private Vector2 velocity;

	// Use this for initialization
	void Start () {
        //player = GameObject.FindGameObjectWithTag("Player");
        FindPlayer();
	}
	
	// Update is called once per frame
	void Update () {
        /*if (player != null){
            offset = transform.position.x - player.transform.position.x;
            if (offset < minOffset)
            {
                transform.position = new Vector3(player.transform.position.x + minOffset, transform.position.y, -10);
            }
        }*/
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x + minOffset, ref velocity.x, 0.05f);
            /*if(player.transform.position.y > 3.5f)
            {
                float posY = Mathf.SmoothDamp(transform.position.y, 1, ref velocity.x, 0.05f);
                transform.position = new Vector3(posX, posY, transform.position.z);
            }
            else if(player.transform.position.y < 0.3f)
            {
                float posY = Mathf.SmoothDamp(transform.position.y, 0, ref velocity.x, 0.05f);
                transform.position = new Vector3(posX, posY, transform.position.z);
            }*/
            transform.position = new Vector3(posX, transform.position.y,transform.position.z);
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, lowerBound, uperBound),
                transform.position.y,transform.position.z);
        }
        
    }

    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
