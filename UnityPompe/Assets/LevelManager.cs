using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public float time = 10;
    public TextMeshPro timer;
    public int nbPompJ1, nbPompJ2;
    public PouleMove J1, J2;
    // Start is called before the first frame update
    void Start()
    {
        timer.text = "" + (int)time;
    }

    // Update is called once per frame
    void Update()
    {

        if (time > 0)
        {
            time -= Time.deltaTime;
            timer.text = "" + ((int)time +1);         
        }
        else if(time <0)
        {
            time = 0;
            StartCoroutine(Test());
        }
            
    }
    public void PompeJ1(int j)
    {
        if(j==1)
            nbPompJ1 ++;
        else
            nbPompJ2++;
    }
    IEnumerator Test()
    {
        if(nbPompJ1 >nbPompJ2)
        {
            J1.canMove = true;
            yield return new WaitForSeconds(0.1f);
            J2.canMove = true;
        }
        else
        {
            J2.canMove = true;
            yield return new WaitForSeconds(0.1f);
            J1.canMove = true;
        }
        yield return new WaitForSeconds(0.1f);
    }
   




}
    
   

