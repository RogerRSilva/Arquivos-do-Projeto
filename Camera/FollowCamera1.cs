using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera1 : MonoBehaviour
{
    public Transform player;
    public float velocidade = 0.05f;
    public Vector2 armazenaPosicao;
    public Vector2 playerLastPosition;
    public static bool perdeuQueda;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (perdeuQueda == false)
        {
            if (FollowCamera.stpCamera == false && FollowCamera.stpCmrCenario == false)
            {
                playerLastPosition = player.position;
                armazenaPosicao = transform.position;
                transform.position = Vector2.Lerp(armazenaPosicao, player.position, velocidade);
            }
            else
            {
                armazenaPosicao = new Vector2(playerLastPosition.x, player.position.y);
                transform.position = Vector2.Lerp(transform.position, armazenaPosicao, velocidade);
            }
        }
    }
}
