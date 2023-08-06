using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float speed =10f;
    private player p_script;
  

    // Start is called before the first frame update
    void Start()
    {
        p_script = GameObject.Find("player").GetComponent<player>();/// looks for in scene
        
    }

    // Update is called once per frame
    void Update()
    {
       if (p_script.game_over!=false)
        {
            Destroy(gameObject);
            
        }
        else
        {
            movemen1t();

            boundry();
        }

       

    }
    void boundry()
    {
        if(gameObject.CompareTag("obstacle") && transform.position.x < -5)
        {
            Destroy(gameObject);
        }
        /*if (transform.position.x < -5)
        {
            Destroy(gameObject);
        }*/
    }
    void movemen1t()
    {
        transform.Translate(Vector3.left * speed*Time.deltaTime);
    }
}
