using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouleMove : MonoBehaviour
{
    public LevelManager level;
    public KeyCode Right, Left;
    Vector2 ppos;
    float speedX = 5, speedY = 20;
    int sign;
    float X;
  
    void Start()
    {
        ppos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (level.time<0)
        {
            if (Input.GetKey(Right))
            {
                X += 0.01f;
                if (X > 10)
                    X = 10;
               
            }
            if (Input.GetKey(Left))
            {
                X -= 0.01f;
                if (X < -10)
                    X = -10;
            }
            ppos.x += X * Time.deltaTime;
            ppos.y += speedY * Time.deltaTime;
            gameObject.transform.position = ppos;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Obstacle")
            speedY--;
        if (other.collider.tag == "Player")
            ppos.x -= 30 * X  * Time.deltaTime;
    }
}