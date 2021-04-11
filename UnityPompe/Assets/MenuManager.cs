using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    SceneManager scene;
    AudioSource poka;
    // Start is called before the first frame update
    void Start()
    {
        poka = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick(int button)
    {
        poka.Play();
        switch(button)
        {
            case 0:
                SceneManager.LoadScene(1);
                break;
            case 1:
                Application.Quit();
                break;


        }
    }
    IEnumerator Charger()
    {
        yield return new WaitForSeconds(1.0f);
            
        SceneManager.LoadScene(1);
    }
}
