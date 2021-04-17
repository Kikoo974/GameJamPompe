using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelManager : MonoBehaviour
{
    public float time = 10;
    public TextMeshPro timer, WinText;
    
    public int nbPompJ1, nbPompJ2;
    public GameObject pouleJ1, pouleJ2, cam, button, quit, touche, spike;
    PouleMoveBaloon J1, J2;
    public GameObject spawnB, spawnO, spawnO1, spawnO2;
    public GameObject CielRep, Ciel0;
    private List<GameObject> Ciels = new List<GameObject>();
    bool isPause = false;
    AudioSource poka;
    int lifeJ1 = 1, lifeJ2 = 1;
    // Start is called before the first frame update
    void Start()
    {
        Ciels.Add(Ciel0);
        J1 = pouleJ1.GetComponent<PouleMoveBaloon>();
        J2 = pouleJ2.GetComponent<PouleMoveBaloon>();
        poka = GetComponent<AudioSource>();
        timer.text = "" + (int)time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                Time.timeScale = 1;
                quit.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                quit.SetActive(true);
            }
        }
           
        if (cam.transform.position.y > Ciels[0].transform.position.y)
            SpawnCiel();
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
      /*  if(pouleJ1.transform.position.y< cam.transform.position.y - 4.2)
        {
            Win(2);
        }
        if (pouleJ2.transform.position.y < cam.transform.position.y - 4.2)
        {
            Win(1);
        }*/

    }
    void SpawnCiel()
    {
        GameObject c = Instantiate(CielRep, new Vector3(Ciels[0].transform.position.x, Ciels[0].transform.position.y), transform.rotation);
        GameObject d = Instantiate(CielRep, new Vector3(Ciels[0].transform.position.x, Ciels[0].transform.position.y + 10), transform.rotation);
        Ciels.Add(c);
        Ciels.Add(d);
        Destroy(Ciels[0]);
        Ciels.RemoveAt(0);
        Ciels.Reverse();
       
    }
    public void PompeJ1(int j)
    {
        if(j==1)
            nbPompJ1 ++;
        else
            nbPompJ2++;
    }
    public void Damage(int J)
    {
        if (J == 1)
            lifeJ1--;
        else
            lifeJ2--;
        if (lifeJ1 <= 0)
            Win(2);
        if (lifeJ2 <= 0)
            Win(1);
    }
    IEnumerator Test()
    {
        lifeJ1 = nbPompJ1;
        lifeJ2 = nbPompJ2;

        if(nbPompJ1 >nbPompJ2)
        {
            J1.canMove = true;
            J1.fly.Play();
            yield return new WaitForSeconds(0.1f);
            J2.fly.Play();
            J2.canMove = true;
        }
        else
        {
            J2.canMove = true;
            J2.fly.Play();
            yield return new WaitForSeconds(0.1f);
            J1.canMove = true;
            J1.canMove = true;
        }
        spike.SetActive(true);
        touche.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        spawnB.SetActive(true);
        spawnO.SetActive(true);
        yield return new WaitForSeconds(10f);
        spawnO1.SetActive(true);
        yield return new WaitForSeconds(12);
        spawnO2.SetActive(true);
        yield return new WaitForSeconds(14);
        

    }
    void Win(int player)
    {
        WinText.text = "J" + player + " WIN";
        button.SetActive(true);
    }
    public void OnClickDo(int button)
    {
        poka.Play();
        switch (button)
        {
            case 0:
                SceneManager.LoadScene(1);
                break;
            case 1:
                Application.Quit();
                break;
            case 2:
                SceneManager.LoadScene(0);
                break;


        }
    }
   




}
    
   

