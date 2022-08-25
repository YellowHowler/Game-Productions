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
        transform.localPosition = new Vector3(3 * Mathf.Sin(Time.time*8)/30, 3 * Mathf.Sin(Time.time*4)/40, 0);
    }
}
