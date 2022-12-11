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


        if((Input.GetAxis("Horizontal") > 0) & (!EstaPulando) ){
            animacao.SetBool("Andando", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);

        }

        if((Input.GetAxis("Horizontal") < 0 ) & (!EstaPulando)){
            animacao.SetBool("Andando", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        
        if(Input.GetAxis("Horizontal") == 0 ){
            animacao.SetBool("Andando", false);

        }

        
    }


    void pulo(){
        if(Input.GetButtonDown("Jump")){


            if(!EstaPulando){

                EstaPulando = true;
                
                rig.AddForce(new Vector2(0f, ForcaDoPulo), ForceMode2D.Impulse);
                animacao.SetBool("Pulando", true);
                PuloDuplo = true;

            }else{

                if(PuloDuplo){
                    animacao.SetBool("AnimPuloDuplo", true);
                    rig.AddForce(new Vector2(0f, ForcaDoPulo), ForceMode2D.Impulse);
                    PuloDuplo = false;
                }
            }

            /*if(!EstaPulando){

                EstaPulando = !EstaPulando;
                rig.AddForce(new Vector2(0f, ForcaDoPulo), ForceMode2D.Impulse);
                animacao.SetBool("pulando", true);

            }else if(!PuloDuplo){

                PuloDuplo = !PuloDuplo;
                rig.AddForce(new Vector2(0f, ForcaDoPulo), ForceMode2D.Impulse);
                animacao.SetBool("pulando", true);

            }*/

        }
    }


    void OnCollisionEnter2D(Collision2D colisao){
        if(colisao.gameObject.layer == 8){
            animacao.SetBool("Pulando", false);
            EstaPulando = false;
            animacao.SetBool("AnimPuloDuplo", false);
        }
    }

    void OnCollisionExit2D(Collision2D colisao){
        if(colisao.gameObject.layer == 8){
            EstaPulando = true;
            animacao.SetBool("Andando", false);
        }
    }
   
}
