using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Vector2 pos;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        pos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos.x += Time.deltaTime * speed;
        pos.y += Time.deltaTime * 20;
        gameObject.transform.position = pos;

    }
}
