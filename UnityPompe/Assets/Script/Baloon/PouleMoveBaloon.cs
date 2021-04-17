using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PouleMoveBaloon : MonoBehaviour
{
    public KeyCode Right, Left, Up, Down, Attack;
    public GameObject RightWinf, LeftWing, cam;
    Vector2 ppos;
    float speedX = 5, speedY = 20;
    int sign;
    float X, Y;
    public float bim;
    bool decreaseX, decreaseY;
    public bool canMove, canInput = true;
    Quaternion rotation;
    public ParticleSystem pouf;
    public AudioSource hit, fly, ouefcrack;
    AudioSource[] ausios;
    public LevelManager level;
    public float maxLeft, maxRight;
    public int J;
    bool canAttack = true;
    void Start()
    {
        canInput = true;
        ppos = gameObject.transform.position;
        ausios = GetComponents<AudioSource>();
        hit = ausios[0];
        fly = ausios[1];
        ouefcrack = ausios[2];
        RightWinf.GetComponent<BoxCollider2D>().enabled = false;
        LeftWing.GetComponent<BoxCollider2D>().enabled = false;
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

                    decreaseX = false;
                    X += 0.1f;
                    if (X > 30)
                        X = 30;
                    if (Input.GetKeyDown(Attack)&&canAttack)
                        StartCoroutine(AttackTime(RightWinf));
                }
                if (Input.GetKey(Left))
                {
                    decreaseX = false;
                    X -= 0.1f;
                    if (X < -30)
                        X = -30;
                    if (Input.GetKeyDown(Attack)&&canAttack)
                        StartCoroutine(AttackTime(LeftWing));
                }
                if (Input.GetKey(Up))
                {

                    decreaseY = false;
                    Y += 0.2f;
                    if (Y > 30)
                        Y = 30;

                }
                if (Input.GetKey(Down))
                {
                    decreaseY = false;
                    Y -= 0.2f;
                    if (Y < -30)
                        Y = -30;
                }

            }
            else bim *= 0.99f;
            if (Input.GetKeyUp(Left))
                decreaseX = true;
            if (Input.GetKeyUp(Right))
                decreaseX = true;
            if (Input.GetKeyUp(Up))
                decreaseY = true;
            if (Input.GetKeyUp(Down))
                decreaseY = true;

            if(decreaseX) X *= 0.99f;
            if(decreaseX) Y *= 0.99f;


            if (ppos.x < -10)
                ppos.x = -8;
            if (ppos.x > 10)
                ppos.x = 8;
            if (ppos.y < cam.transform.position.y -4.5f)
                ppos.y = cam.transform.position.y - 4.5f;
            if (ppos.y > cam.transform.position.y + 4.5f)
                ppos.y = cam.transform.position.y + 4.5f;


            rotation = Quaternion.Euler(0, 0, -X * 2);
            gameObject.transform.rotation = rotation;
            ppos.x += (X + bim) * Time.deltaTime;
            ppos.y += Y * Time.deltaTime;
            gameObject.transform.position = ppos;
        }
    }
    IEnumerator AttackTime(GameObject wing)
    {
        canAttack = false;
        Vector3 size = wing.transform.localScale;
        wing.GetComponent<BoxCollider2D>().enabled = true;
        while (wing.transform.localScale.x * size.x < 10 * size.x * size.x)
        {
            wing.transform.localScale = new Vector3(wing.transform.localScale.x + (Time.deltaTime * 50 *size.x), wing.transform.localScale.y);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.1f);
        while (wing.transform.localScale.x * size.x> 1 * size.x)
        {
            wing.transform.localScale = new Vector3(wing.transform.localScale.x - (Time.deltaTime * 50*size.x) , wing.transform.localScale.y);
            yield return new WaitForEndOfFrame();
        }
        wing.transform.localScale = size;
        wing.GetComponent<BoxCollider2D>().enabled = false;
        canAttack = true;
    }
       
    public IEnumerator Move()
    {

        canInput = false;
       
        yield return new WaitForSeconds(0.2f);
        decreaseX = true;
        canInput = true;
        bim = 0;
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Spike")
        {
            hit.Play();
            transform.localScale /= 1.02f;
            level.Damage(J);
            bim = 0;
            bim = 10 * -(X+bim);
            StartCoroutine(Move());
        }
        //transform.localScale -= new Vector3(0.02f, 0.02f);
        if (other.gameObject.tag == "Player")
        {
            hit.Play();
            other.gameObject.GetComponent<PouleMoveBaloon>().bim = 0;
            other.gameObject.GetComponent<PouleMoveBaloon>().bim = 200 * X * Time.deltaTime;
            other.gameObject.GetComponent<PouleMoveBaloon>().StartCoroutine(Move());
            bim = 0;
            bim = 50 * -X * Time.deltaTime;
            StartCoroutine(Move());
        }

    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    
        if (collision.gameObject.tag == "Obstacle")
        {
            hit.Play();
            transform.localScale /= 1.02f;
            ppos.y -= 0.5f;
            pouf.transform.position = collision.gameObject.transform.position;
            // pouf.transform.position = collision.gameObject.transform.position;
            pouf.Play();
            collision.gameObject.SetActive(false);
            level.Damage(J);
        }
        if (collision.gameObject.tag == "Oeuf")
        {
            ouefcrack.Play();
            transform.localScale /= 1.02f;
            ppos.y -= 0.5f;
            pouf.transform.position = collision.gameObject.transform.position;
            // pouf.transform.position = collision.gameObject.transform.position;
            pouf.Play();
            collision.gameObject.SetActive(false);
            level.Damage(J);
        }
        if (collision.gameObject.tag == "Wing" + J)
        {
            bim = 30 * collision.gameObject.GetComponentInParent<PouleMoveBaloon>().X;
            StartCoroutine(Move());
        }
    }
}
