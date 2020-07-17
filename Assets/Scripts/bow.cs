using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{
    public Vector2 direction;
    public float force;
    public GameObject ponto;
    public GameObject[] pontos;

    public int numeroDePontos;

    // Start is called before the first frame update
    void Start()
    {
        pontos = new GameObject[numeroDePontos];

        for(int i = 0; i<numeroDePontos; i++)
        {
            pontos[i] = Instantiate(ponto, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 bowPos = transform.position;

        direction = mousePos - bowPos;

        faceMouse();

        for (int i = 0; i < numeroDePontos; i++)
        {
            pontos[i].transform.position = PointPosition(i * 0.1f); 
        }
    }

    void faceMouse()
    {
        transform.right = direction;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 currentPos = (Vector2)transform.position + (direction.normalized*force*t) + 0.5f * Physics2D.gravity * (t*t);
        return currentPos;
    }
}
