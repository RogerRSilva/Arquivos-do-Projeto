//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//adiciona biblioteca para gerenciar eventos especificos
using UnityEngine.Events;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class ExitTrigger : MonoBehaviour
{
    //declara variavel de animação
    public Animator _animator;

    //se indentificar colisão
    private void OnTriggerExit2D(Collider2D collision)
    {
        //animação inicia
        _animator.SetBool("pegou", true);
        //Movimento do Jogador é desativado
        Movimento2.estaticoGlobal = false;
    }
}
