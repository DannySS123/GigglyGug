using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelStartText : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public static int level = 1;

    void Start() {
        levelText.text = "Level " + level;
    }
}
