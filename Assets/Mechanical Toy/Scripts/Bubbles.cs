using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    public AnimationCurve curve;
    private bool isStarted; //indicates if bubbles have started
    private Vector2 bubbleSize; //holds size of the bubbles

    private float popTime; //duration for the bubbles to pop before resetting
    public float t; //where along we are in popTime
    // Start is called before the first frame update
    void Start()
    {
        t = 0; //sets time variable to 0
        isStarted = false;
        newBubbleSize(); //calls function and generates a new random bubble
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Starts the bubbles if mouse button is held down
        {
            isStarted = true;
        }
        if (Input.GetMouseButtonUp(0)) //Ends the bubbles if the mouse button is released
        {
            isStarted = false;
        }
        if (t > popTime) //if time is greater than popTime it resets the time and generates a new bubble
        {
            t = 0;
            newBubbleSize();
        }
        if (isStarted) //if the bubbles have started update the bubbles
        {
            transform.localScale = bubbleSize * curve.Evaluate(t / popTime); //size of the bubble based on current time and the animation curve
            t += Time.deltaTime;
        }
    }
    void newBubbleSize() //new function that creates a new bubble
    {
        float temp = Random.Range(0.8f, 1.9f); //generates random size for the bubble from 0.8 to 1.9
        bubbleSize = new Vector2(temp, temp);
        popTime = Random.Range(1f, 1.6f); //generates random time for bubbles to pop between 1 and 1.6 seconds
    }
}
