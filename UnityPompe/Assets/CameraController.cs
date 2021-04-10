using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public LevelManager level;
    public Transform poulePosJ1, poulePosJ2;
    Vector3 pos;
    float speedY = 20;
    void Start()
    {
        pos.z = -10;
    }

    // Update is called once per frame
    void Update()
    {
        if (poulePosJ1.position.y >4 || poulePosJ2.position.y > 4)
        {
            pos.y += speedY * Time.deltaTime;
            gameObject.transform.position = pos;
        }
       
    }
}
