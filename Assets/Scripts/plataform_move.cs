using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plataform_move : MonoBehaviour
{

    public float speed;
    public float jump_force;
    public int quant_kunai;
    public GameObject sword;
    public GameObject kunai;
    public Text text_kunais;
    public GameObject dead;
    public GameObject fade_out;

    private Vector2 dir;
    private Rigidbody2D rig;
    private bool is_ground;
    private Animator anim;
    private Vector3 scale;
    private bool is_atk;
    private Quaternion rot;
    
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        scale = transform.localScale;
    }

    
    void Update()
    {
        move();
        atk();
        text_kunais.text = quant_kunai.ToString();
    }

    //Rotina da cena de morte;
    private IEnumerator dead_scene(){
        yield return new WaitForSeconds(0.2f);
        fade_out.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        fade_out.SetActive(false);
        dead.SetActive(true);
        Destroy(gameObject, 0.1f);
    }

    //Verifica os inputs, e aplica a devida movimentação no player;
    private void move(){
        
        if(Input.GetKeyDown("space") && is_ground){
            rig.AddForce(transform.up * jump_force, ForceMode2D.Impulse);
            is_ground = false;
        }

        if(Input.GetKey("a")){
            dir = new Vector2(-1, 0);
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
            anim.Play("walk");
        }
        else if(Input.GetKey("d")){
            dir = new Vector2(1, 0);
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
            anim.Play("walk");
        }
        else{
            dir = new Vector2(0, 0);
            anim.Play("idle");
        }

        transform.Translate(dir * speed * Time.deltaTime);

    }

    //Rotina do ataque da espada;
    private IEnumerator _atk(){
        is_atk = true;
        sword.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        sword.SetActive(false);
        is_atk = false;
    }

    //Verifica se há input de ataque;
    private void atk(){
        if(transform.localScale.x > 0){
            sword.transform.position = new Vector2(transform.position.x + 0.54f, transform.position.y);
            sword.transform.localScale = new Vector2(1, 1);
        }else{
            sword.transform.position = new Vector2(transform.position.x - 0.54f, transform.position.y);
            sword.transform.localScale = new Vector2(-1, 1);
        }
        if(Input.GetMouseButtonDown(0) && !is_atk){
            StartCoroutine("_atk");
        }
        if(Input.GetMouseButtonDown(1) && quant_kunai > 0){
            if(transform.localScale.x > 0){
                rot = Quaternion.identity;
            }else{
                rot.eulerAngles = new Vector3(0, 0, 180);
            }
            Instantiate(kunai, transform.position, rot);
            quant_kunai--;
        }
    }

    //Verifica se o player está em uma região de dano;
    public void OnTriggerEnter2D(Collider2D coli){
        if(coli.tag == "dano_player"){
            StartCoroutine("dead_scene");
        }
    }

    //Verifica se o player está no chão;
    public void OnCollisionEnter2D(Collision2D coli){
        if(coli.collider.tag == "ground"){
            is_ground = true;
        }
    }

}
