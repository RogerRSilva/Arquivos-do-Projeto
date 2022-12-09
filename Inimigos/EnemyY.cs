//adiciona bibliotecas proprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de herança
public class EnemyY : MonoBehaviour
{
    //declara variaveis
    public float speed;
    public float timeWalk;

    public bool EnemyKill = false;

    private Vector3 fcTop;
    private Vector3 fcDown;

    private bool movingtop = true;
    
    //invoca o metodo constantemente 
    void FixedUpdate()
    {
        //se o inimigo não for eliminado
        if (EnemyKill == false)
        {
            //se o Inimigo estiver se movendo para cima
            if (movingtop)
            {
                //invoca rotina
                StartCoroutine("MovimentUp");
            }
            //se o inimigo estiver se movendo para baixo
            if (movingtop == false)
            {
                //muda direção
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                //invoca rotina
                StartCoroutine("MovimentDown");
            }
        }
    }
    
    //rotina de movimento para cima
    IEnumerator MovimentUp()
    {
        //direção
        transform.Translate (Vector2.up * speed * Time.deltaTime);
        //intervalo de tempo
        yield return new WaitForSeconds(timeWalk);
        //define que deve se mover para baixo
        movingtop = false;
    }
    //rotina de movimento para cima
    IEnumerator MovimentDown()
    {
        //intervalo de tempo
        yield return new WaitForSeconds(timeWalk);
        //define que deve se mover para cima
        movingtop = true;
    }
}
