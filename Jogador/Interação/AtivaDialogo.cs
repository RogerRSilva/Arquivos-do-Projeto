//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class AtivaDialogo : MonoBehaviour
{
    //declara variavel de acesso global do tipo booleana e a define como falsa
    public static bool ativaDlg = false;

    //identifica se existe colisão
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colisão for o Jogador
        if (other.gameObject.tag == "Player")
        {
            //altera valor da váriavel para verdadeira
            ativaDlg = true;
        }
    }
    //identifica se não existe colisão
    private void OnTriggerExit2D(Collider2D other)
    {
        //se o objeto de colisão for o Jogador
        if (other.gameObject.tag == "Player")
        {
            //altera o valor da váriavel para verdadeira
            ativaDlg = false;
        }
    }
}
