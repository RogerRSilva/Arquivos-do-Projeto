//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de Herança
public class Left : MonoBehaviour
{
    //identifica se existe colisão
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colisão for as paredes do cenário
        if (other.gameObject.tag == "Paredes")
        {
            //desativa a possibilidade de movimento para a direção esquerda
            Movimento2.left = true;
        }
    }
    //identifica se não existe colisão
    private void OnTriggerExit2D(Collider2D other)
    {
        //se o objeto de colisão for as paredes do cenário
        if (other.gameObject.tag == "Paredes")
        {
            //ativa a possibilidade de movimento para a direção esquerda 
            Movimento2.left = false;
        }
    }
}
