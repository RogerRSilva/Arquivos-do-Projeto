//adicionando bibliotecas próprias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//criando a classe de Herança
public class BackgroundMov : MonoBehaviour
{
    //criando váriaveis de configurações do fundo
    int numeroBack = 3;

    public float velocidade;

    bool movEsq = false;
    bool movDir = false;

    public GameObject posBkg;
    public GameObject posBkg1;

    //metódo Update
    void Update()
    {
        //se o personagem estiver em movimento e não estiver colidindo com nenhum objeto
        if (Movimento2.colidiu == false && FollowCamera.stpCmrCenario == false && Movimento2.estaticoGlobal == true)
        {
            //se o fundo estiver ativo
            if (Movimento2.bGround == true)
            {
                //se o personagem estiver indo para a direita, o fundo irá se mover constantemente na direção contrária 
                if (Input.GetAxis("Horizontal") > 0)
                {
                    movEsq = true;
                    movDir = false;
                    if (movEsq == true)
                    {
                        transform.position += new Vector3(velocidade * -1 * Time.deltaTime, 0, 0);
                    }
                }
                //se o personagem estiver indo para a esquerda, o fundo irá se mover constantemente na direção contrária
                if (Input.GetAxis("Horizontal") < 0)
                {
                    movDir = true;
                    movEsq = false;
                    if (movDir == true)
                    {
                        transform.position += new Vector3(velocidade * Time.deltaTime, 0, 0);
                    }
                }
            }
            //se o fundo estiver desativado
            if (Movimento2.bGround == false)
            {
                movDir = false;
                movEsq = false;
            }
        }
    }

    //define quando o fundo sai dos limites da camera e o reposiciona
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LimiteFundo")
        {
            Vector3 posicao = posBkg.transform.position;
            GetComponent<BoxCollider2D>().transform.position = posicao;
        }
        if (other.gameObject.tag == "LimiteFundo-x")
        {
            Vector3 posicao2 = posBkg1.transform.position;
            GetComponent<BoxCollider2D>().transform.position = posicao2;
        }
    }
}
