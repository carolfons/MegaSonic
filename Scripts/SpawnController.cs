using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject barreiraPreFab; //objeto a ser spawnado
    public float rateSpawn; //intervalo de spawn
    public float currentTime; //tempo decorrido entre um spawn e outro
    public int posicao;
    private float y;
    public float posA;
    public float posB;



    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
       
        if(currentTime >= rateSpawn)
        {
            currentTime = 0;
            posicao = Random.Range(1,100); //valor aleatório de 1 a 100
            if(posicao>50)
            {
                y = -1.65f;
            }
            else // caso a posição seja <= 50
            {
                y = -3.06f;
            }
            GameObject tempPreFab = Instantiate(barreiraPreFab) as GameObject; 
            tempPreFab.transform.position = new Vector3(transform.position.x,y,tempPreFab.transform.position.z);
        
        }
    }
}
