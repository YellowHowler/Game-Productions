using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
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
            Instantiate(asteroid, new Vector3(Random.Range(-3f, 3f), 10.5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.8f, 1.8f));
        }
    }
}
