using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsPickup : MonoBehaviour
{
    public CharacterController2D characterController;
    public GameObject bootsItemImage;
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boots") {
            Destroy(other.transform.parent.gameObject);
            characterController.isBootsPickedUp = true;
            bootsItemImage.SetActive(true);
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
    }
}
