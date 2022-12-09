//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adiciona a biblioteca para edi��o de texto
using TMPro;

//Cria classe de heran�a
public class ObjetivosEntregues : MonoBehaviour
{
    //declara v�riaveis e objetos
    public TMP_Text objText;
    public int numObjetivo;

    //invoca o metodo constantemente
    void Update()
    {
        //texto na interface da tela � igual o n�mero de objetivos completos convertido em texto
        objText.text = numObjetivo.ToString();
    }
}
