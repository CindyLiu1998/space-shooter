using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warplanecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player1,player2,player3,player4,player5,player6,player7,player8,player9,player10,player11,player12;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick(int index){
        GameObject player = player1;
        switch(index){
            case 1:
                player = player1;
                break;
            case 2:
                player = player2;
                break;
            case 3:
                player = player3;
                break;
            case 4:
                player = player4;
                break;
            case 5:
                player = player5;
                break;
            case 6:
                player = player6;
                break;
            case 7:
                player = player7;
                break;
            case 8:
                player = player8;
                break;
            case 9:
                player = player9;
                break;
            case 10:
                player = player10;
                break;
            case 11:
                player = player11;
                break;
            case 12:
                player = player12;
                break;
            default:
                break;
            
        }
        Camera.main.GetComponent<GameController>().DisplayWarPlane(player);

    }
}
