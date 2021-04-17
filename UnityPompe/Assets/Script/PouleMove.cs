using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PouleMove : MonoBehaviour
{
    public KeyCode Right, Left;
    Vector2 ppos;
    float speedX = 5, speedY = 20;
    int sign;
    float X;
    public float bim;
    bool decrease;
    public bool canMove, canInput = true;
    Quaternion rotation;
    public ParticleSystem pouf;
    public AudioSource hit, fly, ouefcrack;
    AudioSource[] ausios;
    public LevelManagerDuo level;
    public float maxLeft, maxRight;
    void Start()
    {
        canInput = true;
        ppos = gameObject.transform.position;
        ausios = GetComponents<AudioSource>();
        hit = ausios[0];
        fly = ausios[1];
        ouefcrack = ausios[2];
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {

            if (canInput)
            {
                if (Input.GetKey(Right))
                {

                    decrease = false;
                    X += 0.1f;
                    if (X > 30)
                        X = 30;

                }
                if (Input.GetKey(Left))
                {
                    decrease = false;
                    X -= 0.1f;
                    if (X < -30)
                        X = -30;
                }
            }
            if (Input.GetKeyUp(Left))
                decrease = true;
            if (Input.GetKeyUp(Right))
                decrease = true;
            if (decrease)
                X *= 0.99f;
            if (!level.isGo)
            {
                if (ppos.x < maxLeft)
                {
                    ppos.x = maxLeft;
                    X = 0;
                }
                if (ppos.x > maxRight)
                {
                    ppos.x = maxRight;
                    X = 0;
                }
            }
            else
            {
                if (ppos.x < -10)
                    ppos.x = 10;
                if (ppos.x > 10)
                    ppos.x = -10;
            }
           
            rotation = Quaternion.Euler(0, 0, -X * 2);
            gameObject.transform.rotation = rotation;
            ppos.x += (X + bim) * Time.deltaTime;
            ppos.y += speedY * Time.deltaTime;
            gameObject.transform.position = ppos;
        }
    }
    public IEnumerator Move()
    {

        canInput = false;
        bim *= 0.99f;
        yield return new WaitForSeconds(0.2f);
        decrease = true;
        canInput = true;
        bim = 0;
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        // if (other.gameObject.tag == "Obstacle")
        //    transform.localScale *= 1.02f;
        //transform.localScale -= new Vector3(0.02f, 0.02f);
        if (other.gameObject.tag == "Player")
        {
            hit.Play();
            other.gameObject.GetComponent<PouleMove>().bim = 200 * X * Time.deltaTime;
            other.gameObject.GetComponent<PouleMove>().Move();
            bim = 50 * -X * Time.deltaTime;
            StartCoroutine(Move());
        }

    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {
            hit.Play();
            transform.localScale -= new Vector3(0.02f, 0.02f);
            ppos.y -= 0.5f;
            pouf.transform.position = collision.gameObject.transform.position;
            // pouf.transform.position = collision.gameObject.transform.position;
            pouf.Play();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Oeuf")
        {
            ouefcrack.Play();
            transform.localScale -= new Vector3(0.02f, 0.02f);
            ppos.y -= 0.5f;
            pouf.transform.position = collision.gameObject.transform.position;
            // pouf.transform.position = collision.gameObject.transform.position;
            pouf.Play();
            collision.gameObject.SetActive(false);
        }
    }
}
