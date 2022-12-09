//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria Classe de herança
public class Desativatransicao : MonoBehaviour
{
    //declara variaveis e objetos
    public GameObject transicao;
    public static bool prxTrue;

    //invoca o metodo constantemente
    void Update()
    {
        //invoca rotina
        StartCoroutine("DesativaTransicao");
    }

    //rotina
    IEnumerator DesativaTransicao()
    {
        //altera variavel
        prxTrue = true;
        //desativa movimento do Jogador
        Movimento2.estaticoGlobal = false;
        //intervalo de tempo
        yield return new WaitForSeconds(1.5f);
        //altera variaveis
        prxTrue = false;
        JogadorInterage._podeAcao = true;
        //desativa transição de cenarios
        transicao.SetActive(false);
        //ativa movimento do Jogador
        Movimento2.estaticoGlobal = true;
    }
}
