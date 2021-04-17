using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class PompeScript : MonoBehaviour
{
    public LevelManagerDuo level;
    public GameObject pompe;
    public GameObject Poule;
    public Animator renard; 
    public float scale = 0.2f;
    public TextMeshPro NbpomperText;
    int nbPomper = 0;
    private Vector2 pos;
    private bool down = false;
    public KeyCode up;
    ParticleSystem waterSpash;
    public int J = 1;
     AudioSource[] sounds;
     AudioSource exp;
     AudioSource insp;





    // Start is called before the first frame update
    void Start()
    {
        pos = pompe.transform.position;
        NbpomperText.text = "" + nbPomper;
        waterSpash = gameObject.GetComponentInChildren<ParticleSystem>();
        sounds = gameObject.GetComponents<AudioSource>();
        insp = sounds[0];
        exp = sounds[1];
    }

    // Update is called once per frame
    void Update()
    {

        if (!level.isGo)
        {
            if (Input.GetKeyDown(up))
            {

                if (down)
                {
                    pompe.transform.position = pos;
                    renard.SetBool("isDown", false);
                    insp.Play();
                }
                else
                {
                    renard.SetBool("isDown", true);
                  
                    Poule.transform.localScale *= 1.02f;
                    // Poule.transform.localScale += new Vector3(scale, scale);
                    waterSpash.Play();
                    exp.Play();
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
                    newPos.y -= 0.63f;
                    pompe.transform.position = newPos;
                }
                down = !down;

            }
        }
    }

}
