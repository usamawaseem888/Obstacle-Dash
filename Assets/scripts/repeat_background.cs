using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeat_background : MonoBehaviour
{
    float speed = 15;
    private float rpeat;
    Vector3 v;
    private player player;
    // Start is called before the first frame update
    void Start()
    {
        v=transform.position;
        rpeat = GetComponent<BoxCollider>().size.x / 2;
        player=GameObject.Find("player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.game_over == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
       
        
    }
    private void LateUpdate()
    {
        if (transform.position.x < v.x - rpeat)
        {
            transform.position = v;
        }
    }
}
