//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de Heran�a
public class Left : MonoBehaviour
{
    //identifica se existe colis�o
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colis�o for as paredes do cen�rio
        if (other.gameObject.tag == "Paredes")
        {
            //desativa a possibilidade de movimento para a dire��o esquerda
            Movimento2.left = true;
        }
    }
    //identifica se n�o existe colis�o
    private void OnTriggerExit2D(Collider2D other)
    {
        //se o objeto de colis�o for as paredes do cen�rio
        if (other.gameObject.tag == "Paredes")
        {
            //ativa a possibilidade de movimento para a dire��o esquerda 
            Movimento2.left = false;
        }
    }
}
