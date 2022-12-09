//adicionando bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//adiciona biblioteca de gerenciamente de cenas
using UnityEngine.SceneManagement;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class DonaCleusaFinal : MonoBehaviour
{
    //variavel que armazena o nome da próxima cena
    public string proximaFase;
    //variaveis que armazena os objetos da cena
    public GameObject donaCleusa;
    public GameObject player;
    //animação do jogador
    public Animator plrAnim;
    //animação da Dona Cleusa
    public Animator DonaC;
    //componente de dialogo presente no objeto
    public DialogoNPC dlgDC;
    //armazena quantidade de linhas
    private int qtdLinhas;
    //objetos da cena que funcionam como limites do cenário
    public GameObject limiteCmr;
    public GameObject limiteCmr1;
    //componente de movimento do jogador
    public Movimento2 mov;
    //componente de audio
    public AudioSource trilhaSonora;
    //objeto da cena (tela de transição)
    public GameObject transicao;
    //componente de animação da camera
    public Animator camera;

    //invoca o metodo constantemente
    void Update()
    {
        //quantidade de linhas igual a quantidade de linhas lidas
        qtdLinhas = dlgDC.lineIndex;
        //se a quantidade de linhas for igual a quatro
        if(qtdLinhas == 4)
        {
            //aciona um movimento constante no jogador
            player.transform.Translate(Vector2.left * 5f * Time.deltaTime);
            //ativa animação da Dona Cleusa
            DonaC.SetBool("saindo", true);
            //ativa animação do jogador
            plrAnim.SetBool("andando", true);
            //desativa animação do jogador
            plrAnim.SetBool("parado", false);
            //ativa o campo que impede a camera de seguir o jogador
            limiteCmr.SetActive(true);
            //desativa o campo que impede que o jogador saia pra fora dos limites de visão da camera
            limiteCmr1.SetActive(false);
            //desativa o controle de movimento do jogador sobre o personagem
            mov.enabled = false;
            //invoca uma rotina
            StartCoroutine("ProximaFase");
        }
    }
    //identifica se existe colisão
    public void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.tag == "Player")
        {
            camera.enabled = false;
            donaCleusa.SetActive(true);
            player.transform.localScale = new Vector3 (1, 1, 1);
            trilhaSonora.enabled = false;
        }
    }

    IEnumerator ProximaFase()
    {
        yield return new WaitForSeconds(1);
        transicao.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(proximaFase);

    }
}
