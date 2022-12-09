//adicionando bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class JogadorInterage : MonoBehaviour
{
    //variavel que define intervalo em entre uma interação e outra
    public static bool intervaloInteração = false;

    //variavel de acesso global que define quando uma ação pode acontecer
    public static bool interacao;

    //variavel que armazena componente de som
    public AudioSource porta;

    //variavel que define quando a interação está ocorrendo
    public bool EstaInteragindo { get; set; }

    //identifica se existe colisão com um campo especifico
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o obejto de colisão for um objeto interagível
        if (other.gameObject.tag == "Interagiveis")
        {
            //define que a interação pode acontecer
            interacao = true;
        }
    }

    //identifica se não existe colisão
    private void OnTriggerExit2D(Collider2D other)
    {
        //se o obejto de colisão for um objeto interagível
        if (other.gameObject.tag == "Interagiveis")
        {
            //define que a interação não pode acontecer
            interacao = false;
        }

    }

    //Invoca o metodo constantemente
    void Update()
    {
        //se o intervalo entre cada interação não estiver mais ativo
        if (intervaloInteração == false)
        {
            //se for permitido realizar a ação de interação
            if (interacao == true)
            {
                //se o Jogador estiver realizando a ação de interação
                if (Input.GetButtonDown("Interage"))
                {
                    //está interagindo
                    EstaInteragindo = true;
                }
                //se o Jogador não estiver realizando a ação de interação
                else
                {
                    //não está interagindo
                    EstaInteragindo = false;
                }
            }
        }
    }
}
