using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerDuo : MonoBehaviour
{
    public LevelManagerDuo level;
    public Transform poulePosJ1;
    Vector3 pos;
    float speedY = 20;
    void Start()
    {
        pos.z = -10;
    }

    // Update is called once per frame
    void Update()
    {
        if (poulePosJ1.position.y >3.5)
        {
            pos.y += speedY * Time.deltaTime;
            gameObject.transform.position = pos;
        }
       
    }
}
