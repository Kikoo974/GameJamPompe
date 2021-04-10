using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PompeScript : MonoBehaviour
{
    public LevelManager level;
    public GameObject pompe;
    public GameObject Poule;
    public float scale = 0.2f;
    public TextMeshPro NbpomperText;
    int nbPomper = 0;
    private Vector2 pos;
    private bool down = false;
    public KeyCode up;
    ParticleSystem waterSpash;
    public int J = 1;
    // Start is called before the first frame update
    void Start()
    {
        pos = pompe.transform.position;
        NbpomperText.text = "" + nbPomper;
        waterSpash = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        if (level.time >= 0)
        {
            if (Input.GetKeyDown(up))
            {

                if (down)
                    pompe.transform.position = pos;
                else
                {
                    Poule.transform.localScale += new Vector3(scale, scale);
                    waterSpash.Play();
                    if (J == 1)
                    {
                        level.PompeJ1(1);
                        NbpomperText.text = "" + level.nbPompJ1;
                    }
                    else
                    {
                        level.PompeJ1(2);
                        NbpomperText.text = "" + level.nbPompJ2;
                    }
                    Vector2 newPos = pos;
                    newPos.y -= 0.83f;
                    pompe.transform.position = newPos;
                }
                down = !down;

            }
        }
    }

}
