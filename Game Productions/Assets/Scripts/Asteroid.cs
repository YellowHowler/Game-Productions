using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] GameObject chi1;
    [SerializeField] GameObject chi2;

    private float size;
    private int health;
    private float speed;

    private GameObject scoreTxt;
    
    void Start()
    {
        Destroy(gameObject, 7);

        float difficulty = Mathf.Clamp(((int)Time.time / 2) * 0.3f, 0, 4.5f);

        size = Random.Range(0.4f, 0.8f);
        speed = Random.Range(2f + difficulty, 4.5f + difficulty);

        health = (int)(10 * size);

        transform.localScale = new Vector3(size,size,1);

        scoreTxt = GameObject.FindGameObjectWithTag("ScoreUI");
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);    
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Asteroid" || transform.position.y > 9)
        {
            return;
        }

        health -= 4;
        Debug.Log(health);

        if(health <= 0)
        {
            scoreTxt.GetComponent<ScoreUI>().AddScore((int)(size*10));
            StartCoroutine(Die());

            chi1.transform.parent = null;
            Destroy(chi1, 1f);

            chi2.transform.parent = null;
            Destroy(chi2, 1f);
            
            Destroy(gameObject);
        }

        if(col.gameObject.tag == "Player")
        {
            CameraShake.Shake(0.1f, 0.3f);
            scoreTxt.GetComponent<ScoreUI>().ReStart();

            StartCoroutine(Die());

            chi1.transform.parent = null;
            Destroy(chi1, 1f);

            chi2.transform.parent = null;
            Destroy(chi2, 1f);
            
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            StartCoroutine(Hit());
        }
    }

    private IEnumerator Hit()
    {
        CameraShake.Shake(0.1f, 0.1f);
        ParticleSystem ps = chi1.gameObject.GetComponent<ParticleSystem>();
        if(ps != null) ps.Play();
        yield return new WaitForSeconds(0.2f);
        if(ps != null) ps.Stop(true);
    }

    private IEnumerator Die()
    {
        CameraShake.Shake(0.1f, 0.1f);
        ParticleSystem ps = chi2.GetComponent<ParticleSystem>();
        if(ps != null) ps.Play();
        yield return new WaitForSeconds(0.2f);
        if(ps != null) ps.Stop(true);
    }
}
