
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public GameObject[] pre;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn_m", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawn_m()
    {
        int index=Random.Range(0, pre.Length);
        Instantiate(pre[index], new Vector3(53, pre[index].transform.position.y, 0.96f), pre[index].transform.rotation);
    }
    public void stop()
    {
        CancelInvoke();
    }
}
