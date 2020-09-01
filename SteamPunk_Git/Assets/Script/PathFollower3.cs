using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollower3 : MonoBehaviour
{
    public PathCreator pathCreator1, pathCreator2, pathCreator3, pathCreator4;
    public EndOfPathInstruction end;
    float speed = 10;
    int gear = 0;
    bool gearForward = true;
    float dstTravelled;
    int whichPath = 0;
    int direction = 1;

    //public GameObject arrow1, arrow2;

    // Start is called before the first frame update
    void Start()
    {
        whichPath = 1;
        direction = 1;
        dstTravelled = 10f;

        speed = 8;
    }

    void FixedUpdate()
    {
        if (transform.position == pathCreator1.path.GetPoint(0))
        {
            whichPath = 4;
            dstTravelled = 0.1f;
        }
        else if (transform.position == pathCreator1.path.GetPoint(2))
        {
            whichPath = 2;
            dstTravelled = 0.1f;
        }
        else if (transform.position == pathCreator2.path.GetPoint(0))
        {
            whichPath = 1;
            dstTravelled = 36.5f;
        }
        else if (transform.position == pathCreator2.path.GetPoint(2))
        {
            whichPath = 3;
            dstTravelled = 0.1f;
        }
        else if (transform.position == pathCreator3.path.GetPoint(0))
        {
            whichPath = 2;
            dstTravelled = 36.5f;
        }
        else if (transform.position == pathCreator3.path.GetPoint(2))
        {
            whichPath = 4;
            dstTravelled = 0.1f;
        }
        else if (transform.position == pathCreator4.path.GetPoint(0))
        {
            whichPath = 3;
            dstTravelled = 36.5f;
        }
        else if (transform.position == pathCreator4.path.GetPoint(2))
        {
            whichPath = 1;
            dstTravelled = 0.1f;
        }

        /**///important!
        dstTravelled += speed * gear * direction * Time.deltaTime;
        /**/

        if (whichPath == 1)
        {
            transform.position = pathCreator1.path.GetPointAtDistance(dstTravelled, end);
        }
        else if (whichPath == 2)
        {
            transform.position = pathCreator2.path.GetPointAtDistance(dstTravelled, end);
        }
        else if (whichPath == 3)
        {
            transform.position = pathCreator3.path.GetPointAtDistance(dstTravelled, end);
        }
        else if (whichPath == 4)
        {
            transform.position = pathCreator4.path.GetPointAtDistance(dstTravelled, end);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gearForward = !gearForward;
        }

        switch (gearForward)
        {
            case true:
                {
                    gear = 1;
                    //arrow1.SetActive(true);
                    //arrow2.SetActive(false);
                    break;
                }
            case false:
                {
                    gear = -1;
                    //arrow1.SetActive(false);
                    //arrow2.SetActive(true);
                    break;
                }
        }
    }
}
