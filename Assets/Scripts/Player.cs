using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float angulo;
    public float forca;

    public GameObject tiro;
    public Transform linhaAngPos;
    public Transform spawnPointPos;

    public Vector2 startPoint;
    public Vector2 endPoint;
    public Vector2 direcao;

    public bool pressionou = false;
   
    public Slider barraDeForca;

    private void Start()
    {
        angulo = 60;
        forca = 0;
    }


    // Update is called once per frame
    void Update()
    {
        //ponto q indica o centro da direção
        startPoint = linhaAngPos.position;
        //ponto q indica a ponta (direção em relação ao centro)
        endPoint = spawnPointPos.position;
        //calculo que diz a direção pela diferença das posições dos pontos
        direcao = (endPoint - startPoint).normalized;


        //parte responsável por mudar o valor da variavel angulo
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            angulo += 20 * Time.deltaTime;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            angulo -= 20 * Time.deltaTime;
        }

        //rotaciona para a direção que a variavel angulo está guardando
        linhaAngPos.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, angulo);

        //resposável por o que acontece quando clicamos no botão de disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            forca = 0;
            pressionou = true;
        }
        //o que acontece quando soltamos o botão de disparo
        if (Input.GetKeyUp(KeyCode.Space))
        {
            pressionou = false;
            GameObject clone = Instantiate(tiro, new Vector3(spawnPointPos.position.x, spawnPointPos.position.y, 0), transform.rotation);
            clone.GetComponent<Rigidbody2D>().AddForce(transform.right * forca * 40);
        }

        //aumentar a força do disparo e atualizar a barra de força na tela
        if (pressionou)
        {
            forca += Time.deltaTime * 50;

            barraDeForca.value = forca / 100;
        }
    }
   
}
