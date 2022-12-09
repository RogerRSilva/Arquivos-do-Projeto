//adiciona as bibliotecas do unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//declarando requerimento do componente "colisor 2D" para o código funcionar
[RequireComponent(typeof(Collider2D))]
//cria classe de herança
public class Movimento2 : MonoBehaviour
{
    //declara váriavel global que define quando o jogador pode se movimentar ou não
    public static bool estaticoGlobal = true;

    //variaveis de direção
    public static bool left = false;
    public static bool right = false;

    public bool esquerda;
    public bool direita;

    //Variaveis do audio
    public AudioSource pulando;

    //Variaveis referente a movimento
    public Rigidbody2D rb;
    public static float moveSpeed = 6.5f;
    public float direction;

    //Variaveis referente a direção que o personagem se move
    private Vector3 fcRight;
    private Vector3 fcLeft;
    public Transform player;
    public Transform player2;

    //variaveis referente a animação de movimento
    public Animator animacao;
    public Animator animacao2;

    //Variaveis referente ao pulo,pulo duplo e força de repulsão ao enconstar nos inimigos
    public bool chaoTrue;
    public Transform detectarOChao;
    public LayerMask defineOQueSeriaChao;
    //variavel que define o tamanho do detector
    public float tamanhoCirculo;

    //quantidade de pulos extras
    public int pulosExtras = 1;
    public static bool podePular = true;
    public static bool colidiu = false;
    public static bool bGround;
    //força de repulsão
    public float bounceforce;

    //invoca o objeto no primeiro momento
    void Start()
    {
        //Definindo valores de direção
        left = false;
        right = false;

        fcRight = transform.localScale;
        fcLeft = transform.localScale;
        fcRight.x = fcRight.x * -1;

        //reconhece o componente utilizado
        rb = GetComponent<Rigidbody2D>();
    }

    //invoca o objeto constantemente
    void Update()
    {
        //codigo para aplicar o movimento de acordo com os botões
        direction = Input.GetAxis("Horizontal"); 

        // Movimento = 0 por causa do Game Over
        if(PlayerHP.playerhp == 0)
        {
            rb.velocity = Vector2.zero;
        }

        //definindo colisões com base na direção
        if (left == true)
        {
            colidiu = true;
        }

        if(right == true)
        {
            colidiu = true;
        }

        if(right == false && left == false)
        {
            colidiu = false;
        }

        //Se for possível se movimentar
        if (estaticoGlobal == true)
        {
            rb.constraints = ~RigidbodyConstraints2D.FreezePosition;
            
            //define se colidiu com inimigos e de qual direção
            if (PlayerHP.tomoDano == true)
            {
                if (direita == true)
                {
                    rb.AddForce(new Vector2(bounceforce * -1, 0), ForceMode2D.Impulse);
                    StartCoroutine("KnockBack");
                }
                if (esquerda == true)
                {
                    rb.AddForce(new Vector2(bounceforce, 0), ForceMode2D.Impulse);
                    StartCoroutine("KnockBack");
                }
            }

            if (chaoTrue)
            {
                if (Input.GetAxis("Horizontal") != 0)
                {
                    //esta andando
                    animacao.SetBool("andando", true);
                    animacao.SetBool("parado", false);
                    animacao2.SetBool("andando", true);
                    animacao2.SetBool("parado", false);
                }
                else
                {
                    //esta parado
                    animacao.SetBool("andando", false);
                    animacao.SetBool("parado", true);
                    animacao2.SetBool("andando", false);
                    animacao2.SetBool("parado", true);

                }
            }

                chaoTrue = Physics2D.OverlapCircle(detectarOChao.position, tamanhoCirculo, defineOQueSeriaChao);

            //se ele apertar os botões de pulo uma força positiva é aplicada ao personagem no eixo Y
            if (podePular == true)
            {
                if (Input.GetButtonDown("Jump") && chaoTrue == true)
                {
                    rb.velocity = Vector2.up * 12;
                    pulando.Play();

                }
                if (chaoTrue == true)
                {
                    animacao.SetBool("pulando", false);
                    animacao2.SetBool("pulando", false);            
                }
                if (chaoTrue == false)
                {
                    animacao.SetBool("pulando", true);
                    animacao.SetBool("andando", false);
                    animacao2.SetBool("pulando", true);
                    animacao2.SetBool("andando", false);
                }
                
                //Define se os valores atendem os requisitos para que o player possa efetuar pulo duplo
                if (Input.GetButtonDown("Jump") && chaoTrue == false && pulosExtras > 0)
                {
                    rb.velocity = Vector2.up * 12;
                    pulando.Play();
                    pulosExtras--;
                }

                if (chaoTrue)
                {
                    pulosExtras = 1;
                }
                if(direction == -1 || direction == 1)
                {
                    bGround = true;
                }
                else
                {
                    bGround = false;
                }
            }

            //Se ele se mover para a esquerda a imagem do personagem se vira para o lado esquerdo
            if (direction > 0)
            {
                player.localScale = fcRight;
                player2.localScale = fcRight;
                direita = true;
                esquerda = false;
            }
            //Se ele se mover para a direita a imagem do personagem se vira para o lado direito
            if (direction < 0)
            {
                player.localScale = fcLeft;
                player2.localScale = fcLeft;
                direita = false;
                esquerda = true;
            }

            //ao colidir com inimigos
            if (colidiu == false)
            {
                if (PlayerHP.tomoDano == false)
                {
                    rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
                }
             
            }

            if(colidiu == true)
            {
                if(right == true)
                {
                    if(direction < 0)
                    {
                        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

                    }
                }
                if (left == true)
                {
                    if (direction > 0)
                    {
                        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
                    }
                }
            }
        }

        //Impede o movimento em casos específicos
        if (estaticoGlobal == false)
        {
            if (PlayerHP.playerhp != 0)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                animacao.SetBool("andando", false);
                animacao.SetBool("parado", true);
                animacao2.SetBool("andando", false);
                animacao2.SetBool("parado", true);
            }
        }
    }

    //Impulso ao colidir com inimigos
    IEnumerator KnockBack()
    {
        yield return new WaitForSeconds(0.1f);
        PlayerHP.tomoDano = false;
    }
}
