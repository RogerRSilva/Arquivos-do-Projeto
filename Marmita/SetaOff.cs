//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//Cria classe de herança
public class SetaOff : MonoBehaviour
{
    //declara objetos e variaveis
    public GameObject seta, parede;
    public static bool pegou = true;

    //invoca metodo constantemente
    public void Update()
    {
        //se a marmita estiver ativa na cena com a possibilidade de recuperação
        if(pegou == false)
        {
            //ativa limite de cenário que impede do Jogador chegar ao objetivo sem a marmita
            parede.SetActive(true);
        }
        //se a marmita tiver sido recuperada 
        if(pegou == true)
        {
            //desativa limite de cenário que impede do Jogador chegar ao objetivo sem a marmita
            parede.SetActive(false);
        }
    }

    //identifica se existe colisão
    public void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colisão for o jogador
        if (other.gameObject.tag == "Player")
        {
            //se a marmita não tiver sido recuperada e já estiver no campo de visão da camera
            if (RespawnMarmita.destroyerMarmita == true)
            {
                //desativa componente da interface que indica a posição da marmita
                seta.SetActive(false);
            }
        }
    }

    //identifica se não existe colisão
    public void OnTriggerExit2D(Collider2D other)
    {
        //se o objeto de colisão for o jogador
        if (other.gameObject.tag == "Player")
        {
            //se a marmita não estiver no campo de visão da camera
            if (RespawnMarmita.destroyerMarmita == true)
            {
                //se ela não foi recuperada
                if (pegou == false)
                {
                    //ativa o componente de interface que indica a posição da marmita
                    seta.SetActive(true);
                }
            }
        }
    }
}
