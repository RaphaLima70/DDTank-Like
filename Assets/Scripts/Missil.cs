using System.Collections;
using System.Collections.Generic;   
using UnityEngine;

public class Missil : MonoBehaviour
{
    public Transform target;

    float speed = 5;

    float rotateSpeed = 1000;

    public Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //target = GameObject.Find("tiro(Clone)").transform;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - rigid.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rigid.angularVelocity = -rotateAmount * rotateSpeed;

            //rigid.velocity = transform.up * speed;
          

        }
    }
}
