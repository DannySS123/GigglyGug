using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public GameObject respawnPosition;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (transform.position.y < -10) {
            transform.position = respawnPosition.transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Monster"){
            transform.position = respawnPosition.transform.position;
        }
    }
}
