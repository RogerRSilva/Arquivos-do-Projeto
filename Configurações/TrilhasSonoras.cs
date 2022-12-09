//adiciona bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de heran�a
public class TrilhasSonoras : MonoBehaviour
{
    //declara variaveis
    public AudioSource somBar;
    public AudioSource somFora;
    public AudioSource somFora1;
    public static bool falouDnCleusa = false;

    //quando um objeto especifico (jogador) entrar no campo definido o met�do � invocado
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bar")
        {
            //ativa som do cen�rio "bar" e desativa trilhas sonoras do cen�rio externo
            somBar.Play();
            somFora.Pause();
            somFora1.Stop();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bar")
        {
            //desativa som do cen�rio "bar" e ativa trilhas sonoras do cen�rio externo
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
