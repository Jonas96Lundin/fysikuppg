using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    Transform ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rullning>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ball.position;
    }
}
