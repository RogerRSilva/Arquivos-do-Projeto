//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adiciona a biblioteca para edição de texto
using TMPro;

//Cria classe de herança
public class ObjetivosEntregues : MonoBehaviour
{
    //declara váriaveis e objetos
    public TMP_Text objText;
    public int numObjetivo;

    //invoca o metodo constantemente
    void Update()
    {
        //texto na interface da tela é igual o número de objetivos completos convertido em texto
        objText.text = numObjetivo.ToString();
    }
}
