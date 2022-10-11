using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Creamos una variable.
    public static int coinsCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Coin.coinsCount++;
        Debug.Log("El juego ha comenzado y hay " + Coin.coinsCount + " monedas");

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Estamos en el Update");
    }

    /*
     *Método que se llama automáticamente cuando otro collider entra
     *en contacto con que tiene este script (La moneda)
     */
    private void OnTriggerEnter(Collider otherCollider)
    {
        //Si el otherCollider es la etiqueta "Player":
        if(otherCollider.CompareTag("Player")== true)
        {
            Coin.coinsCount--;

            Debug.Log("Hemos recogido la moneda y ahora hay " + Coin.coinsCount + " monedas");

            if(Coin.coinsCount == 0)
            {
                Debug.Log("El juego ha finalizado.");

                //Creamos un objeto gameManager y le damos como valor la busqueda del GameObjetc GameManager
                GameObject gameManager = GameObject.Find("GameManager");

                //Destruimos gameManager para (parar/eliminar) el tiempo
                Destroy(gameManager);

                //Buscamos todos los fuegos artificiales
                GameObject[] fireworksSystem = GameObject.FindGameObjectsWithTag("Fireworks");

                //Hacemos un foreach de fireworks y le damos al play
                foreach(GameObject fireworks in fireworksSystem)
                {
                    fireworks.GetComponent<ParticleSystem>().Play();
                }
            }

            Destroy(gameObject);
        }

    }
}
