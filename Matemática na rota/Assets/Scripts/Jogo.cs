using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Text.RegularExpressions;

public class Jogo : MonoBehaviour
{
    public TextMeshProUGUI LabelNomeJogador;
    public TextMeshProUGUI LabelCasaJogador;
    public TextMeshProUGUI TituloModalDados;
    public TextMeshProUGUI DadosRolados;
    public TMP_InputField InputResposta;
    public GameObject BtnJogaDados;
    public GameObject LabelVitoria;

    public GameObject Modal;
    public GameObject Tabuleiro; //Jogo
    public GameObject EscolherQuantJogador;
    public GameObject Regras;
    public GameObject MenuInicial;
    public GameObject ResponderErrado;

    public Calculos calculosModal;

    public List<GameObject> PlayerPrefab;
    public int casaFinal;
    public int quantJogador;
    public int jogadorAtual = 0;
    public int casasAndadas;
    public int contaParaApresentarResultado;
    public List<Player> Jogadores;
    int ordem = 0;
    public bool repete = true;
    private bool ganhou = false;
    private List<int> casaMMC = new List<int>() { 5,17,25,28,31,55,61,66,75,87,92,95,100,106,113,131,135,140};      //troca para mmc
    private List<int> casaMDC = new List<int>() { 6,18,24,27,30,56,60,67,76,86,91,94,99,105,112,130,134,139};       //troca para mdc
    private List<int> casa2dados = new List<int>() { 7,20,29,35,40,97,109,116,122};                                //passa a jogar 2 dados
    private List<int> casa3dados = new List<int>() { 3,14,26,33,37,39,41,52,59,62,68,80,84,103,127,132,136};       //passa a jogar 3 dados

    // Start is called before the first frame update
    void Start()
    {
        Jogadores = new List<Player>();
        calculosModal = new Calculos();
        MudarCena.SetaTela(MenuInicial, Modal, Tabuleiro, EscolherQuantJogador, Regras);
    }

    public void setTabuleiro()
    {
        if (LabelVitoria.active)
        { LabelVitoria.SetActive(false); }

        if (!BtnJogaDados.active)
        { BtnJogaDados.SetActive(true); }

        casaFinal = /*10; //*/142;
        Modal.SetActive(false);
        ganhou = false;

        casasAndadas = 0;
        contaParaApresentarResultado = 0;

        for (int i =0; i < quantJogador; i++)
        {
            if (i==0)
                Jogadores.Add(NewPlayer(PlayerPrefab[0], "Tay"));
            else if (i == 1)
                Jogadores.Add(NewPlayer(PlayerPrefab[0], "Érebo"));
            else if (i == 2)
                Jogadores.Add(NewPlayer(PlayerPrefab[0], "Toshinori"));
            else if (i == 3)
                Jogadores.Add(NewPlayer(PlayerPrefab[0], "Hikaru"));
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
        print("posicao "+ Jogadores[jogadorAtual].casa +" e casa final "+ casaFinal);
        if (Jogadores[jogadorAtual].casa >= casaFinal)
        {
            Jogadores[jogadorAtual].anima.GetComponent<Animator>().SetBool("ganhou", true);
            LabelVitoria.SetActive(true);
            BtnJogaDados.SetActive(false);

            ganhou = true;
        }
        else
        {
            if (jogadorAtual >= (quantJogador - 1))
            {
                jogadorAtual = 0;
            }
            else
            {
                jogadorAtual++;
            }

            casasAndadas = 0;

            LabelNomeJogador.SetText(Jogadores[jogadorAtual].NomePersonagem);
            LabelCasaJogador.SetText(Jogadores[jogadorAtual].casa.ToString());
        }
        
    }

    //void GeraCasas(){
    //    for (int i = 0; i <7; i++){
            
    //    }
    //}

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
        foreach ( Player item in Jogadores)
        {
            if (item.anima != null)
                Destroy(item.anima);
        }

        Jogadores.Clear();

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

        DadosRolados.SetText(calculosModal.GeraDados(Jogadores[jogadorAtual].quantDados));

        if (Jogadores[jogadorAtual].mmc)
        {
            TituloModalDados.SetText("Faça o MMC");
            calculosModal.GeraMMC();
        }
        else
        {
            TituloModalDados.SetText("Faça o MDC");
            calculosModal.GeraMDC();
        }
        print(calculosModal.resposta);

        ResponderErrado.SetActive(false);
    }

    public void RetornaParaTabuleiroErro()
    {
        BtnJogaDados.SetActive(false);

        MudarCena.SetaTela(Tabuleiro, Regras, MenuInicial, Modal, EscolherQuantJogador);

        AtivaJogadorAtual();

        Jogadores[jogadorAtual].anima.GetComponent<Animator>().SetBool("parado", false);

        Jogadores[jogadorAtual].casa += Convert.ToInt32(calculosModal.resposta / 2);

        VerificaMudancaNacasaEDados();

        LabelCasaJogador.SetText(Jogadores[jogadorAtual].casa.ToString());

        InputResposta.SetTextWithoutNotify("");

        StartCoroutine(TrocaJogadorAposNsec(2.0f));

        contaParaApresentarResultado = 0;

        ResponderErrado.SetActive(false);
    }

    public void RetornaParaTabuleiro()
    {
        if ((string.IsNullOrEmpty(InputResposta.text)) || (!Regex.IsMatch(InputResposta.text, @"^[0-9]+$") ))
        {
            if (!DadosRolados.text.Contains("Tente novamente \n"))
            {
                string msg = DadosRolados.text;
                msg = "Tente novamente \n" + msg;
                DadosRolados.SetText(msg);
            }

            if (contaParaApresentarResultado < 2)
            {
                contaParaApresentarResultado++;
            }
            else
            {
                ResponderErrado.SetActive(true);
            }
        }
        else if (Convert.ToInt32(InputResposta.text) == calculosModal.resposta)
        {

            BtnJogaDados.SetActive(false);

            MudarCena.SetaTela(Tabuleiro, Regras, MenuInicial, Modal, EscolherQuantJogador);

            AtivaJogadorAtual();

            Jogadores[jogadorAtual].anima.GetComponent<Animator>().SetBool("parado", false);

            Jogadores[jogadorAtual].casa += calculosModal.resposta;

            VerificaMudancaNacasaEDados();

            LabelCasaJogador.SetText(Jogadores[jogadorAtual].casa.ToString());

            InputResposta.SetTextWithoutNotify("");

            StartCoroutine(TrocaJogadorAposNsec(2.0f));

            contaParaApresentarResultado = 0;

            ResponderErrado.SetActive(false);
        }
        else
        {
            if (!DadosRolados.text.Contains("Tente novamente"))
            {
                string msg = DadosRolados.text;
                msg = "Tente novamente \n" + msg;
                DadosRolados.SetText(msg);
            }

            if (contaParaApresentarResultado < 2)
            {
                contaParaApresentarResultado++;
            }
            else
            {
                ResponderErrado.SetActive(true);
            }
        }
    }

    IEnumerator TrocaJogadorAposNsec(float num)
    {
        yield return new WaitForSeconds(num);
        Jogadores[jogadorAtual].anima.GetComponent<Animator>().SetBool("parado", true);
        AtualizaJogadorAtual();
        if (!ganhou)
            BtnJogaDados.SetActive(true);
    }

    private void VerificaMudancaNacasaEDados()
    {
        if (casaMMC.Contains(Jogadores[jogadorAtual].casa))
        {
            Jogadores[jogadorAtual].ViraMMC();
        }
        else if (casaMDC.Contains(Jogadores[jogadorAtual].casa))
        {
            Jogadores[jogadorAtual].ViraMDC();
        }
        else if (casa2dados.Contains(Jogadores[jogadorAtual].casa))
        {
            Jogadores[jogadorAtual].Vira2Dados();
        }
        else if (casa3dados.Contains(Jogadores[jogadorAtual].casa))
        {
            Jogadores[jogadorAtual].Vira3Dados();
        }
    }

    public Player NewPlayer(GameObject preFab, string Nome)
    {
        GameObject go = Instantiate(preFab, Vector3.zero, Quaternion.identity);
        Player component = new Player(go, Nome);
        return component;
    }
}
