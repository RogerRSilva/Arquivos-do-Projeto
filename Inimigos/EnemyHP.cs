//adiciona bibliotecas proprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de herança
public class EnemyHP : MonoBehaviour
{
    //declara variaveis
    public int enemyHP;
    private int currentHP;

    public float timeDeath;

    //invoca o metodo apenas no primeiro instante apos o objeto ser ativado
    void Start()
    {
        //vida do inimigo é igual a vida atual
        currentHP = enemyHP;
    }

    //invoca o metodo constantemente
    void Update()
    {
        //se a vida for igual a zero
        if (currentHP <= 0)
        {
            //invoca rotina "Kill"
            StartCoroutine("Kill");
        }
    }

    //metodo de dano ai inimigo
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }
    //Rotina "kill"
    IEnumerator Kill()
    {
        //intervalo de tempo
        yield return new WaitForSeconds(timeDeath);
        //Destroi o objeto "Inimigo"
        Destroy(transform.parent.gameObject);
    }

}
