using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    public int coins = 0;
    public TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        coinText.text = "Coins: " + coins;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Coin")) {
            coins++;
            coinText.text = "Coins: " + coins;
            Destroy(other.gameObject);
        }
    }
}
