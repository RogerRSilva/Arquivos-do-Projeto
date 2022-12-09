//adiciona as bibliotecas da pr�pria Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de heran�a
public class MarmitaPos : MonoBehaviour
{
    //declara objetos e variaveis
    public GameObject limiteMapa;
    public GameObject marmita, spawnerMarmita;
    public Transform player;
    //variavel de acesso global que define quando o marmita � instanciada
    public static bool dropou;

    //invoca o metodo constantemente
    void Update()
    {
        //define que a posi��o da marmita ao ser instanciada na cena ser� sempre igual a posi��o do jogador
        transform.position = Vector2.Lerp(transform.position, player.position, 1);
        //se a vida do jogador for igual a um (indicando que recebeu dano)
        if(PlayerHP.playerhp == 1)
        {
            //se a marmita j� n�o tiver sido instanciada
            if (dropou == false)
            {
                //instancia o objeto "marmita" na cena com base na posi��o do jogador
                Instantiate(marmita, spawnerMarmita.transform.position, this.gameObject.transform.rotation);
                //declara que o objeto foi instanciado
                dropou = true;
                //ativa o componente na cena que impede que o jogador prossiga sem recuperar o objeto
                limiteMapa.SetActive(true);
            }
        }
    }
}
