using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int coins = 0;
    public static int lives = 3;

    public static float timer = 0;
    public static int hour = 0;
    public static int min = 0;
    public static int sec = 0;
    private int fps = 0;
    private int fpsTimer = 0;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI fpsText;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        sec = ((int)timer);
        if (sec == 60) {
            timer = 0;
            min++;
        }
        if (min == 60) {
            min = 0;
            hour++;
        }
        timeText.text = "Time: " + (hour == 0 ? "" : (hour + ":")) + (min == 0 ? "" : (min + ":")) + sec;

        if (fpsTimer == 100) {
             fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = "FPS: " + fps;
            fpsTimer = 0;
        }
        fpsTimer++;
    }
}
