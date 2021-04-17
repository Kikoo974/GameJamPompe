using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelManagerSoloScore : MonoBehaviour
{
    public float time = 10;
    public TextMeshPro timer, WinText, scoreT;
    int score;
    public int nbPompJ1;
    public GameObject pouleJ1, cam, button, quit, touche, scoreO;
    PouleMoveSolo J1;
    public GameObject spawnB, spawnO, spawnO1, spawnO2, spawnO3, spawnO4;
    public GameObject CielRep, Ciel0;
    private List<GameObject> Ciels = new List<GameObject>();
    bool isPause = false, isScoring = false;
    AudioSource poka;
    // Start is called before the first frame update
    void Start()
    {
        Ciels.Add(Ciel0);
        J1 = pouleJ1.GetComponent<PouleMoveSolo>();
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
        if (isScoring)
        {
            score++;
            scoreT.text = "" + score;
        }
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
    public void PompeJ1()
    {
        if(!J1.canMove)
            nbPompJ1 ++;
       
    }
    IEnumerator Test()
    {
        isScoring = true;
        J1.canMove = true;
        scoreO.SetActive(true);
        J1.fly.Play();
        J1.life = nbPompJ1;
        J1.maxLife = nbPompJ1;
        touche.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        spawnB.SetActive(true);
        spawnO.SetActive(true);
        yield return new WaitForSeconds(10f);
        spawnO1.SetActive(true);
        yield return new WaitForSeconds(12);
        spawnO2.SetActive(true);
        yield return new WaitForSeconds(14);
        spawnO3.SetActive(true);
        yield return new WaitForSeconds(15);
        spawnO4.SetActive(true);

    }
    public void Win()
    {
        scoreO.SetActive(false);
        WinText.text = "Score :" + score;
        Time.timeScale = 0;
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
    
   

