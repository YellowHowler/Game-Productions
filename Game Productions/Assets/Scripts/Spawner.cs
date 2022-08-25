using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;

    float difficulty = 0;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn()
    {
        while(true)
        {
            difficulty = Mathf.Clamp(((int)Time.time / 2) * 0.02f, 0, 0.4f);
            Instantiate(asteroid, new Vector3(Random.Range(-3f, 3f), 10f, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.8f - difficulty, 1.3f - difficulty));
        }
    }
}
