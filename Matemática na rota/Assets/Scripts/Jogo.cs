using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour
{
    public int casaFinal = 140;

    public int quantJogador = 2;

    public int jogadorAtual = 0;

    public int casasAndadas;

    public List<Player> Jogadores;

    public bool repete = true;

    // Start is called before the first frame update
    void Start()
    {
        casasAndadas = 0;
        foreach (Player item in Jogadores){
            item.SetaOrdemJogadores(quantJogador);
            while (repete){
                repete = false;
                for (int j = 0; j < Jogadores.Count; j++){
                    if (item.posicao == Jogadores[j].posicao){
                        repete = true;
                    }
                }  
                item.SetaOrdemJogadores(quantJogador);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        casasAndadas = 0;
        AtualizaJogadorAtual();
    }

    void AtualizaJogadorAtual(){
        if (jogadorAtual >= (quantJogador-1)){
            jogadorAtual = 0;
        }
        else if (Jogadores[jogadorAtual].posicao == casaFinal){
            jogadorAtual++;
        }
        else {
            jogadorAtual++;
        }
    }
}
