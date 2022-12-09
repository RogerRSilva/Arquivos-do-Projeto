//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//adiciona a biblioteca do Unity para gerenciamento de eventos
using UnityEngine.Events;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de heran�a
public class BotaoInterage : MonoBehaviour
{
    //serializa variavel na interface do programa
    [SerializeField]
    //variavel que armazena o script "JogadorInterage" para utilizar as variaveis presentes no c�digo
    private JogadorInterage _jogadorInterage;

    [SerializeField]
    //variavel que armazena o(s) evento(s)
    private UnityEvent _botaoApertado;

    //variavel que armazena o componente visual do objeto
    public SpriteRenderer _destacaIcone;
    //variavel que define quando o(s) evento(s) devem ocorrer
    private bool _podeExecutar;
    //variavel de acesso global que define quando o personagem pode se mover
    public static bool onOff;


    //Invoca o metodo constantemente
    void Update()
    {
        //se for permitido acontecer a a��o
        if (_podeExecutar)
        {
            //se o jogador estiver realizando a a��o
            if(_jogadorInterage.EstaInteragindo)
            {
                //se o controle de movimento estiver ativo
                if (onOff == false)
                {
                    //desativa controle de movimento do Jogador
                    Movimento2.estaticoGlobal = false;
                    //invoca evento(s)
                    _botaoApertado.Invoke();
                    //declara que o movimento est� inativo
                    onOff = true;
                }
                //se o controle de movimento estiver inativo
                else
                {
                    //ativa controle de movimento do Jogador
                    Movimento2.estaticoGlobal = true;
                    //invoca evento(s)
                    _botaoApertado.Invoke();
                    //declara que o movimento est� ativo
                    onOff = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _podeExecutar = true;
        _destacaIcone.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _podeExecutar = false;
        _destacaIcone.enabled = false;
    }
}
