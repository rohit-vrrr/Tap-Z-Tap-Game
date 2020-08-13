using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject ball;   // target GameObject to follow

    Vector3 offset;   // distance between camera and ball

    public float lerpRate;   // rate at which cam will change its pos to follow the ball
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        offset = ball.transform.position - transform.position;   // sub pos of cam from pos of ball to get dist
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            Follow();
        }
    }

    private void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 ballPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, ballPos, lerpRate * Time.deltaTime);   // Time.deltaTime runs scene in all computers
        transform.position = pos;
    }
}
