using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{


    public float Velocidade = 1f;
    public bool EstaPulando;
    public bool PuloDuplo;
    public int ForcaDoPulo;
    


    private Rigidbody2D rig;
    private Animator animacao;
    // Start is called before the first frame update
    void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    { 
        movimentos();
        pulo();
    }


    void movimentos()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * Time.deltaTime * Velocidade;


        if(Input.GetAxis("Horizontal") > 0 ){
            animacao.SetBool("andando", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);

        }

        if(Input.GetAxis("Horizontal") < 0 ){
            animacao.SetBool("andando", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        if(Input.GetAxis("Horizontal") == 0 ){
            animacao.SetBool("andando", false);
            
        }


        
    }


    void pulo(){
        if(Input.GetButtonDown("Jump")){

            if(!EstaPulando){
                EstaPulando = !EstaPulando;
                rig.AddForce(new Vector2(0f, ForcaDoPulo), ForceMode2D.Impulse);
            }else if(!PuloDuplo){
                PuloDuplo = !PuloDuplo;
                rig.AddForce(new Vector2(0f, ForcaDoPulo), ForceMode2D.Impulse);
            }

        }
    }


    


    
}
