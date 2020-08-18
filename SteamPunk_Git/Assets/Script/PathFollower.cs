using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollower : MonoBehaviour
{
    public PathCreator pathCreator1, pathCreator2, pathCreator3;
    public EndOfPathInstruction end;
    float speed = 3;
    int gear = 0;
    float dstTravelled;
    int whichPath = 0;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        whichPath = 1;
        direction = 1;
        dstTravelled = 1f;

        speed = 3;
        gear = 0;
    }

    void FixedUpdate()
    {
        if (transform.position == pathCreator1.path.GetPoint(0))
        {
            direction *= -1;
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
            direction *= -1;
            dstTravelled -= 0.1f;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (gear < 3)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                gear++;
            }
        }
        if (gear > -3)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                gear--;
            }
        }

        Debug.Log(gear);
    }
}
