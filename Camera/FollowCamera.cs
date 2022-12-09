//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de herança
public class FollowCamera : MonoBehaviour
{
    //criando variaveis
    public Transform player;
    public static bool stpCamera = false;
    public static bool stpCmrCenario = false;
    public float velocidade = 0.05f;

    void Start()
    {
        //define valores iniciais
        stpCamera = false;
        stpCmrCenario = false;
    }

    void FixedUpdate()
    {
        //define as condições em que a camera deve seguir o personagem
        if (stpCamera == false && stpCmrCenario == false)
        {
            //Objeto "Camera" segue a posição do Objeto "Jogador" constantemente
            transform.position = Vector2.Lerp(transform.position, player.position, velocidade);
        }
    }
}
