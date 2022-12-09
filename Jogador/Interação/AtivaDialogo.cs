//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de heran�a
public class AtivaDialogo : MonoBehaviour
{
    //declara variavel de acesso global do tipo booleana e a define como falsa
    public static bool ativaDlg = false;

    //identifica se existe colis�o
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colis�o for o Jogador
        if (other.gameObject.tag == "Player")
        {
            //altera valor da v�riavel para verdadeira
            ativaDlg = true;
        }
    }
    //identifica se n�o existe colis�o
    private void OnTriggerExit2D(Collider2D other)
    {
        //se o objeto de colis�o for o Jogador
        if (other.gameObject.tag == "Player")
        {
            //altera o valor da v�riavel para verdadeira
            ativaDlg = false;
        }
    }
}
