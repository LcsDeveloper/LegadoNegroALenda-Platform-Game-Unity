using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    public float speed;
    public float radius;
    public float time_energy;
    public float life;
    public GameObject atk_zone;
    public Image life_bar;
    public GameObject fade_out;
    public GameObject fim;

    private Transform player;
    private float dir;
    private Animator anim;
    private Vector3 scale;
    private bool is_cansado;
    private float life_set;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
        scale = transform.localScale;
        StartCoroutine("cansado");
        life_set = life;
    }

    void Update()
    {
        life_bar.fillAmount = life/life_set;
        if(life <= 0){
            fade_out.SetActive(true);
            fade_out.GetComponent<Animator>().Play("fade_out");
            fim.SetActive(true);
            fim.GetComponent<Animator>().Play("fim");
            Destroy(gameObject);
        }
        if(player && !is_cansado){
            find_player();
        }
    }

    //Rotina da fase parada do boss;
    private IEnumerator cansado(){
        is_cansado = false;
        yield return new WaitForSeconds(time_energy);
        is_cansado = true;
        atk_zone.SetActive(false);
        anim.Play("cansado");
        yield return new WaitForSeconds(2f);
        StartCoroutine("cansado");
    }

    //Localiza o player e aplica uma velocidade na direção dele;
    private void find_player(){
        dir = player.position.x - transform.position.x;
        if(radius < Mathf.Sqrt(dir*dir)){
            if(dir < 0){
                dir = -1;
            }
            else{
                dir = 1;
            }
            transform.localScale = new Vector3((-dir)*scale.x, scale.y, scale.z);
            transform.Translate(new Vector2(dir, 0) * speed * Time.deltaTime);
            anim.Play("walk");
            atk_zone.SetActive(false);
        }else{
            anim.Play("atk");
            atk_zone.SetActive(true);
        }
    }

    //Verifica se o boss foi atacado;
    private void OnTriggerEnter2D(Collider2D colli){
        if(colli.tag == "dano_inimigo"){
            life--;
        }
    }
}
