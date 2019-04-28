using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

    public Color[] colors;
    public bool changeByTime;
    private int order;

	// Use this for initialization
	void Start () {
        order = 0;
        if (changeByTime)
        {
            StartCoroutine(ChangeMusicByTime());
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("color change");
            GetComponent<SpriteRenderer>().color = colors[order];
            if(order<colors.Length-1)
            order++;
        }
        
    }

    IEnumerator ChangeMusicByTime()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(8f);
            /*for(int i = 0; i < 5; i++)
            {
                transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = colors[order];
            }*/
            GetComponent<SpriteRenderer>().color = colors[order];
            if (order < colors.Length - 1)
                order++;
            else order = 0;
            //yield return new WaitForSecondsRealtime(8f);
        }
    }
}
