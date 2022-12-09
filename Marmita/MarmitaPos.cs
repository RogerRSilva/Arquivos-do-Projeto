//adiciona as bibliotecas da própria Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de herança
public class MarmitaPos : MonoBehaviour
{
    //declara objetos e variaveis
    public GameObject limiteMapa;
    public GameObject marmita, spawnerMarmita;
    public Transform player;
    //variavel de acesso global que define quando o marmita é instanciada
    public static bool dropou;

    //invoca o metodo constantemente
    void Update()
    {
        //define que a posição da marmita ao ser instanciada na cena será sempre igual a posição do jogador
        transform.position = Vector2.Lerp(transform.position, player.position, 1);
        //se a vida do jogador for igual a um (indicando que recebeu dano)
        if(PlayerHP.playerhp == 1)
        {
            //se a marmita já não tiver sido instanciada
            if (dropou == false)
            {
                //instancia o objeto "marmita" na cena com base na posição do jogador
                Instantiate(marmita, spawnerMarmita.transform.position, this.gameObject.transform.rotation);
                //declara que o objeto foi instanciado
                dropou = true;
                //ativa o componente na cena que impede que o jogador prossiga sem recuperar o objeto
                limiteMapa.SetActive(true);
            }
        }
    }
}
