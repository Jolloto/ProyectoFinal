using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
   [SerializeField] private Transform playerTransform;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerTransform.position;
    }
}
