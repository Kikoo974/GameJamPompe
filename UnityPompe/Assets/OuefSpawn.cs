    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuefSpawn : MonoBehaviour
{
    float timeSpawn = 3.0f;
    public GameObject Oeuf, OuefBase;
    public GameObject att;
    private List<GameObject> Oeufs = new List<GameObject>();
    Vector2 posOeuf;
    float speed = 3.0f;
    bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
        posOeuf = gameObject.transform.position;
        Oeufs.Add(OuefBase);
    }

    // Update is called once per frame
    void Update()
    {
       
        posOeuf = gameObject.transform.position;
        if (canMove)
        {
            if (posOeuf.x < -10)
            {
                posOeuf = new Vector3(-10, posOeuf.y);
                speed = Random.Range(3, 15);
            }
            if (posOeuf.x > 10)
            {
                posOeuf = new Vector3(10, posOeuf.y);
                speed = Random.Range(-15, -3);
            }
            posOeuf.x += Time.deltaTime * speed;
        }
       
        timeSpawn -= Time.deltaTime;
        if(timeSpawn <0)
        {
            StartCoroutine(Spawn());
            canMove = false;
           if (Oeufs[0] && Oeufs[0].transform.position.y < posOeuf.y - 15)
                   Destroyer();
                

            timeSpawn = Random.Range(1, 5);
        }
        gameObject.transform.position = posOeuf;
    }       
   
    private void Destroyer()
    {
     
        Destroy(Oeufs[0]);
        Oeufs.RemoveAt(0);

    }
    IEnumerator Spawn()
    {
        att.transform.position = new Vector3(posOeuf.x, att.transform.position.y);
        att.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        att.SetActive(false);
        GameObject go = Instantiate(Oeuf, new Vector3(posOeuf.x, posOeuf.y), transform.rotation);
        go.transform.localScale *= Random.Range(0.3f, 1);
        Oeufs.Add(go);
        canMove = true;
    }
}
