using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed = 8f;

    public GameObject particle;         // particle effect

    bool started;
    bool gameOver;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.instance.StartGame();           // Calling GameManager to StartGame
            }
        }

        // Debug.DrawRay(transform.position, Vector3.down, Color.red);   // Ray visibility

        if(!Physics.Raycast(transform.position, Vector3.down, 1f))          // Ray casting for ball downwards
        {
            rb.velocity = new Vector3(0, -25f, 0);
            gameOver = true;

            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.GameOver();            // Calling GameManager to end the game
        }

        if(Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    private void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider other)         // Ruby collision & particle
    {
        if(other.gameObject.tag == "Ruby")
        {
            GameObject part = Instantiate(particle, other.gameObject.transform.position,        // Storing particle in a GameObject
                Quaternion.identity) as GameObject;

            Destroy(other.gameObject);
            Destroy(part, 0.8f);
        }
    }
}
