//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class AtivaDonaCleusa : MonoBehaviour
{

    //variavel que armazena o script "DialogueDonaCleusa" para utilizar as váriaveis e metódos presentes no código
    public DialogueDonaCleusa _jogador;

    //identifica se existe colisão
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colisão for o Jogador
        if (other.gameObject.tag == "Player")
        {
            //ativa componente
            _jogador.enabled = true;
        }
    }
    //identifica se não existe colisão
    public void OnTriggerExit2D(Collider2D other)
    {
        //se o objeto de colisão for o Jogador
        if (other.gameObject.tag == "Player")
        {
            //desativa componente
            _jogador.enabled = false;
        }
    }
}
