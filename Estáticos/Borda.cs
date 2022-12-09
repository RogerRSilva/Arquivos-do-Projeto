//adiciona bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de heran�a
public class Icone : MonoBehaviour
{
    //declara variaveis
    private float speed = 0.75f;
    private float timeWalk = 0.75f;

    private Vector3 fcRight;
    private Vector3 fcLeft;

    private bool movingUp = true;

    //invoca o metodo apenas no primeiro instante
    void Start()
    {
        //define variaveis
        fcRight = transform.localScale;
        fcLeft = transform.localScale;
        fcRight.x = fcRight.x * -1;
    }

    //Invoca o metodo constantemente
    void Update()
    {
        //Se estiver se movendo para cima
            if (movingUp)
            {
            //altera dire��o
                transform.localScale = fcRight;
            //invoca rotina    
            StartCoroutine("MovimentLeft");
            }
            //se estiver se movendo para baixo
            if (movingUp == false)
            {
            //altera posi��o
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            //altera dire��o
                transform.localScale = fcLeft;
            //invoca rotina
                StartCoroutine("MovimentRight");
            }
    }

    //rotina
    IEnumerator MovimentLeft()
    {
        //altera posi��o
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        //intervalo de tempo
        yield return new WaitForSeconds(timeWalk);
        //altera variavel
        movingUp = false;
    }
    //rotina
    IEnumerator MovimentRight()
    {
        //intervalo de tempo
        yield return new WaitForSeconds(timeWalk);
        //altera variavel
        movingUp = true;
    }
}
