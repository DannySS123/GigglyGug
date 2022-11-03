using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public GameObject respawnPosition;
    public AudioClip audioClip;
    public int lives = 3;
    public TextMeshProUGUI livesText;

    // Update is called once per frame
    void Update() {
        if (transform.position.y < -20) {
            RespawnPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Monster"){
            RespawnPlayer();
        }
    }

    void RespawnPlayer() {
        transform.position = respawnPosition.transform.position;
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        lives--;
        livesText.text = "Lives: " + lives;
    }
}
