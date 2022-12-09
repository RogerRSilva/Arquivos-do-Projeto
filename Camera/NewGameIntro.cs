//adiciona bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de heran�a
public class NewGameIntro : MonoBehaviour
{
    //adcionando variaveis e objetos
    public Animator introNgStart;
    public GameObject introObj;


    void Start()
    {
        //define valores iniciais
        introNgStart.SetBool("IntroStart", true);
        StartCoroutine("ExcluirIntro");
        Movimento2.estaticoGlobal = false;
    }

    //Exclue objeto depois da sua anima��o terminar
    IEnumerator ExcluirIntro()
    {
        yield return new WaitForSeconds(7);
        Movimento2.estaticoGlobal = true;
        yield return new WaitForSeconds(3);
        Destroy(introObj);
    }
}
