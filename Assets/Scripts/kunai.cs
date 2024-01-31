using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunai : MonoBehaviour
{
    public float speed;
    void Start()
    {
        Destroy(gameObject, 2);
    }

    void Update()
    {
        transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime); //Aplica uma velocidade para frente assim que o objeto é instanciado;
    }
}
