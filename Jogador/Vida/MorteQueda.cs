//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de heran�a
public class MorteQueda : MonoBehaviour
{
    //identifica se existe colis�o
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colis�o for o jogador
        if (other.gameObject.tag == "Player")
        {
            //define a vida do jogador como zero
            PlayerHP.playerhp = 0;
        }
    }
}
