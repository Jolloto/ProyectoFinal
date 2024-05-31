using UnityEngine;

public class Coin : MonoBehaviour
{
    public ParticleSystem collectEffect;

    void OnCollisionEnter(Collision collision)      //Las monedas al ser colisionadas, por el jugador se destruyen y causa un efecto
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
