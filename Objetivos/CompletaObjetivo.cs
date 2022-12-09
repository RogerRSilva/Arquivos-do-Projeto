//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//Cria classe de Herança
public class CompletaObjetivo : MonoBehaviour
{
    //serializa váriavies na interface do unity
    [SerializeField]
    //declara variaveis e componentes
    private JogadorInterage _jogadorInterage;
    public CapsuleCollider2D Objetivo;
    public Dialogue dialog;

    //variavel global que identifica o tipo de dialogo
    public static bool tipoDialog = false;

    //invoca o metodo apenas no primeiro instante
    void Start()
    {
        //reconhece o componente previamente
        Objetivo = GetComponent<CapsuleCollider2D>();
    }

    //identifica se existe colisão
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colisão for o jogador
        if (other.gameObject.tag == "Player")
        {
            //define que o tipo de dialogo é um dialogo de objetivo 
            tipoDialog = true;
            //ativa o componente
            dialog.enabled = true;
        }
    }
}
