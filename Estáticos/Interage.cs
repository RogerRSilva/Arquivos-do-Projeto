//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de herança
public class Interage : MonoBehaviour
{
    //declara variaveis e objetos
    public Animator _animator;
    public AudioSource carta;

    //invoca metodo
    public void Ler()
    {
        //se a variavel for falsa
        if(BotaoInterage.onOff == false)
        {
            //audio inicia
            carta.Play();
            //animação inicia
            _animator.SetBool("pegou", true);
        }
        //se a variavel for verdadeira
        if(BotaoInterage.onOff == true)
        {
            //animação para
           _animator.SetBool("pegou", false);
        }

    }
}
