//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class Right : MonoBehaviour
{
    //identifica se existe colisão
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colisão for o jogador
        if (other.gameObject.tag == "Paredes")
        {
            //impede que o jogador continue se movendo pra direita
                Movimento2.right = true;
        }

    }
    //identifica se não existe colisão
    private void OnTriggerExit2D(Collider2D other)
    {
        //se o objeto de colisão for o jogador
        if (other.gameObject.tag == "Paredes")
        {
            //permite que o jogador se mova pra direita
                Movimento2.right = false;
         
        }
    }
}
