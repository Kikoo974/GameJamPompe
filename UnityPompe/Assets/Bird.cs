using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Vector2 pos;
    public float speed = 1;
    float speedY;
    // Start is called before the first frame update
    void Start()
    {
        pos = gameObject.transform.position;
        speedY = 20;
    }

    // Update is called once per frame
    void Update()
    {
        pos.x += Time.deltaTime * speed;
        pos.y += Time.deltaTime * speedY;
        gameObject.transform.position = pos;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destroy")
            Destroy(gameObject);
    }
}
