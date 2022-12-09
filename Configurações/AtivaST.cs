//adiciona bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de heran�a
public class AtivaST : MonoBehaviour
{
    //declara objeto da cena
    public GameObject seta;

    //ao trocar de cen�rio desativa o objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bar")
        {
                seta.SetActive(false);
        }
    }
    //ao trocar de cen�rio ativa o objeto
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bar")
        {
            if (TrilhasSonoras.falouDnCleusa == true)
            {
                seta.SetActive(true);
            }
        }
    }
}
