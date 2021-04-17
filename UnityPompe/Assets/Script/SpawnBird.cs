using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird : MonoBehaviour
{
    public GameObject BirdOBJ;
    public float Spawn = 0;
    public float length= 15;
    public Transform BirdPosition;
   
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
        
        if(BirdPosition.position.y - 15 > Spawn - (3 * length))
        {
            SpawnTile();
            print(Spawn);
            print(BirdPosition.position.y);
           // DeleteBird();
        }
      
    }

    public void SpawnTile()
    {
        for (int i =1; i<Random.Range(2,6); i++)
        {
            float Randome = Random.Range(-10, 10);
            GameObject go = Instantiate(BirdOBJ, new Vector3(Randome, transform.position.y + Spawn), transform.rotation);
            go.GetComponent<Bird>().speed = -Randome;
            if (Randome > 0)
                go.transform.localScale= new Vector3(-1,1);
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
