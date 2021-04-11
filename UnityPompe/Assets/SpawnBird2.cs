using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird2 : MonoBehaviour
{
    public GameObject BirdOBJ;
    public float Spawn = 0;
    public float length = 15;
    public Transform camPos;
    float time = 3.0f;
    private List<GameObject> ActiveBird = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        SpawnTile();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time<=0)
        {
            SpawnTile();


           // DeleteBird();
            time = Random.Range(3, 5);
        }
       

    }

    public void SpawnTile()
    {
        float Randome;
        if ((int)Random.Range(1, 3) == 1)
            Randome = Random.Range(-13f, -19f);
        else
            Randome = Random.Range(10f, 13f);
        float posRAn = camPos.position.y + Random.Range(-5, 5);

        GameObject go = Instantiate(BirdOBJ, new Vector3(Randome, posRAn), transform.rotation);
        if (Randome > 0)
        {
            go.GetComponent<Bird>().speed = Random.Range(-3, 0) * 10;
            go.transform.localScale = new Vector3(1, 1);
        }
        else
        {
            go.GetComponent<Bird>().speed = Random.Range(1, 4) * 10;
        }
        go.transform.localScale *= Random.Range(0.3f, 1);
        ActiveBird.Add(go);

    }
    
    
    public void DeleteBird()
    {
        Destroy(ActiveBird[0]);
        ActiveBird.RemoveAt(0);
    }
}