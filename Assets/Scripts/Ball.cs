using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Vector2 direction;
    public float speed;
    public int points;
    public Player player;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector2.zero;
        direction = new Vector2(Random.Range(0.5f, 1), Random.Range(0.5f, 1));
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = direction.normalized * speed;
        if(transform.position.x>player.transform.position.x + 1)
        {
            Debug.Log("lose");
            Start();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            direction.x = -direction.x;
            points++;
            Debug.Log(+points);
        }
        if (col.gameObject.CompareTag("TopWall"))
        {
            direction.y = -direction.y;
        }
        if (col.gameObject.CompareTag("BottomWall"))
        {
            direction.y = -direction.y;
        }
        if (col.gameObject.CompareTag("SideWall"))
        {
            direction.x = -direction.x;
        }
    }
}
