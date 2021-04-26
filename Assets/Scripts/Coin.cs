using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coinsCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        Coin.coinsCount++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
      
    }

    private void OnDestroy()
    {
        Coin.coinsCount--;

        if(Coin.coinsCount<=0)
        {
            GameObject timer = GameObject.Find("GameTimer");
            Destroy(timer);
            GameObject[] fireworks = GameObject.FindGameObjectsWithTag("Fireworks");
            foreach(GameObject firework in fireworks)
            {
                firework.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
