using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float speed = 100f;
    private float lifetime = 5f;
    public int moveDirection;
    private Vector3 mDirection;
    // Start is called before the first frame update
    void Start()
    {
        setMovingDirection();
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 newPosition = transform.position+mDirection*speed*Time.deltaTime; 
       transform.position = newPosition;
       lifetime -= Time.deltaTime;
       if (lifetime < 0) {
        Destroy(this.gameObject);
       }
    }

    private void setMovingDirection() {
        switch (moveDirection) {
            case 1:
                mDirection = Vector3.left;
                break;
            case 2:
                mDirection = Vector3.right;
                break;
            case 3:
                mDirection = Vector3.up;
                break;
            case 4:
                mDirection = Vector3.down;
                break;
        }
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.gameObject.CompareTag("enemy")) {
    //         Destroy(this.gameObject);
    //     }
    // }
}
