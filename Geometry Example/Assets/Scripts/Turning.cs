using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Turning : MonoBehaviour {

    public float speedTurning;

    private bool canTurn;

    private int isTurn;

    private bool isTurning;

    void Start ()
    {
        //canTurn = true;
        //isTurn = 0;
    }

    void Update()
    {
        if (isTurning)
        {
            transform.Rotate(new Vector3(0, 0, speedTurning));
        }
    }

    //IEnumerator Turn()
    //{
        //canTurn = false;
        //transform.DORotate(new Vector3(0, 0, transform.eulerAngles.z - 90), 0.3f);
        //yield return new WaitForSecondsRealtime(0.3f);
        //canTurn = true;
    //}

    public void CancelTurning()
    {
        isTurning = false;
        int angle = (int)transform.eulerAngles.z;
        //Debug.Log(angle%360);
        if(angle%360 > 270)
        {
            transform.eulerAngles = new Vector3(0, 0, 270);
        }else if(angle%360 > 180)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if(angle % 360 > 90)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 360);
        }
    }

    public void StartTurn()
    {
        isTurning = true;
    }
}
