using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PompeScript : MonoBehaviour
{
    public GameObject pompe;
    public GameObject Poule;
    private Vector2 pos;
    private bool down = false;
    // Start is called before the first frame update
    void Start()
    {
        pos = pompe.transform.position;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            if(down)
                pompe.transform.position = pos;
            else
            {
                Poule.transform.localScale += new Vector3(0.2f, 0.2f);
                Vector2 newPos = pos;
                newPos.y -= 0.83f;
                pompe.transform.position = newPos;
            }
            down = !down;
           
        }
            
    }
}
