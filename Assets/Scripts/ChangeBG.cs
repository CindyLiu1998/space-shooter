using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBG : MonoBehaviour
{   
    [SerializeField] Sprite[] bg;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = bg[Random.Range(0,4)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
