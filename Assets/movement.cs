using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject box;
    private float movespeed = 5f;
    public GameObject bulletPreFab;
    private int movingDirection;
    private float bulletGraceTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            movingDirection = 1;
            box.transform.Translate((Vector3.left*Time.deltaTime)*movespeed);
        }
        if (Input.GetKey(KeyCode.D)) {
            box.transform.Translate((Vector3.right*Time.deltaTime)*movespeed);
            movingDirection = 2;
        }
        if (Input.GetKey(KeyCode.W)) {
            box.transform.Translate((Vector3.up*Time.deltaTime)*movespeed);
            movingDirection = 3;
        }
        if (Input.GetKey(KeyCode.S)) {
            box.transform.Translate((Vector3.down*Time.deltaTime)*movespeed);
            movingDirection = 4;
        }
        if (Input.GetMouseButtonDown(0)) {
            bulletGraceTime -= Time.deltaTime;
            if (bulletGraceTime < 1f)
            {
                spawnBullet();
                bulletGraceTime = 2f;
            }
        }
        
    }
    private void spawnBullet() {
        GameObject bulletTransform = Instantiate(bulletPreFab, transform.position, Quaternion.identity);
        bullet bulletScript = bulletTransform.GetComponent<bullet>();
        bulletScript.moveDirection = movingDirection;
    }
}
