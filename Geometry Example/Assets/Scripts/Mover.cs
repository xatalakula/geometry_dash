using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mover : MonoBehaviour {

    public float speed;
    public bool loop;
    public float distance;

	// Use this for initialization
	void Start () {
        if (loop)
        {
            loopMove();
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
	}

    void loopMove()
    {
        transform.DOMove(new Vector3(transform.position.x, transform.position.y + distance, transform.position.z), 5f).SetLoops(-1, LoopType.Yoyo);
    }
}
