//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//adiciona a biblioteca da Unity para gerenciar cenas
using UnityEngine.SceneManagement;

//cria classe de Heran�a
public class TrocaTextos : MonoBehaviour
{
    //objetos presentes na cena (textos 2D)
    public GameObject txt;
    public GameObject txt1;
    public GameObject txt2;
    public GameObject txt3;
    //tela de transi��o
    public GameObject transicao;
    //int que armazena quantos textos foram ativados
    public int txtactive;
    //variavel que armazena o nome da pr�xima cena
    public string prxFase;

    //invoca o metodo constantemente
    void Update()
    {
        //se o Jogador pressionar a tecla "E"
        if (Input.GetKey(KeyCode.E))
        {
            //se a trasi��o estiver desativada
            if (Desativatransicao.prxTrue == false)
            {
                //ativa transicao
                transicao.SetActive(true);
                //invoca Rotina
                StartCoroutine("Transicion");
            }
        }
        //se o n�mero de texto ativos for igual a 1
        if(txtactive == 1)
        {
            //ativa o pr�ximo texto
            txt.SetActive(true);
        }
        //se o n�mero de texto ativos for igual a 2
        if (txtactive == 2)
        {
            //ativa o pr�ximo texto
            txt1.SetActive(true);
        }
        //se o n�mero de texto ativos for igual a 3
        if (txtactive == 3)
        {
            //ativa o pr�ximo texto
            txt2.SetActive(true);
        }
        //se o n�mero de texto ativos for igual a 4
        if (txtactive == 4)
        {
            //ativa o pr�ximo texto
            txt3.SetActive(true);
        }
        //se o n�mero de texto ativos for igual a 5
        if (txtactive == 5)
        {
            //Invoca a pr�xima cena
            SceneManager.LoadScene(prxFase);
        }
    }

    //rotina
    IEnumerator Transicion()
    {
        //intervalo de tempo
        yield return new WaitForSeconds(0.6f);
        //adiciona +1 para cada texto ativo na v�riavel
        txtactive++;
        //para a rotina
        StopCoroutine("Transicion");
    }
}
