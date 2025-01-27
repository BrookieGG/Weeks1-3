using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public Vector3 startingAngle;
    public Vector3 endingAngle;
    private float t;
    public float swing;
    private bool isSwinging;
    
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        isSwinging = false;
    }
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        {
            if (t > swing)
            {
                t = 0;
                isSwinging = !isSwinging;
            }
            else if (isSwinging)
            {
                firstSwing();
            }
            else
            {
                secondSwing();
            }
        }
        void firstSwing()
        {
            transform.eulerAngles = Vector3.Lerp(startingAngle, endingAngle, t);
        }
        void secondSwing()
        {
            transform.eulerAngles = Vector3.Lerp(endingAngle, startingAngle, t);
        }
    }
}
