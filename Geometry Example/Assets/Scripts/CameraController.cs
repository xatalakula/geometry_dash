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
        player = GameObject.FindGameObjectWithTag("Player");
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
	}

    void FixedUpdate()
    {
        if (player != null)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x + minOffset, ref velocity.x, 0.05f);
            transform.position = new Vector3(posX, transform.position.y,transform.position.z);
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, lowerBound, uperBound),
                transform.position.y,transform.position.z);
        }
        
    }
}
