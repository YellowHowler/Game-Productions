using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.3f;
    [SerializeField] private GameObject bullet;

    private Vector3 pos; 
    private float moveDelay = 0.07f;

    void Start()
    {
        StartCoroutine("ShootBullet");
        StartCoroutine("Move");

        //transform.position = new Vector(3, 3, 3.4f);
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        
        if (Input.GetKey(KeyCode.A) && pos.x > -2.5f)
        {
            transform.position = new Vector3(pos.x - moveSpeed*Time.deltaTime, pos.y, 0);
        }
        if (Input.GetKey(KeyCode.D) && pos.x < 2.5f)
        {
            transform.position = new Vector3(pos.x + moveSpeed*Time.deltaTime, pos.y, 0);
        }
    }

    IEnumerator ShootBullet()
    {
        while(true)
        {
            Instantiate(bullet, new Vector3(pos.x, pos.y+0.5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
        }
    }

    // IEnumerator Move()
    // {
    //     while(true)
    //     {
    //         //pos = transform.position;
    //         if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && pos.x > -2.5f)
    //         {
    //             transform.position = new Vector3(pos.x - moveSpeed*moveDelay, pos.y, 0);
    //         }
    //         if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && pos.x < 2.5f)
    //         {
    //             transform.position = new Vector3(pos.x + moveSpeed*moveDelay, pos.y, 0);
    //         }

    //         yield return new WaitForSeconds(moveDelay);
    //     }
    // }
}
