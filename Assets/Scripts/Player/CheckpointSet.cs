using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSet : MonoBehaviour
{
    public GameObject respawnPosition;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            respawnPosition.transform.position = transform.position;
        }
    }
}
