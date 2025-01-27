using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public Vector3 startingAngle; //stores the starting Angle number
    public Vector3 endingAngle; //stores the final Angle number
    private float t; //float to track time that has passed
    public float swing; 
    private bool isSwinging; //determines whether the lantern is swinging
    
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        isSwinging = false; //sets swinging bool to false
    }
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        {
            if (t > swing) //checks if time is greater than one swing cycle
            {
                t = 0; //reset time
                isSwinging = !isSwinging;
            }
            else if (isSwinging) //if the lantern is swinging call firstSwing
            {
                firstSwing();
            }
            else //if the lantern is not swinging call secondSwing
            {
                secondSwing();
            }
        }
        void firstSwing() //first half of the swing
        {
            transform.eulerAngles = Vector3.Lerp(startingAngle, endingAngle, t); //rotates the lantern using lerp based on time
        }
        void secondSwing() //second half of the swing 
        {
            transform.eulerAngles = Vector3.Lerp(endingAngle, startingAngle, t); //rotates the lantern using lerp based on time but reverses the angles so it goes backwards
        }
    }
}
