using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public Vector3 startingAngle;
    public Vector3 endingAngle;
    private float t;
    private bool swing;
    public AnimationCurve curve;
    //public AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        swing = false;
    }
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.eulerAngles = Vector3.Lerp(startingAngle, endingAngle, curve.Evaluate(t));
    }
}
