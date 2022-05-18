using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public enum EnemyType {Destroy,Bumper,Stopper};
    public EnemyType enemyType;

    public GameObject target;

    public int score = 10;
    public float power = 5;

    public GameManager gM;

    private void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehavior>() != null && enemyType == EnemyType.Destroy)
        {
            if (Stats.GetMomentum() > 40f)
            {
                if (!collision.gameObject.GetComponent<PlayerBehavior>().hit)
                {
                    Destroy(gameObject);
                    gM.AddScore(score);
                    collision.gameObject.GetComponent<PlayerBehavior>().hit = true;
                }else if (!collision.gameObject.GetComponent<PlayerBehavior>().hitTwo)
                {
                    Destroy(gameObject);
                    gM.AddScore(score);
                    collision.gameObject.GetComponent<PlayerBehavior>().hitTwo = true;
                }
                else if (!collision.gameObject.GetComponent<PlayerBehavior>().hitThree)
                {
                    Destroy(gameObject);
                    gM.AddScore(score);
                    collision.gameObject.GetComponent<PlayerBehavior>().hitThree = true;
                }
                else
                {
                    Debug.Log("Reset to Start");
                    collision.gameObject.GetComponent<PlayerBehavior>().Reset();
                }
            }
            else if (Stats.GetMomentum() > 25f)
            {
                if (!collision.gameObject.GetComponent<PlayerBehavior>().hit)
                {
                    Destroy(gameObject);
                    gM.AddScore(score);
                    collision.gameObject.GetComponent<PlayerBehavior>().hit = true;
                }
                else if (!collision.gameObject.GetComponent<PlayerBehavior>().hitTwo)
                {
                    Destroy(gameObject);
                    gM.AddScore(score);
                    collision.gameObject.GetComponent<PlayerBehavior>().hitTwo = true;
                }
                else
                {
                    Debug.Log("Reset to Start");
                    collision.gameObject.GetComponent<PlayerBehavior>().Reset();
                }
            }
            else
            {
                if (!collision.gameObject.GetComponent<PlayerBehavior>().hit)
                {
                    Destroy(gameObject);
                    gM.AddScore(score);
                    collision.gameObject.GetComponent<PlayerBehavior>().hit = true;
                }
                else
                {
                    Debug.Log("Reset to Start");
                    collision.gameObject.GetComponent<PlayerBehavior>().Reset();
                }
            }
        }
        if (collision.gameObject.GetComponent<PlayerBehavior>() != null && enemyType == EnemyType.Stopper)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Debug.Log("Stopped");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehavior>() != null && enemyType == EnemyType.Bumper)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((target.transform.position-transform.position) * power, ForceMode2D.Impulse);
            Debug.Log("Bumpy");
        }
    }
}
