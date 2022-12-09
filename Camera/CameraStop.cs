//adicionando bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class CameraStop : MonoBehaviour
{
    //define quando a camera deve parar de seguir o personagem (paredes e limites de cenário)
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se o Objeto "Jogador" (personagem) estiver dentro do campo limite
        if (other.gameObject.tag == "Player")
        {
            //para a camera
            FollowCamera.stpCmrCenario = true;
        }

    }
    //define quando a camera deve voltar a seguir o personagem 
    private void OnTriggerExit2D(Collider2D other)
    {
        //se o Objeto "Jogador" (personagem) estiver fora do campo limite
        if (other.gameObject.tag == "Player")
        {
            //a camera volta a seguir o personagem
            FollowCamera.stpCmrCenario = false;
        }
    }
}
