using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelManagerDuo : MonoBehaviour
{
    public float time = 10;
    public TextMeshPro timer, WinText;
    
    public int nbPompJ1, nbPompJ2;
    public GameObject pouleJ1, pouleJ2, cam, button, quit, touche;
    PouleMove J1, J2;
    public GameObject spawnB, spawnO, spawnO1, spawnO2, spawnO3, spawnO4;
    public GameObject CielRep, Ciel0;
    private List<GameObject> Ciels = new List<GameObject>();
    bool isPause = false;
    AudioSource poka;
    public bool isGo;
    public int FirstToGo =0;
    // Start is called before the first frame update
    void Start()
    {
        Ciels.Add(Ciel0);
        J1 = pouleJ1.GetComponent<PouleMove>();
        J2 = pouleJ2.GetComponent<PouleMove>();
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
      
      
        if(pouleJ1.transform.position.y< cam.transform.position.y - 4.2 && FirstToGo ==1)
        {
            Win(2);
        }
        if (pouleJ2.transform.position.y < cam.transform.position.y - 4.2 && FirstToGo == 2)
        {
            Win(1);
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
    public void PompeJ1(int j)
    {
        if(j==1)
            nbPompJ1 ++;
        else
            nbPompJ2++;
        if (nbPompJ1 > 30 && FirstToGo!=1)
            StartCoroutine(Test());
        if (nbPompJ2 > 30 && FirstToGo != 2)
            StartCoroutine(Test());

    }
    void Go()
    {

    }
    IEnumerator Test()
    {
        
        if (FirstToGo == 0)
        {
            if (nbPompJ1 > nbPompJ2)
            {
                J1.canMove = true;
                J1.fly.Play();
                spawnO.GetComponent<OuefSpawn>().SetRL(J1.maxRight, J1.maxLeft);
                spawnO1.GetComponent<OuefSpawn>().SetRL(J1.maxRight, J1.maxLeft);
                spawnO2.GetComponent<OuefSpawn>().SetRL(J1.maxRight, J1.maxLeft);
                spawnO3.GetComponent<OuefSpawn>().SetRL(J1.maxRight, J1.maxLeft);
                spawnO4.GetComponent<OuefSpawn>().SetRL(J1.maxRight, J1.maxLeft);
                FirstToGo = 1;
            }
            else
            {
                J2.canMove = true;
                J2.fly.Play();
                spawnO.GetComponent<OuefSpawn>().SetRL(J2.maxRight, J2.maxLeft);
                spawnO1.GetComponent<OuefSpawn>().SetRL(J2.maxRight, J2.maxLeft);
                spawnO2.GetComponent<OuefSpawn>().SetRL(J2.maxRight, J2.maxLeft);
                spawnO3.GetComponent<OuefSpawn>().SetRL(J2.maxRight, J2.maxLeft);
                spawnO4.GetComponent<OuefSpawn>().SetRL(J2.maxRight, J2.maxLeft);
                FirstToGo = 2;
            }
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
        else
        {
            if(FirstToGo==1)
            {
                J2.canMove = true;
                J2.fly.Play();
            }
            else
            {
                J1.canMove = true;
                J1.fly.Play();
            }
            isGo = true;
        }

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
    
   

