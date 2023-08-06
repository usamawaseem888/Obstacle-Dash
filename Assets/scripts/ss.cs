using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ss : MonoBehaviour
{
    public TextMeshProUGUI game;
    player p;
    // Start is called before the first frame update
    void Start()

    {
        game=GetComponent<TextMeshProUGUI>();   
        p=GameObject.Find("player").GetComponent<player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(p.game_over==true)
        {
            endgame();
        }
    }
    void endgame()
    {
        game.text = "Game Over ";
    }
}
