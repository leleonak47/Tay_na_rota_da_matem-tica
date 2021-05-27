using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class Jogo : MonoBehaviour
{
    public TextMeshProUGUI LabelNomeJogador;
    public TextMeshProUGUI LabelCasaJogador;
    public TextMeshProUGUI DadosRolados;
    public TextMeshProUGUI InputResposta;
    public TextMeshProUGUI LabelTituloCalculo;
    public TextMeshProUGUI LabelDadosCalculo;

    public GameObject Modal;
    public GameObject Tabuleiro; //Jogo
    public GameObject EscolherQuantJogador;
    public GameObject Regras;
    public GameObject MenuInicial;

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
        Jogadores = new List<Player>();
        calculosModal = new Calculos();
        MudarCena.SetaTela(MenuInicial, Modal, Tabuleiro, EscolherQuantJogador, Regras);
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
                Jogadores.Add(NewPlayer(PlayerPrefab[0], "Tay"));
            else if (i == 1)
                Jogadores.Add(NewPlayer(PlayerPrefab[0], "Érebo"));
            else if (i == 2)
                Jogadores.Add(NewPlayer(PlayerPrefab[0], "Hank"));
            else if (i == 3)
                Jogadores.Add(NewPlayer(PlayerPrefab[0], "Oscar"));
            else if (i == 4)
                Jogadores.Add(NewPlayer(PlayerPrefab[0], "Renato"));
            else
                Jogadores.Add(NewPlayer(PlayerPrefab[0], "Poul"));
        }
        
        //seleciona ordem jogadores
        foreach (Player player in Jogadores){
            player.posicao = ordem;
            ordem++;
        }

        DesabilitaTodosAnima();

        AtivaJogadorAtual();

        LabelNomeJogador.SetText(Jogadores[jogadorAtual].NomePersonagem);
        LabelCasaJogador.SetText(Jogadores[jogadorAtual].casa.ToString());
    }

    void DesabilitaTodosAnima()
    {
        foreach (Player player in Jogadores)
        {
            player.anima.SetActive(false);
        }
    }

    void AtivaJogadorAtual()
    {
        Jogadores[jogadorAtual].anima.SetActive(true);
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
        LabelCasaJogador.SetText(Jogadores[jogadorAtual].casa.ToString());
}

    void GeraCasas(){
        for (int i = 0; i <7; i++){
            
        }
    }

    public void SetQuantidadeJogadores (int quant)
    {
        quantJogador = quant;
        MudarCena.SetaTela(Tabuleiro, Regras, MenuInicial, Modal, EscolherQuantJogador);

        setTabuleiro();
    }

    public void SetRegras()
    {
        MudarCena.SetaTela(Regras, MenuInicial, Modal, Tabuleiro, EscolherQuantJogador);
    }

    public void SetJogadores()
    {
        MudarCena.SetaTela(EscolherQuantJogador, Regras, MenuInicial, Modal, Tabuleiro);
    }

    public void SetMenu()
    {
        MudarCena.SetaTela(MenuInicial, EscolherQuantJogador, Regras, Modal, Tabuleiro);
    }

    public static void Sair()
    {
        Application.Quit();
    }

    public void SetCalculoModal()
    {
        DesabilitaTodosAnima();
        MudarCena.SetaTela(Modal, MenuInicial, EscolherQuantJogador, Regras, Tabuleiro);
        string teste = calculosModal.GeraDados(Jogadores[jogadorAtual].quantDados);
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
        MudarCena.SetaTela(Tabuleiro, Regras, MenuInicial, Modal, EscolherQuantJogador);
        AtivaJogadorAtual();

        print("quantJogador = " + jogadorAtual);

        StartCoroutine(EsperaSegundos(2000.0f));

        AtualizaJogadorAtual();
        print("quantJogador = " + jogadorAtual);
    }

    IEnumerator EsperaSegundos(float num)
    {
        yield return new WaitForSeconds(num);
    }

    public Player NewPlayer(GameObject preFab, string Nome)
    {
        GameObject go = Instantiate(preFab, Vector3.zero, Quaternion.identity);
        Player component = new Player(go, Nome);
        return component;
    }
}
