using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    public static int coins = 0;
    public TextMeshProUGUI coinText;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: " + coins;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Coin")) {
            other.gameObject.transform.position = new Vector3(-10,-10,-10);
            Destroy(other.gameObject);
            coins++;
            coinText.text = "Coins: " + coins;
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            Debug.Log("Picked Up");
        }
    }
}
