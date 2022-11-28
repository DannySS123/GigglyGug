using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public GameObject respawnPosition;
    public AudioClip audioClip;
    
    public TextMeshProUGUI livesText;

    public GameObject[] mobs;

    public Transform[] mobSpawnPoints;

    private GameObject[] mobReferences;

    // Update is called once per frame

    void Start() {
        livesText.text = "Lives: " + PlayerStats.lives;
        mobReferences = new GameObject[mobs.Length];
        ReSpawnMobs();
        Debug.Log($"Size of mobs: {mobs}");
    }
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
        PlayerStats.lives--;
        livesText.text = "Lives: " + PlayerStats.lives;
        DestoryMobs();
        ReSpawnMobs();
    }

    public void ReSpawnMobs() {
        for(int i = 0; i < mobs.Length; i++) {
            mobReferences[i] = Instantiate(mobs[i], mobSpawnPoints[i].position, mobSpawnPoints[i].rotation);
        }
    }

    public void DestoryMobs() {
        for(int i = 0; i < mobs.Length; i++) {
            if(mobReferences[i] != null) {
                Destroy(mobReferences[i]);
            }
        }
    }
}
