////adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cria classe de herança
public class Cachorro : MonoBehaviour
{
    //declara componentes
    public AudioSource dog;
    public DialogoNPC dlg;

    //invoca o metódo constantemente
    void Update()
    {
        //se a quantidade de linhas lidas for igual a 1
        if (dlg.lineIndex == 1)
        {
            dog.enabled = true;
            //ativa o som do cachorro
        }
        //se a quantidade de linhas lidar for igual a 2
        if(dlg.lineIndex == 2)
        {
            //Invoca rotina
            StartCoroutine("Stop");
        }
    }
    //rotina
    IEnumerator Stop()
    {
        //intervalo de tempo
        yield return new WaitForSeconds(2);
        //desativa som do cachorro
        dog.enabled = false;
    }
}
