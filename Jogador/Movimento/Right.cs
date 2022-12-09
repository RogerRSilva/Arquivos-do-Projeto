//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de heran�a
public class Right : MonoBehaviour
{
    //identifica se existe colis�o
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colis�o for o jogador
        if (other.gameObject.tag == "Paredes")
        {
            //impede que o jogador continue se movendo pra direita
                Movimento2.right = true;
        }

    }
    //identifica se n�o existe colis�o
    private void OnTriggerExit2D(Collider2D other)
    {
        //se o objeto de colis�o for o jogador
        if (other.gameObject.tag == "Paredes")
        {
            //permite que o jogador se mova pra direita
                Movimento2.right = false;
         
        }
    }
}
