//adiciona bibliotecas pr�prias do Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cria classe de heran�a
public class NovoJogo : MonoBehaviour
{
    //se a op��o de Novo jogo for selecionada o m�todo abaixo � invocado
    public void Novojogo()
    {
        //define que n�mero de fases desbloqueadas � zero, todo o progresso (caso tenha) � perdido
        SaveFaseCarregar.fase = 0;
        PlayerPrefs.SetInt("dbFase", SaveFaseCarregar.fase);
    }
}
