//adiciona bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de heran�a
public class CameraStopQueda : MonoBehaviour
{
    //Se o personagem "cair" no limbo da cena a camera ir� parar de seguir com base nos limites de cenario
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //define game over por queda
            FollowCamera1.perdeuQueda = true;
        }

    }
}
