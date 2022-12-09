////adiciona bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cria classe de heran�a
public class Entrarsair : MonoBehaviour
{
    //declara objetos de cenarios
    public GameObject transicaoAtiva;
    public GameObject cenario1;
    public GameObject fundoCenarioAtiva;
    public GameObject cenario2;

    //invoca esse met�do ao entrar em um novo cen�rio
    public void Ativa()
    {
        //Se o jogador tiver interagido (como, por exemplo, uma porta)
        if (JogadorInterage._podeAcao == true)
        { 
            //invoca Rotina
            StartCoroutine("Sair");
        }
    }
    //Invoca esse metodo ao sair de um cenario
    public void Desativa()
    {
        //se o jogador tiver interagido
        if (JogadorInterage._podeAcao == true)
        {
            //invoca rotina
            StartCoroutine("Entrar");
        }
    }

    //Rotina 
    IEnumerator Sair()
    {
        //Desativa o cen�rio antigo
        //ativa a transi��o
        transicaoAtiva.SetActive(true);
        JogadorInterage._podeAcao = false;
        yield return new WaitForSeconds(0.6f);
        fundoCenarioAtiva.SetActive(false);
        cenario1.SetActive(true);
        cenario2.SetActive(false);
        //ativa cen�rio novo

    }
    //Rotina
    IEnumerator Entrar()
    {
        ////Desativa o cen�rio antigo
        //ativa a transi��o
        transicaoAtiva.SetActive(true);
        JogadorInterage._podeAcao = false;
        yield return new WaitForSeconds(0.6f);
        fundoCenarioAtiva.SetActive(true);
        cenario1.SetActive(false);
        cenario2.SetActive(true);
        //ativa cen�rio novo
    }

}
