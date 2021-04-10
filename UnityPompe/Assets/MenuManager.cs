using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    SceneManager scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick(int button)
    {
        switch(button)
        {
            case 0:
                StartCoroutine(Charger());
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
