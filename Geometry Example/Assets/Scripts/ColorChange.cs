using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    public Color[] colors;
    private int order;

	// Use this for initialization
	void Start () {
        order = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("color change");
            GetComponent<SpriteRenderer>().color = colors[order];
            if(order<2)
            order++;
        }
        
    }
}
