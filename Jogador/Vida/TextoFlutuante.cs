//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cria classe de heran�a
public class TextoFlutuante : MonoBehaviour
{
    //declara v�riaveis e objetos
    public GameObject text;
    public static bool textAtiva;

    //invoca o metodo constantemente
    void Update()
    {
        //se o componente estiver ativado
        if (textAtiva == true)
        {
            //invoca rotina
            StartCoroutine("DropText");
        }
    }

    //rotina
    IEnumerator DropText()
    {
        //intervalo de tempo
        yield return new WaitForSeconds(0.47f);
        //desativa o componente
        text.SetActive(false);
        //declara que o componente foi desativado
        textAtiva = false;
    }
}
