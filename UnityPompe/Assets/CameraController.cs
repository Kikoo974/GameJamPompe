using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform poulePos;
    Vector3 pos;
    void Start()
    {
        pos.y = poulePos.position.y+1.44f;
        pos.z = -10;
        gameObject.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        pos.y = poulePos.position.y + 1.44f;
        gameObject.transform.position = pos;
    }
}
