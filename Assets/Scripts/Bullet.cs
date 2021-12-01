using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 dir;
    private Rigidbody2D rigidBody;
    void Start()
    {
       // dir = GameObject.Find("Dir").transform.position;
       // transform.position = GameObject.Find("FirePoint").transform.position;
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
        if((Vector2) transform.position==dir)
        {
            Destroy(gameObject);
        }

    }
    public void Fire(Vector3 direction)
    {
        // rigidBody.AddForce(direction * acceleration,ForceMode2D.Impulse)
        dir = transform.position + (direction.normalized * 10f);
    }
}
