using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird2 : MonoBehaviour
{
    public GameObject BirdOBJ;
    public float Spawn = 0;
    public float length = 15;
    public Transform BirdPosition;
    float time = 3.0f;
    private List<GameObject> ActiveBird = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time<=0)
        {
            SpawnTile();
            print(Spawn);
            print(BirdPosition.position.y);
            DeleteBird();
            time = Random.Range(3, 5);
        }
       

    }

    public void SpawnTile()
    {
        for (int i = 1; i < Random.Range(2, 4); i++)
        {
            float Randome;
            if(Random.Range(1,2) ==1)
                Randome = Random.Range(-20f, -10f);
            else
                Randome = Random.Range(10f, 20f);
            GameObject go = Instantiate(BirdOBJ, new Vector3(Randome, BirdPosition.position.y + Random.Range(-5,5)), transform.rotation);
            go.GetComponent<Bird>().speed = Random.Range(-30,30);
            if (go.GetComponent<Bird>().speed > 0)
                go.transform.localScale = new Vector3(-1, 1);
            go.transform.localScale *= Random.Range(0.3f, 1);
            ActiveBird.Add(go);
            Spawn += length;
        }

    }

    public void DeleteBird()
    {
        Destroy(ActiveBird[0]);
        ActiveBird.RemoveAt(0);
    }
}