using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public GameObject respawnPosition;
    public AudioClip audioClip;

    // Update is called once per frame
    void Update() {
        if (transform.position.y < -10) {
            transform.position = respawnPosition.transform.position;
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Monster"){
            transform.position = respawnPosition.transform.position;
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
    }
}
