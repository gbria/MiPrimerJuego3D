using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float maxTime = 60f;
    private float countDown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        countDown = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        //El deltaTime es el tiempo en segundos que ha pasado desde que se
        //renderizó en pantalla el último frame anterior
        countDown -= Time.deltaTime;
        Debug.Log("Timer: " + countDown);

        if(countDown <= 0)
        {
            Debug.Log("Te has quedado sin tiempo... GameOver");

            //Asigna  a la variable nuevamente el valor de inicio
            Coin.coinsCount = 0;

            //Reinica la escena con la libreria SceneManagement
            SceneManager.LoadScene("MainScene");
        }
       
    }
}
