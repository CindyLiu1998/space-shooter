using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class player : MonoBehaviour
{   
    [SerializeField] float speed = 5;
    [SerializeField] float rotate = 5;
    [SerializeField] Transform bulletPos;
    [SerializeField] GameObject bullet;
    [SerializeField] float fireinterval;
    [SerializeField] float nextinterval;
    [SerializeField] GameObject exposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate(){
        Move();
    }
    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    private void Fire(){
        if(Time.time > nextinterval){
            nextinterval = Time.time + fireinterval;
            Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            gameObject.GetComponent<AudioSource>().Play();
        }
        
    }
    private void Move(){

        //Debug.Log(GetComponent<Rigidbody>().position);

        float moveHorizontal, moveVertical;
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(moveHorizontal, 0f, moveVertical);
        GetComponent<Rigidbody>().velocity = moveVector*speed;

        //rotate
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0,0, GetComponent<Rigidbody>().position.x*-rotate);

        //range
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, -4.0f,3.8f),-26.54f,Mathf.Clamp(GetComponent<Rigidbody>().position.z, -3.8f,4.3f));

    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "astreoid" ||other.tag == "bullets" ||other.tag == "enemys"){
            if(other.name !="bulletgreen(Clone)"){
                GameObject theEffect;
                theEffect = Instantiate(exposition, transform.position, transform.rotation);
                Destroy(gameObject);
                Destroy(theEffect, 2f);

                Destroy(other);
                Camera.main.GetComponent<GameController>().GameOver();
                Camera.main.DOShakePosition(1,0.2f,5,90,true);

            }
            
            

        }
        
    }
    
}
