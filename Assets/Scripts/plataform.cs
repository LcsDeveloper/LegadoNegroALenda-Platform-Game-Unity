using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataform : MonoBehaviour
{

    public float erro;

    private BoxCollider2D colli;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>(); //Pega o transform do player para acessar a posição;
        colli = gameObject.GetComponent<BoxCollider2D>(); //Pega o collider do objeto, para ativar ou desativar dada situação;
    }

    
    void Update()
    {
        if(player){
            solid();
        }
    }

    //Verifica se o objeto deve, ou não estar solido;
    private void solid(){
        if((transform.position.y - erro) > player.position.y){
            colli.enabled = false;
        }
        if((transform.position.y + erro) < player.position.y){
            colli.enabled = true;
        }
    }
}
