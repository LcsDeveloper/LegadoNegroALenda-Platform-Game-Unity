using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{

    public float speed;
    public float radius;
    private Transform player;
    private float dir;
    private Animator anim;
    private Vector3 scale;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
        scale = transform.localScale;
    }

    void Update()
    {
        if(player){
            find_player();
        }
    }

    //Localiza o player e aplica uma velocidade em sua direção;
    private void find_player(){
        dir = player.position.x - transform.position.x;
        if(radius < Mathf.Sqrt(dir*dir)){
            if(dir < 0){
                dir = -1;
            }
            else{
                dir = 1;
            }
            transform.localScale = new Vector3(dir*scale.x, scale.y, scale.z);
            transform.Translate(new Vector2(dir, 0) * speed * Time.deltaTime);
            anim.Play("walk");
        }else{
            anim.Play("atk");
        }
    }

    //verifica se o inimigo está em uma região de dano;
    private void OnTriggerEnter2D(Collider2D colli){
        if(colli.tag == "dano_inimigo"){
            Destroy(gameObject);
        }
    }
}
