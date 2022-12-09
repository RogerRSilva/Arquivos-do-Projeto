//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de Herança
public class PlataformaMovimentoY : MonoBehaviour
{
    //declara variaveis
    public float speed;
    public float timeWalk;

    public bool Plataforma;

    private bool movingUp = true;

    //invoca o metodo constantemente 
    void FixedUpdate()
    {
        //Se o objeto estiver ativado
        if (Plataforma)
        {
            //Movimento para cima
            if (movingUp)
            {
                //invoca rotina
                StartCoroutine("Movimentup");
            }
            //Movimento para baixo
            if (movingUp == false)
            {
                //altera direção
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                //invoa rotina
                StartCoroutine("Movimentdown");
            }
        }
    }

    //Rotina de movimento para cima
    IEnumerator Movimentup()
    {
        //altera direção
        transform.Translate (Vector2.up * speed * Time.deltaTime);
        //intervalo de tempo
        yield return new WaitForSeconds(timeWalk);
        //altera variavel
        movingUp = false;
    }

    //Rotina de movimento para baixo
    IEnumerator Movimentdown()
    {
        //intervalo de tempo
        yield return new WaitForSeconds(timeWalk);
        //altera variavel
        movingUp = true;
    }
}
