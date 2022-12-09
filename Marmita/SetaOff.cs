//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o c�digo funcionar
[RequireComponent(typeof(Collider2D))]
//Cria classe de heran�a
public class SetaOff : MonoBehaviour
{
    //declara objetos e variaveis
    public GameObject seta, parede;
    public static bool pegou = true;

    //invoca metodo constantemente
    public void Update()
    {
        //se a marmita estiver ativa na cena com a possibilidade de recupera��o
        if(pegou == false)
        {
            //ativa limite de cen�rio que impede do Jogador chegar ao objetivo sem a marmita
            parede.SetActive(true);
        }
        //se a marmita tiver sido recuperada 
        if(pegou == true)
        {
            //desativa limite de cen�rio que impede do Jogador chegar ao objetivo sem a marmita
            parede.SetActive(false);
        }
    }

    //identifica se existe colis�o
    public void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colis�o for o jogador
        if (other.gameObject.tag == "Player")
        {
            //se a marmita n�o tiver sido recuperada e j� estiver no campo de vis�o da camera
            if (RespawnMarmita.destroyerMarmita == true)
            {
                //desativa componente da interface que indica a posi��o da marmita
                seta.SetActive(false);
            }
        }
    }

    //identifica se n�o existe colis�o
    public void OnTriggerExit2D(Collider2D other)
    {
        //se o objeto de colis�o for o jogador
        if (other.gameObject.tag == "Player")
        {
            //se a marmita n�o estiver no campo de vis�o da camera
            if (RespawnMarmita.destroyerMarmita == true)
            {
                //se ela n�o foi recuperada
                if (pegou == false)
                {
                    //ativa o componente de interface que indica a posi��o da marmita
                    seta.SetActive(true);
                }
            }
        }
    }
}
