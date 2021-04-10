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
        SpawnTile();
        SpawnTile();
        SpawnTile();
    }

    // Update is called once per frame
    void Update()
    {

        if(BirdPosition.position.y - 15 > Spawn - (3 * length))
        {
            SpawnTile();
            print(Spawn);
            print(BirdPosition.position.y);
            DeleteBird();
        }
    }

    public void SpawnTile()
    {
        float Randome = Random.Range(-7, 7.5f);
        GameObject go = Instantiate(BirdOBJ, new Vector3(Randome, transform.position.y + Spawn), transform.rotation);
        ActiveBird.Add(go);
        Spawn += length;
    }

    public void DeleteBird()
    {
        Destroy(ActiveBird[0]);
        ActiveBird.RemoveAt(0);
    }
}
