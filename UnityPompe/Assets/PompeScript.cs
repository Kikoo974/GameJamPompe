using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PompeScript : MonoBehaviour
{
    public GameObject pompe;
    public GameObject Poule;
    public LevelManager levelManager;
    public float scale = 0.2f;
    public TextMeshPro NbpomperText;
    int nbPomper = 0;
    private Vector2 pos;
    private bool down = false;
    // Start is called before the first frame update
    void Start()
    {
        pos = pompe.transform.position;
        NbpomperText.text = "" + nbPomper;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (levelManager.time > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (down)
                    pompe.transform.position = pos;
                else
                {
                    Poule.transform.localScale += new Vector3(scale, scale);
                    nbPomper += 1;
                    NbpomperText.text = "" + nbPomper;
                    Vector2 newPos = pos;
                    newPos.y -= 0.83f;
                    pompe.transform.position = newPos;
                }
                down = !down;

            }
        }
        else
            Poule.transform.position += new Vector3(Random.Range(-0.5f, 0.5f) * Time.deltaTime, 0.1f, 0);


    }
}
