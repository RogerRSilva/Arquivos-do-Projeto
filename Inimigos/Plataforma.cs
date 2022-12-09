//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de Herança
public class Plataforma : MonoBehaviour
{
    //declara variavel
    public bool colidiu;

    //se indetificar contato com o Objeto "Plataforma"
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "plataforma")
        {
            //transforma o Personagem em um objeto filiado a plataforma
            gameObject.transform.parent = other.transform;
            //detecta contato
            colidiu = true;
        }
    }
    //se indetificar que não existe mais contato com o Objeto "Plataforma"
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "plataforma")
        {
            //Define o personagem como um Objeto independente 
            gameObject.transform.parent = null;
            //detecta contato
            colidiu = false;
        }
    }
}
