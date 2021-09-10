using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcontroller : MonoBehaviour
{   
    [SerializeField] float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up*speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 5.3f || transform.position.z < -5.3f ){
            Destroy(gameObject);
        }
    }
}
