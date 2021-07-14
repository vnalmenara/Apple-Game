using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rig;
    public Animator anim;

    public float velocity;
    public float forceJump;

    bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //retorna uma direcao no eixo X com valor entre -1(esquerda) e 1(direita)
        float direction = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(direction * velocity, rig.velocity.y);

        if(direction > 0){
            transform.eulerAngles = new Vector2(0, 0);
        }

        if(direction < 0){
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(direction != 0 && jumping == false){
            anim.SetInteger("transition", 1);
        }

        if(direction == 0 && jumping == false){
            anim.SetInteger("transition", 0);
        }

        Jump();
    }

    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && jumping == false){
            rig.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            anim.SetInteger("transition", 2);
            jumping = true;
        }
    }

    //Este método é chamado automaticamente pela Unity quando o objeto toca em outro objeto
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            jumping = false;
        }
    }
}
