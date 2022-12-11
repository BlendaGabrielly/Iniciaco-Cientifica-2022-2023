using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public float Velocidade;
    private Transform Alvo;
    void Start()
    {
        Alvo = GameObject.FindGameObjectWithTag("Jogador").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, Alvo.position, Velocidade * Time.deltaTime);
       
    }
}
