//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de heran�a
public class AtivaDonaCleusa : MonoBehaviour
{

    //variavel que armazena o script "DialogueDonaCleusa" para utilizar as v�riaveis e met�dos presentes no c�digo
    public DialogueDonaCleusa _jogador;

    //identifica se existe colis�o
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colis�o for o Jogador
        if (other.gameObject.tag == "Player")
        {
            //ativa componente
            _jogador.enabled = true;
        }
    }
    //identifica se n�o existe colis�o
    public void OnTriggerExit2D(Collider2D other)
    {
        //se o objeto de colis�o for o Jogador
        if (other.gameObject.tag == "Player")
        {
            //desativa componente
            _jogador.enabled = false;
        }
    }
}
