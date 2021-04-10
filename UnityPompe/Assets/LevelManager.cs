using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public float time = 10;
    public Text timer;
    public int nbPompJ1, nbPompJ2;
    // Start is called before the first frame update
    void Start()
    {
        timer.text = "" + (int)time;
    }

    // Update is called once per frame
    void Update()
    {

        if (time >= 0)
        {
            time -= Time.deltaTime;
            timer.text = "" + (int)time;         
        }
    }
    public void PompeJ1(int j)
    {
        if(j==1)
            nbPompJ1 ++;
        else
            nbPompJ2++;
    }
   




}
    
   

