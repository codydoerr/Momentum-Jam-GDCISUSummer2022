using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public int maxStamina;
    public int curStamina;

    public bool moving;
    public bool hit;

    public GameObject arrowParent;
    public GameObject arrowBody;


    public Vector2 minPower;
    public Vector2 maxPower;

    public Vector3 startLocation;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    private void Start()
    {
        cam = Camera.main;

        moving = false;
        hit = false;

        curStamina = maxStamina;

        maxPower = new Vector2(Stats.GetMomentum(), Stats.GetMomentum());
        minPower = maxPower * -1;

        maxStamina = Stats.GetStamina();

        startLocation = transform.position;





    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !moving)
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(startPoint);
        }
        if (Input.GetMouseButtonUp(0) && !moving)
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(endPoint);
            float distance = Vector3.Distance(Camera.main.ScreenToWorldPoint(startPoint), Camera.main.ScreenToWorldPoint(endPoint));
            Debug.Log(distance);
            if (distance > .05f) { 
                force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
                rb.AddForce(force * power, ForceMode2D.Impulse);
                moving = true;
                curStamina--;
                if(curStamina <= 0)
                {
                    Debug.Log("Ran Out of Stamina");
                    // pop up lose screen
                }
            }
        }
        if (rb.velocity.x < .05 && rb.velocity.y < .05)
        {
            moving = false;
            hit = false;
        }

    }
    public void Reset()
    {
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = startLocation;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            Debug.Log("Level Complete");
            //win game
            //bring up rewards
            //go to menu
        }
    }
}
