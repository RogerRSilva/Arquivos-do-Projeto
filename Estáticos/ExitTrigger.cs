//adiciona bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//adiciona biblioteca para gerenciar eventos especificos
using UnityEngine.Events;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de heran�a
public class ExitTrigger : MonoBehaviour
{
    //declara variavel de anima��o
    public Animator _animator;

    //se indentificar colis�o
    private void OnTriggerExit2D(Collider2D collision)
    {
        //anima��o inicia
        _animator.SetBool("pegou", true);
        //Movimento do Jogador � desativado
        Movimento2.estaticoGlobal = false;
    }
}
