//adicionando bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class SetaRL : MonoBehaviour
{
    //declara objetos da cena
    public GameObject seta1, seta2;

    //identifica se existe colisão
    public void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colisão for o jogador
        if (other.gameObject.tag == "Marmita")
        {
            //desativa os objetos da cena
            seta1.SetActive(false);
            seta2.SetActive(false);
        }
    }
}
