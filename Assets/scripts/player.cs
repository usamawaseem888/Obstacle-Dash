using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class player : MonoBehaviour
{
    private AudioSource comp;
    public AudioClip jumm,cr;
    public ParticleSystem p,run;
    private Animator play;
    private Rigidbody character;

    public float speed=15f;
    public float gm;
    bool onground; /// default set to true
   private int count = 2;
    Vector3 v=new Vector3(-2.93f,0,0.96f);
    public bool game_over;
    private float xr, yr, zr;

    // Start is called before the first frame update
    void Start()
    {
        comp=GetComponent<AudioSource>();
        play=GetComponent<Animator>();
        character = GetComponent<Rigidbody>();
        Physics.gravity *= gm;
        xr = transform.rotation.x;
        yr=transform.rotation.y;
        zr = transform.rotation.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!game_over)
        {
            run.Play();
        }
       

        if (Input.GetKeyDown(KeyCode.Space)&& count>0 && onground ==false)
        {
            comp.PlayOneShot(jumm,1.0f);
            run.Stop();
            character.AddForce(Vector3.up * speed,ForceMode.Impulse);
            count--;
            onground = false;
            play.SetTrigger("Jump_trig");
           
        }
       /* float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        character.transform.Translate(Vector3.forward*vert*Time.deltaTime *speed);
        character.transform.Translate(Vector3.right * horiz * Time.deltaTime * speed);*/
     // stand still even on hit
       if(transform.position.x!=v.x || transform.position.z != v.z)
        {
            v.y =transform.position.y;
            transform.position = v;
            transform.rotation = Quaternion.Euler(xr, 90, zr);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        count = 2;
        if (collision.gameObject.CompareTag("ground"))
        {
            
            onground = true;
            play.SetTrigger("Crouch_b");
        }
        else if (collision.gameObject.CompareTag("obstacle"))
        {
            comp.PlayOneShot(cr,1.0f);
            p.Play();
            run.Stop();
            game_over = true;
            onground=true;
            Debug.Log("gamr over");
            play.SetTrigger("Death_b");
            //play.SetBool("Death_b", true);
            //play.SetInteger("DeathType_Int", 2);
          //  Destroy(gameObject);
             
        }
    }
}
