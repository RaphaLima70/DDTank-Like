using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //definindo a direção que ele está se movendo
        Vector2 direction = rigid.velocity;

        //calculo que define a rotação do tiro baseado na velocidade do seu rigidbody
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //comando que atualiza a rotação baseado no calculo acima
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chao")
        {
            Destroy(gameObject);
        }
    }
}

