using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    public SwordAttack swordAttack;
    public GameObject swordItemImage;
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Sword") {
            Destroy(other.transform.parent.gameObject);
            swordAttack.isSwordPickedUp = true;
            swordItemImage.SetActive(true);
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
    }
}
