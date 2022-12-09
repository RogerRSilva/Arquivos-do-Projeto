//adiciona bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class CameraStopQueda : MonoBehaviour
{
    //Se o personagem "cair" no limbo da cena a camera irá parar de seguir com base nos limites de cenario
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //define game over por queda
            FollowCamera1.perdeuQueda = true;
        }

    }
}
