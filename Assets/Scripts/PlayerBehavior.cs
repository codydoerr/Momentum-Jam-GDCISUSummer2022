using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    bool paused;

    public float power;

    public int thresholdTriggerTwo;
    public int thresholdTriggerThree;
    public Rigidbody2D rb;
    public LineRenderer lr;

    public GameManager gM;

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
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        lr = GetComponent<LineRenderer>();
        cam = Camera.main;

        moving = false;
        hit = false;

        curStamina = maxStamina;

        maxPower = new Vector2(Stats.GetMomentum(), Stats.GetMomentum());
        minPower = maxPower * -1;

        maxStamina = Stats.GetStamina();
        curStamina = maxStamina;
        startLocation = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !moving && !paused)
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            Debug.Log(startPoint);
        }

        if (Input.GetMouseButtonUp(0) && !moving && !paused)
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(endPoint);
            float distance = Vector3.Distance(Camera.main.ScreenToWorldPoint(startPoint), Camera.main.ScreenToWorldPoint(endPoint));
            Debug.Log(distance);
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));

            rb.AddForce(force * power, ForceMode2D.Impulse);
            moving = true;
            curStamina--;
            if(curStamina <= 0 && (rb.velocity.x < .05 && rb.velocity.y < .05))
            {
                Debug.Log("Ran Out of Stamina");
                gM.LoseGame();
            }
        }
        if (Input.GetMouseButton(0) && !paused && !moving)
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            RenderLine(startPoint, currentPoint);
        }
        else
        {
            EndLine();
        }
        if (rb.velocity.x < .05 && rb.velocity.y < .05)
        {
            moving = false;
            hit = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            paused = true;
            Time.timeScale = 0;
            gM.PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            Time.timeScale = 1;
            paused = false;
            gM.PauseGame();
        }
    }
    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {//need to make it reference global coordinates and not local
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;
        lr.SetPositions(points);
        if ((Vector2.Distance(startPoint, endPoint)) > thresholdTriggerThree && Stats.GetMomentum() > 40f)
        {
            lr.startColor = Color.red;
        }
        else if ((Vector2.Distance(startPoint, endPoint)) > thresholdTriggerTwo && Stats.GetMomentum() > 25f)
        {
            lr.startColor = Color.yellow;
        }
        else
        {
            lr.startColor = Color.green;
        }
    }
    public void EndLine()
    {
        lr.positionCount = 0;
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
            gM.WinGame();
        }
    }
}
