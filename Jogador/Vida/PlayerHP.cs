//adicionando bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class PlayerHP : MonoBehaviour
{
    //componentes de som
    public AudioSource somTomouDano;
    public AudioSource marmitaSom;
    public AudioSource porta;

    //variaveis para o game over
    public AudioSource somGmOver;
    //diferencia sons que devem ser ativados
    public int diferenciaSonsGmOver;
    //Tela de Game Over
    public GameObject gmOver;
    //define quando é game over
    private bool AtivaGmOver;
    //objetos da cena
    public GameObject cenarioSons;
    public GameObject personagemSons;

    //define se recuperou a marmita
    public static bool recuperouMarmita;

    //texto que deve ser ativado ao receber dano
    public GameObject tomouDanoText;

    //animação do jogador ao perder a marmita
    public Animator marmita;
    //variavel com acesso global que define a vida do jogador 
    public static int playerhp;
    //variavel local para vizualisação dos valores pela interface do Unity
    public int playerHp;
    //variavel que define a vida atual
    public int hpAtual;
    //variavel de acesso global que define quando o personagem recebe dano
    public static bool tomoDano = false;
    //componente visual do personagem
    public SpriteRenderer sprite;
    //componente de fisica do Unity
    public Rigidbody2D theRB2D;
    //componente de fisica de colisão do Unity
    public CapsuleCollider2D player;
    //objeto da cena
    public GameObject damageEnemy;
    //animação do jogador
    private Animator jogador;
    //componente de fisica de colisão do Unity 
    public CapsuleCollider2D playerColisor;
    //objeto da cena (tela de transição) 
    public GameObject transicao;

    //variavel que identifica quando o personagem perde a marmita
    public bool perdeu = false;

    //invoca o metodo apenas no primeiro instante
    void Start()
    {
        //define os valores das variaveis
        playerhp = 2;
        playerhp = playerHp;
        jogador = GetComponent<Animator>();
        player = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (recuperouMarmita == true)
        {
            marmitaSom.Play();
            recuperouMarmita = false;
        }

        hpAtual = playerhp;
        if(playerhp == 2)
        {
            FollowCamera.stpCamera = false;
            marmita.SetBool("perdeu", false);
        }
        else if (playerhp == 1)
        {
            marmita.SetBool("perdeu", true);
        }
        else
        {
            if (perdeu == false)
            {
                FollowCamera.stpCamera = true;
                StartCoroutine("GameOver");
                perdeu = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "MorteQueda")
        {
            if (diferenciaSonsGmOver == 0)
            {
                somGmOver.Play();
                diferenciaSonsGmOver++;
            }
        }

        if (other.gameObject.tag == "Enemy")
        {
            playerhp--;
            tomouDanoText.SetActive(true);
            somTomouDano.Play();
            TextoFlutuante.textAtiva = true;

            if (playerhp == 1)
            {
                SetaOff.pegou = false;
                jogador.SetBool("dano", true);
                StartCoroutine("DamagePlayer");
                player.enabled = false;
                damageEnemy.SetActive(false);
                tomoDano = true;
            }
            if (playerhp == 0)
            {
                if (diferenciaSonsGmOver == 0)
                {
                    somGmOver.Play();
                    diferenciaSonsGmOver++;
                }
                player.enabled = false;
                damageEnemy.SetActive(false);
                tomoDano = true;
                jogador.SetTrigger("morto");
                Movimento2.estaticoGlobal = false;
                theRB2D.constraints = RigidbodyConstraints2D.FreezePositionY;
                playerColisor.enabled = false;
            }
        }

    }

IEnumerator DamagePlayer()
    {
        sprite.color = new Color(1f, 0.2f, 0.2f, 1f);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1f, 1f, 1f, 1f);

        yield return new WaitForSeconds(0.25f);
        jogador.SetBool("dano", false);
        damageEnemy.SetActive(true);

        for (int i = 0; i < 7; i++)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.15f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.15f);
        }
        player.enabled = true;

    }
    IEnumerator GameOver()
    {
        porta.enabled = false;
        transicao.SetActive(true);
        yield return new WaitForSeconds(1);
        cenarioSons.SetActive(false);
        personagemSons.SetActive(false);
        gmOver.SetActive(true);
    }
}
