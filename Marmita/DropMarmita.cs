//Adiciona as bibliotecas da Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class DropMarmita : MonoBehaviour
{
    //declara objeto da cena que funciona como um icone pra destacar outro objeto 
    public GameObject borda;
    //variavel de posição
    public bool pos = false;
    //declara o objeto marmita
    public GameObject marmitaObj;
    //variavel que define quando o objeto pode ser recuperado ou não
    public bool podeRecuperar;
    //componente de física do Unity
    private Rigidbody2D marmitinha;
    //variavel que armazena a força de impulso
    private int impulso = 5;
    //variavel que define quando existe colisão
    public bool colidiu;

    //invoca o metodo apenas no primeiro instante
    void Start()
    {
        //define que o jogador pode recuperar o objeto
        podeRecuperar = false;
        //invoca rotina
        StartCoroutine("RecMarmita");
        //reconhece o componente do próprio objeto
        marmitinha = GetComponent<Rigidbody2D>();
        //adiciona força de impulsão ao objeto
        marmitinha.AddForce(new Vector2(impulso, 2), ForceMode2D.Impulse);    
    }

    //identifica se existe colisão
    public void OnTriggerEnter2D(Collider2D other)
    {
        //se o objeto de colisão for o jogador
        if (other.gameObject.tag == "Player")
        {
            //se o objeto puder ser recuperado
            if (podeRecuperar == true)
            {
                //desativa o componente que indica a posição da marmita
                SetaOff.pegou = true;
                //define que a marmita não existe mais na cena 
                MarmitaPos.dropou = false;
                //retorna a vida do jogador ao valor original
                PlayerHP.playerhp = 2;
                //destroi o objeto
                DestroyObj();
                //define que a marmita foi recuperada
                PlayerHP.recuperouMarmita = true;
            }
        }

        //se o objeto de colisão for uma plataforma
        if (other.gameObject.tag == "plataforma")
        {
            //define que existe colisão
            colidiu = true;
            //ativa o componente que destaca do objeto
            borda.SetActive(true);
            //impede o movimento do objeto
            marmitinha.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        if (other.gameObject.tag == "chao")
        {
            borda.SetActive(true);
            marmitinha.constraints = RigidbodyConstraints2D.FreezePosition;
            colidiu = true;
        }

        if (other.gameObject.tag == "Paredes")
        {
            if (colidiu == false)
            {
                marmitinha.constraints = RigidbodyConstraints2D.FreezePositionX;
            }
        }

        if (other.gameObject.tag == "MorteQueda")
        {
            RespawnMarmita.destroyerMarmita = true;
            DestroyObj();
        }
    }

    public void DestroyObj()
    {
        Destroy(marmitaObj);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "chao")
        {
            marmitinha.constraints = ~RigidbodyConstraints2D.FreezePosition;
            colidiu = false;
        }
    }

        IEnumerator RecMarmita()
    {
        yield return new WaitForSeconds(1);
        podeRecuperar = true;
    }
}
