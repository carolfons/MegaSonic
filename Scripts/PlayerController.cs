using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D PlayerRigidBody; //variável para o corpo rígido
    public int forceJump; //variável para força do pulo

    public Animator animation; //chamando o componente de animação do personagem
    public bool slide; //variável auxiliar para slide
    
    public bool grounded; //verifica o chão
    public LayerMask whatIsGround; //verifica o chão
    public Transform GroundCheck; //chamando o componente da Unity

    //slide
    public float timeTemp;
    public float slideTemp;

    //colisor
    public Transform colisor; //chamando o component da Unity


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //pressionando o botão de pular
        if (Input.GetButtonDown("Jump") && grounded == true){//comando só funciona se o personagem estiver pisando no chão

            PlayerRigidBody.AddForce(new Vector2 (0,forceJump));

            if(slide)
            {
                 colisor.position = new Vector3(colisor.position.x,colisor.position.y + 0.75f,colisor.position.z);//caso pule
                 //o collider volta para o lugar correto
                slide = false;
            }
            
            
        }

        //pressionando o botão de deslizar
        if(Input.GetButtonDown("Slide") && grounded && !slide){//comando só funciona se o personagem estiver pisando no chão
            colisor.position = new Vector3(colisor.position.x,colisor.position.y - 0.75f,colisor.position.z);//diminuindo 
            //a posição do collider

            slide = true;
            timeTemp = 0;
          
        }

        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f,whatIsGround); //animção de pulo

        //animação de slide
        if(slide == true){

            timeTemp += Time.deltaTime;

            //quando chegar no tempo definido, a variável slide volta a ser falsa
            if(timeTemp >= slideTemp){ 
                colisor.position = new Vector3(colisor.position.x,colisor.position.y + 0.75f,colisor.position.z);//quando a slide
                //termina o collider volta a posição original
                slide = false;
            }
        }

        animation.SetBool("jump",!grounded);//grounded = false
        animation.SetBool("slide",slide);


    }

   void OnTriggerEnter2D()
   {

       Application.LoadLevel("gameOver");


   } 

}
