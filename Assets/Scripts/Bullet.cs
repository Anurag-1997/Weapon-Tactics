using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
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
        //transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
        
        if ((Vector2) transform.position==dir)
        {
            Destroy(gameObject);
        }

    }
    void FixedUpdate()
    {
        rigidBody.AddForce(transform.up * speed);
        
    }
    //public void Fire(Vector3 direction)
    //{
    //    //dir = transform.position + direction.normalized *speed;
        
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="wall")
        {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag=="enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
