//adiciona bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de heran�a
public class PositionBeneStart : MonoBehaviour
{
    //declara objetos da cena
    public GameObject bene;
    public GameObject posicao;

    //invocada apenas uma vez no primeiro momento que o objeto for ativado
    void Start()
    {
        //define uma posi��o especifica para o personagem
        bene.transform.position = posicao.transform.position;   
    }

}
