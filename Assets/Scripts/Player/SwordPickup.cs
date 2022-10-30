using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{

    public SwordAttack swordAttack = null;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Sword") {
            Destroy(other.gameObject);
            if (swordAttack != null) {
                swordAttack.isSwordPickedUp = true;
            }
        }
    }
}
