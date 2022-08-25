using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float size;
    private int health;
    private float speed;
    void Start()
    {
        size = Random.Range(0.4f, 0.8f);
        speed = Random.Range(4f, 6f);

        health = (int)(10 * size);

        transform.localScale = new Vector3(size,size,1);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);    
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Asteroid")
        {
            return;
        }

        health -= 3;
        Debug.Log(health);
        if(health <= 0) Destroy(gameObject);

        if(col.gameObject.tag == "Player")
        {

        }
        else if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            StartCoroutine(Hit());
        }
    }

    private IEnumerator Hit()
    {
        var em = transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().emission;
        em.rateOverTime = 50;
        yield return new WaitForSeconds(0.2f);
        em.rateOverTime = 0;
    }
}
