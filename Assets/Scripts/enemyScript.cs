using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private const string GROUND_TAG = "Ground";
    void OnCollisionEnter(Collision collision)
    {
        Vector3 playerPosition = transform.position;
        print("COLISION ENTRA");
        print(playerPosition);

        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            Destroy(gameObject);
        }
    }
}
