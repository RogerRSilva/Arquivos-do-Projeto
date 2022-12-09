//adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//adiciona a biblioteca do Unity para gerenciamento de eventos
using UnityEngine.Events;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class TriggerInteracao : MonoBehaviour
{
    //serializa a variavel na interface do Unity
    [SerializeField]
    //variavel que armazena um evento
    private UnityEvent chamaCena;

    //identifica se existe colisão
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colisão for o jogador
        if (other.gameObject.tag == "Player")
        {
            //invoca o evento armazenado na variavel
            chamaCena.Invoke();
            //impede o movimento do jogador
            Movimento2.estaticoGlobal = false;
        }
    }
}
