using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoopers : MonoBehaviour {

    public float speed;
    public float originPosition;
    public float limitPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if(transform.position.x < limitPosition)
        {
            transform.position = new Vector2(originPosition, transform.position.y);
        }
	}
}
