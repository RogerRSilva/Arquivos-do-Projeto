//adiciona bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de heran�a
public class Renata : MonoBehaviour
{
    //Declara variaveis e objetos
    public Animator renataAnim;
    public Transform renataPos;
    public GameObject renataObj;
    public DialogoNPC dlg;

    //invoca o metodo constantemente
    void Update()
    {
        //se a quantidade de linhas lidas for igual a 4
        if(dlg.lineIndex == 4)
        {
            //ativa anima��o
            renataAnim.SetBool("DialogEnd", true);
            //altera posi��o
            renataPos.Translate(Vector2.left * 5 * Time.deltaTime);
            //invoca rotina
            StartCoroutine("DestroyR");
        }
    }
    //rotina
    IEnumerator DestroyR()
    {
        //intervalo de tempo
        yield return new WaitForSeconds(10);
        //destroi o objeto
        Destroy(renataObj);
    }
}
