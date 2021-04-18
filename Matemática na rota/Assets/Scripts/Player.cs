using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int posicao = 0;
    public bool mmc;
    public int quantDados;
    public List<int> dado;
    private GameObject anima;

    public Player(GameObject preFab){
        anima = preFab;
        Instantiate(anima,Vector3.zero, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        //mmc = (Random.value > 0.5f);
        mmc = (Random.Range(0, 2) == 0);
        quantDados = 2;
        dado.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ViraMMC(){
        mmc = true;
    }

    public void ViraMDC(){
        mmc = false;
    }

    public int RolaDado(){
        return Random.Range(1, 7);
    }

    public void SetaOrdemJogadores(int dado){
        posicao = Random.Range(1, dado);
    }

    public void SetaAndando(){
        
    }
    public void SetaParado(){

    }

    public void SetaGanhou(){
        
    }
}
