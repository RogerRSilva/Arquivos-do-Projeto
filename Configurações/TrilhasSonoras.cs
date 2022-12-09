//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class TrilhasSonoras : MonoBehaviour
{
    //declara variaveis
    public AudioSource somBar;
    public AudioSource somFora;
    public AudioSource somFora1;
    public static bool falouDnCleusa = false;

    //quando um objeto especifico (jogador) entrar no campo definido o metódo é invocado
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bar")
        {
            //ativa som do cenário "bar" e desativa trilhas sonoras do cenário externo
            somBar.Play();
            somFora.Pause();
            somFora1.Stop();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bar")
        {
            //desativa som do cenário "bar" e ativa trilhas sonoras do cenário externo
            if (falouDnCleusa == true)
            {
                somBar.Stop();
                somFora1.Play();
            }
            else
            {
                somBar.Stop();
                somFora.Play();
            }
        }
    }
}
