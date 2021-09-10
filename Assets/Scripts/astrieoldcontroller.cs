using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class astrieoldcontroller : MonoBehaviour
{   
    public float speed = -3;
    public float tumble = 2;
    [SerializeField] GameObject exposition;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward*speed;
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -5.3f){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "PLayer" ||other.tag == "bullets" ){
            if(other.name !="bulletred(Clone)"){
                GameObject theEffect;
                theEffect = Instantiate(exposition, transform.position, transform.rotation);
                Destroy(gameObject);
                Destroy(theEffect, 2f);

                Destroy(other);
                Camera.main.DOShakePosition(1,0.2f,5,90,true);

            }
            Camera.main.GetComponent<GameController>().AddScore(1);
            
        }
    }
}
