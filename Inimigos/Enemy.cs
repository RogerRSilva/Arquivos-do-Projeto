////adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de herança
public class Enemy : MonoBehaviour
{
    //declara variaveis e objetos
    public float speed;
    public float timeWalk;

    public bool EnemyKill = false;

    private Vector3 fcRight;
    private Vector3 fcLeft;

    private bool movingRight = true;
    
    //invoca o metodo no primeiro instante em o objeto é ativado
    void Start()
    {
        //define valores de variaveis
        fcRight = transform.localScale;
        fcLeft = transform.localScale;
        fcRight.x = fcRight.x * -1;
    }

    //invoca o metodo constantemente
    void FixedUpdate()
    {
        //se o inimigo não for eliminado
        if (EnemyKill == false)
        {
            //Se move pra direita utilizando uma rotina
            if (movingRight)
            {
                //define a direção
                transform.localScale = fcRight;
                //invoca a rotina
                StartCoroutine("MovimentLeft");
            }
            //Se move pra esquerda utilizando uma rotina
            if (movingRight == false)
            {
                //Movimento
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                //define a direção
                transform.localScale = fcLeft;
                //invoca a rotina
                StartCoroutine("MovimentRight");
            }
        }
    }
    
    //movimento para a esquerda
    IEnumerator MovimentLeft()
    {
        //Movimento
        transform.Translate (Vector2.left * speed * Time.deltaTime);
        //intervalo de tempo em que o inimigo ira alterar a sua direção
        yield return new WaitForSeconds(timeWalk);
        //variavel que define se a direção foi alterada
        movingRight = false;
    }
    //movimento para a direita
    IEnumerator MovimentRight()
    {
        yield return new WaitForSeconds(timeWalk);
        movingRight = true;
    }
}
