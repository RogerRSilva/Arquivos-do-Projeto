//adiciona bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de heran�a
public class AtivaInimigos : MonoBehaviour
{
    //declara variaveis e objetos
    public GameObject ativaObjetivo;
    public bool ativou = false;
    public GameObject inimigos;
    
    //se identificar colis�o
    private void OnTriggerEnter2D(Collider2D other)
    {
        // se os inimigos estiverem desativados
        if (ativou == false) {
            //se o objeto que passar pelo campo for o jogador
            if (other.gameObject.tag == "Player")
            {
                // ativa os inimigos 
                ativaObjetivo.SetActive(true);
                inimigos.SetActive(true);
                ativou = true;
            }
        }
    }
}
