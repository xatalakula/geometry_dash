using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformer : MonoBehaviour {

    public GameObject objectTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Transformer");
            Vector3 pos = other.gameObject.transform.position;
            Instantiate(objectTransform, new Vector3(pos.x-0.1f,pos.y,pos.z), new Quaternion(0,0,0,0));
            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().FindPlayer();
            Destroy(other.gameObject, 0.01f);
        }
    }
}
