using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class epilepsy : MonoBehaviour
{
    Image image;

    public TextMeshProUGUI text;



    Color[] colors = { 
        new Color(0.47451f, 0.83137f, 0.81569f, 1.0f), //Blue
        new Color(0.36863f, 0.65098f, 0.34118f, 1.0f), //Green
        new Color(0.73333f, 0.72941f, 0.23529f, 1.0f), //Yellow
        new Color(0.85882f, 0.54118f, 0.26275f, 1.0f), //Orange
        new Color(0.85882f, 0.28627f, 0.26275f, 1.0f), //Red
        new Color(0.85882f, 0.26275f, 0.82353f, 1.0f), //Pink
        new Color(0.59608f, 0.26275f, 0.62353f, 1.0f), //Purple
        new Color(0.18039f, 0.21569f, 0.73725f, 1.0f) //Dark blue
     };
     int whichColor = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerStats.coins * 50 + PlayerStats.lives * 20 - PlayerStats.hour * 200 - PlayerStats.min * 200/60;
        text.text = "Score: " + score.ToString();
        image = GetComponent<Image>();
        InvokeRepeating("changeBackground",0.0f,0.15f);
    }

    void changeBackground() {
        image.color = colors[whichColor];
        whichColor++;
        if(whichColor == colors.Length)
            whichColor = 0;
    }


}
