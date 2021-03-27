using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int posicao = 0;
    public bool mmc;

    // Start is called before the first frame update
    void Start()
    {
        //mmc = (Random.value > 0.5f);
        mmc = (Random.Range(0, 2) == 0);
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
}
