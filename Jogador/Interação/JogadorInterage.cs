//adicionando bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de heran�a
public class JogadorInterage : MonoBehaviour
{
    //variavel que define intervalo em entre uma intera��o e outra
    public static bool intervaloIntera��o = false;

    //variavel de acesso global que define quando uma a��o pode acontecer
    public static bool interacao;

    //variavel que armazena componente de som
    public AudioSource porta;

    //variavel que define quando a intera��o est� ocorrendo
    public bool EstaInteragindo { get; set; }

    //identifica se existe colis�o com um campo especifico
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o obejto de colis�o for um objeto interag�vel
        if (other.gameObject.tag == "Interagiveis")
        {
            //define que a intera��o pode acontecer
            interacao = true;
        }
    }

    //identifica se n�o existe colis�o
    private void OnTriggerExit2D(Collider2D other)
    {
        //se o obejto de colis�o for um objeto interag�vel
        if (other.gameObject.tag == "Interagiveis")
        {
            //define que a intera��o n�o pode acontecer
            interacao = false;
        }

    }

    //Invoca o metodo constantemente
    void Update()
    {
        //se o intervalo entre cada intera��o n�o estiver mais ativo
        if (intervaloIntera��o == false)
        {
            //se for permitido realizar a a��o de intera��o
            if (interacao == true)
            {
                //se o Jogador estiver realizando a a��o de intera��o
                if (Input.GetButtonDown("Interage"))
                {
                    //est� interagindo
                    EstaInteragindo = true;
                }
                //se o Jogador n�o estiver realizando a a��o de intera��o
                else
                {
                    //n�o est� interagindo
                    EstaInteragindo = false;
                }
            }
        }
    }
}
