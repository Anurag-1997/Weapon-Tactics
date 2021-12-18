using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveDirection;
    public GameObject bullet;
    public Transform firepoint;
    private Animator myAnim;

    private void Start()
    {
        myAnim = transform.GetChild(0).GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }
    void Move()
    {
        rb2d.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        myAnim.SetFloat("speed", rb2d.velocity.sqrMagnitude);
    }
    void Update()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject tempBullet = Instantiate(bullet, firepoint.position + 1.0f * transform.forward, transform.rotation); // transform.position+(dir.normalized)
          
        }
        ProcessInputs();
    }
}
