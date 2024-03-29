using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.3f;
    [SerializeField] private GameObject bullet;

    private Vector3 pos; 
    private float moveDelay = 0.07f;
    private bool canShoot = true;

    void Start()
    {
        StartCoroutine("ShootBullet");›
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        
        if (Input.GetKey(KeyCode.A) && pos.x > -3f)
        {
            transform.position = new Vector3(pos.x - moveSpeed*Time.deltaTime, pos.y, 0);
        }
        if (Input.GetKey(KeyCode.D) && pos.x < 3f)
        {
            transform.position = new Vector3(pos.x + moveSpeed*Time.deltaTime, pos.y, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            StartCoroutine(ShootBullet());
        }
    }

    IEnumerator ShootBullet()
    {
        canShoot = false;
        Instantiate(bullet, new Vector3(pos.x, pos.y+0.5f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        canShoot = true;
    }
}
