using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    
    public string next_level;

    //Verifica se há colisão com o player, e se houver, passa para a proxima fase;
    private void OnTriggerEnter2D(Collider2D colli){
        if(colli.tag == "Player"){
            SceneManager.LoadScene(next_level);
        }
    }
}
