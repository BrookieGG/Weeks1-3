using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public Vector2 starting; //starting position
    public Vector2 ending; //ending position
    public float timeToMove;
    public float timeToPause;
    public AnimationCurve curveForward;
    private float currentTime; //keep track of time
    private bool isMovingForward; //movement direction
    private bool isMovingBackward; //movement direction
    private bool isPaused; //pause state of object

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        isMovingForward = true;
        isMovingBackward = false;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; 
        if (isPaused) //if the object is paused
        {
            if (currentTime > timeToPause)
            {
                currentTime = 0; //reset time to 0
                isMovingForward = !isMovingForward; 
                isPaused = false; //unpause the object
                transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 0)); //flip the object on the X-axis
            }
            return;
        }
        else if (isMovingForward) //if object is moving forward call the firstMove function
        {
            firstMove();

        }
        else
        {
            secondMove(); //if object is not moving forward call the secondMove function
        }
        if (currentTime > timeToMove) //reset the current time and pause the object if mouse has reached the destination
        {
            currentTime = 0; //reset time to 0
            isPaused = true; //pause the object

        }
    }

    void firstMove()
    { //move the object from starting position to ending position using an animation curve
        transform.position = Vector2.Lerp(starting, ending, curveForward.Evaluate(currentTime));
    }
    void secondMove()
    { //move the object from ending position to starting position using an animation curve
        transform.position = Vector2.Lerp(ending, starting, curveForward.Evaluate(currentTime));
    }
}
