//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cria classe de herança
public class RespawnMarmita : MonoBehaviour
{
    //declara váriaveis e objetos
    public GameObject seta;
    public GameObject marmita, spawnerMarmita;
    public static bool destroyerMarmita;

    //Invoca o metodo constantemente
    void Update()
    {
        //se o objeto "marmita" for destruido por motivos exteriores (cair no limbo)
        if (destroyerMarmita == true)
        {
            //Ativa componente de interface que indica a nova posição da marmita
            seta.SetActive(true);
            //instancia um novo objeto na posição declarada
            Instantiate(marmita, spawnerMarmita.transform.position, this.gameObject.transform.rotation);
            //destroi o objeto anterior
            destroyerMarmita = false;
        }
    }
}
