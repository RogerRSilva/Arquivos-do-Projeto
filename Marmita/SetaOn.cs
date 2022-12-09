//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//define quando a camera deve parar de seguir o personagem (paredes e limites de cen�rio)
[RequireComponent(typeof(Collider2D))]
//Cria classe de Heran�a
public class SetaOn : MonoBehaviour
{
    //declara objeto
    public GameObject seta;

    //invoca Metodo constantemente
    void Update()
    {
        //se o objeto marmita tiver sido recuperado
        if (SetaOff.pegou == true)
        {
            //desativa componente de interface
            seta.SetActive(false);
        }
    }

    //identifica se existe colis�o
    public void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colis�o for a marmita
        if (other.gameObject.tag == "Marmita")
        {
            //ativa componente de interface
                seta.SetActive(true);
            //declara que a marmita n�o foi recuperada
                SetaOff.pegou = false;
        }
    }
}
