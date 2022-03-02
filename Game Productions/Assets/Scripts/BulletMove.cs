using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private Vector3 pos;

    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y+(20f * Time.deltaTime), 0);
    }
}
