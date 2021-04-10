using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public LevelManager level;
    public Transform poulePos;
    Vector3 pos;
    float speedY = 20;
    void Start()
    {
        pos.z = -10;
    }

    // Update is called once per frame
    void Update()
    {
        if (level.time <=0)
        {
            pos.y += speedY * Time.deltaTime;
            gameObject.transform.position = pos;
        }
    }
}
