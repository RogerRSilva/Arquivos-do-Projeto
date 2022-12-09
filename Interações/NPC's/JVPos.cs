//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de Herança
public class JVPos : MonoBehaviour
{
    //declara variaveis e objetos;
    public Transform npc;
    public GameObject npc1;
    public GameObject npc2;

    //se identificar contato com o Jogador
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //altera escala do objeto
            npc.localScale = new Vector3 (-1,1,1);
            //desativa objeto
            npc1.SetActive(false);
            //ativa objeto
            npc2.SetActive(true);
        }
    }
}
