using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouleMove : MonoBehaviour
{
    public KeyCode Right, Left;
    Vector2 ppos;
    float speedX = 5, speedY = 20;
    int sign;
    float X;
    bool decrease;
    public bool canMove;
    Quaternion rotation;
    void Start()
    {
        ppos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (canMove)
        {
          
            if (Input.GetKey(Right))
            {
              
                decrease = false;
                X += 0.01f;
                if (X > 10)
                    X = 10;
               
            }
            if (Input.GetKey(Left))
            {
                decrease = false;
                X -= 0.01f;
                if (X < -10)
                    X = -10;
            }
            if (Input.GetKeyUp(Left))
                decrease = true;
            if (Input.GetKeyUp(Right))
                decrease = true;
            if(decrease)
                X *= 0.99f;
            if (ppos.x < -11) 
                ppos.x = 11;
            if (ppos.x > 11)
                ppos.x = -11;
            rotation = Quaternion.Euler(0, 0, -X*2);
            gameObject.transform.rotation = rotation;
            ppos.x += X  * Time.deltaTime;
            ppos.y += speedY * Time.deltaTime;
            gameObject.transform.position = ppos;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
            transform.localScale -= new Vector3(0.02f, 0.02f);
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PouleMove>().ppos.x += 30 * X * Time.deltaTime;
            ppos.x -= 10 * X * Time.deltaTime;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            transform.localScale -= new Vector3(0.02f, 0.02f);
            ppos.y -= 0.1f;
            collision.gameObject.SetActive(false);
        }
    }
}
