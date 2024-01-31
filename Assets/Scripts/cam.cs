using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    private Transform player_position;
    private Vector2 dir;
    private float dist;
    private float x, y;

    public float speed_cam;
    public float limx;
    public float limX;
    public float limy;
    public float limY;

    void Update(){
        if(GameObject.FindWithTag("Player")){
            seguir_player();
        }
    }

    //Localiza o player e aplica uma velocidade em sua direção proporcional a distância entre os objetos;
    private void seguir_player(){
        player_position = GameObject.FindWithTag("Player").transform;

        x = player_position.position.x - transform.position.x;
        y = player_position.position.y - transform.position.y;
        dir = new Vector2(x, y);
        dist = Mathf.Sqrt(dir.x*dir.x + dir.y*dir.y);
        dir = new Vector2(dir.x/dist, dir.y/dist);

        if(transform.position.x <= limx && player_position.position.x < transform.position.x){
            dir = new Vector2(0, dir.y);
        }else if(transform.position.x >= limX && player_position.position.x > transform.position.x){
            dir = new Vector2(0, dir.y);
        }

        if(transform.position.y <= limy && player_position.position.y < transform.position.y){
            dir = new Vector2(dir.x, 0);
        }else if(transform.position.y >= limY && player_position.position.y > transform.position.y){
            dir = new Vector2(dir.x, 0);
        }
        
        if(y != 0 || x != 0){
            transform.Translate(dir * dist * speed_cam * Time.deltaTime);
        }
    }
}
