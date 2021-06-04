using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int posicao;
    public int casa;
    public bool mmc;
    public int quantDados;
    public GameObject anima;
    public string NomePersonagem;

    public Player(GameObject preFab, string Nome)
    {
        anima = preFab;
        NomePersonagem = Nome;
        mmc = (UnityEngine.Random.Range(0, 1) == 0);
        quantDados = 2;
        casa = 0;
    }

    public void ViraMMC(){
        mmc = true;
    }

    public void ViraMDC(){
        mmc = false;
    }

    public void Vira2Dados()
    {
        quantDados = 2;
    }

    public void Vira3Dados()
    {
        quantDados = 3;
    }

    public int RolaDado(){
        return Random.Range(1, 7);
    }

    public void SetaOrdemJogadores(int dado){
        posicao = Random.Range(1, dado);
    }
}
