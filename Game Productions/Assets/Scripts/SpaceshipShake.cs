using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShake : MonoBehaviour
{
    private Vector3 pos;
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(Mathf.Sin(Time.time*10)/30, Mathf.Sin(Time.time*6)/40, 0);
    }
}
