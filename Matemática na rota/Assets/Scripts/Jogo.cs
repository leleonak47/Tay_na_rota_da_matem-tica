using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Jogo : MonoBehaviour
{
    public TextMeshProUGUI LabelNomeJogador;
    public TextMeshProUGUI LabelCasaJogador;
    public TextMeshProUGUI DadosRolados;

    public GameObject Modal;
    public GameObject Tabuleiro; //Jogo
    public GameObject EscolherQuantJogador;
    public GameObject Regras;
    public GameObject MenuInicial;

    public MudarCena mudarCena;
    public Calculos calculosModal;

    public List<GameObject> PlayerPrefab;
    public int casaFinal = 140;
    public int quantJogador;
    public int jogadorAtual = 0;
    public int casasAndadas;
    public List<Player> Jogadores;
    int ordem = 0;
    public bool repete = true;
    public List<int> casaMMC;
    public List<int> casaMDC;
    public List<int> casa2;
    public List<int> casa3;

    // Start is called before the first frame update
    void Start()
    {
        mudarCena = new MudarCena();
        mudarCena.SetaTela(MenuInicial, Modal, Tabuleiro, EscolherQuantJogador, Regras);
    }
    public void setTabuleiro()
    {
        Modal.SetActive(false);
        casaMMC.Clear();
        casaMDC.Clear();
        casa2.Clear();
        casa3.Clear();

        casasAndadas = 0;

        for (int i =0; i < quantJogador; i++)
        {
            if (i==0)
                Jogadores.Add(new Player(PlayerPrefab[0], "Tay"));
            else if (i == 1)
                Jogadores.Add(new Player(PlayerPrefab[0], "Érebo"));
            else if (i == 2)
                Jogadores.Add(new Player(PlayerPrefab[0], "Hank"));
            else if (i == 3)
                Jogadores.Add(new Player(PlayerPrefab[0], "Oscar"));
            else if (i == 4)
                Jogadores.Add(new Player(PlayerPrefab[0], "Renato"));
            else
                Jogadores.Add(new Player(PlayerPrefab[0], "Poul"));

        }
        
        
        //seleciona ordem jogadores
        foreach (Player player in Jogadores){
            player.posicao = ordem;
            ordem++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //casasAndadas = 0;
        //AtualizaJogadorAtual();
    }

    void AtualizaJogadorAtual(){
        if (jogadorAtual >= (quantJogador-1)){
            jogadorAtual = 0;
        }
        else {
            jogadorAtual++;
        }

        if (Jogadores[jogadorAtual].posicao == casaFinal)
        {
            //Apresenta tela de vitória
            //jogadorAtual++;
        }

        casasAndadas = 0;

        LabelNomeJogador.SetText(Jogadores[jogadorAtual].NomePersonagem);
        LabelCasaJogador.SetText(Jogadores[jogadorAtual].posicao.ToString());
}

    void GeraCasas(){
        for (int i = 0; i <7; i++){
            
        }
    }

    public void SetQuantidadeJogadores (int quant)
    {
        quantJogador = quant;
        mudarCena.SetaTela(Tabuleiro, Regras, MenuInicial, Modal, EscolherQuantJogador);

        setTabuleiro();
    }

    public void SetRegras()
    {
        mudarCena.SetaTela(Regras, MenuInicial, Modal, Tabuleiro, EscolherQuantJogador);
    }

    public void SetJogadores()
    {
        mudarCena.SetaTela(EscolherQuantJogador, Regras, MenuInicial, Modal, Tabuleiro);
    }

    public void SetMenu()
    {
        mudarCena.SetaTela(MenuInicial, EscolherQuantJogador, Regras, Modal, Tabuleiro);
    }

    public void SetCalculoModal()
    {
        mudarCena.SetaTela(Modal, MenuInicial, EscolherQuantJogador, Regras, Tabuleiro);
        string teste = calculosModal.GeraDados(Jogadores[jogadorAtual].quantDados);

        Console.WriteLine(teste);
        DadosRolados.SetText(teste);

        if (Jogadores[jogadorAtual].mmc)
        {
            calculosModal.GeraMMC();
        }
        else
        {
            calculosModal.GeraMDC();
        }
    }

    public void RetornaParaTabuleiro()
    {
        mudarCena.SetaTela(Tabuleiro, Regras, MenuInicial, Modal, EscolherQuantJogador);

        //Atualiza dados dos jogadores e avança para o procimo.
    }
}
