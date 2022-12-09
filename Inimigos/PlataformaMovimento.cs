//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de Herança
public class PlataformaMovimento : MonoBehaviour
{
    //declara variaveis
    public float speed;
    public float timeWalk;

    public bool Plataforma = true;

    private bool movingRight = true;

    //invoca o metodo constantemente 
    void FixedUpdate()
    {
        //Se o objeto estiver ativado
        if (Plataforma)
        {
            //Movimento para direita
            if (movingRight)
            {
                //invoca rotina
                StartCoroutine("MovimentLeft");
            }
            //Movimento para a esquerda
            if (movingRight == false)
            {
                //altera direção
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                //invoca rotina
                StartCoroutine("MovimentRight");
            }
        }
    }
    
    //Rotina de movimento na direção esquerda
    IEnumerator MovimentLeft()
    {
        //altera direção
        transform.Translate (Vector2.left * speed * Time.deltaTime);
        //intervalo de tempo
        yield return new WaitForSeconds(timeWalk);
        //altera variavel
        movingRight = false;
    }

    //Rotina de movimento na direção direita
    IEnumerator MovimentRight()
    {
        //intervalo de tempo
        yield return new WaitForSeconds(timeWalk);
        //altera variavel
        movingRight = true;
    }
}
