using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enter : MonoBehaviour
{
    
    public GameObject fade_out;
    public string fase;
    
    void Update()
    {
        if(Input.GetKeyDown("space")){
            StartCoroutine("passar_cena");
        }    
    }

    //Rotina de transição entre as cenas;
    private IEnumerator passar_cena(){
        fade_out.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(fase);
    }
}
