using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    public float timeLife;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, timeLife);
	}
}
