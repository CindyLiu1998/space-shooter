using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class GameController : MonoBehaviour
{   
    GameObject go;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] Button play, exit, choose;
    [SerializeField] ScrollRect warplaneDisplay;

    [SerializeField] GameObject player,enemy,asteroid1,asteroid2,asteroid3;
    [SerializeField] Transform playerDisplay;
    [SerializeField] Transform spownDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisplayWarPlane(GameObject playered){

        player = playered;

        warplaneDisplay.gameObject.SetActive(true);
        play.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        choose.gameObject.SetActive(true);

        Quaternion quaternion = Quaternion.Euler(0,0,0);

        if(go){
            quaternion = go.transform.localRotation;
            HideWarPlane();
        }


        go = Instantiate(playered, playerDisplay);
        go.transform.localScale = Vector3.one;
        go.transform.localRotation = quaternion;
        go.transform.DORotate(new Vector3(0,0,360),5f, RotateMode.WorldAxisAdd).SetLoops(-1,LoopType.Restart).SetEase(Ease.Linear);
        Destroy(go.transform.Find("engines_player").gameObject);
        Destroy(go.GetComponent<player>());


    }
    private void HideWarPlane(){
        Destroy(go);
    }
    public void PlayGame(){
        Quaternion quaternion = Quaternion.Euler(0,0,0);

        warplaneDisplay.gameObject.SetActive(false);
        score.gameObject.SetActive(true);
        choose.gameObject.SetActive(false);
        HideWarPlane();

        //instantiate player
        Instantiate(player,spownDisplay);
        player.transform.localScale = Vector3.one;
        player.transform.localRotation = quaternion;
        player.transform.localPosition = Vector3.zero;

        //instantiate enemy
        StartCoroutine("SpawnWaves");





    }
    private IEnumerator SpawnWaves(){
        yield return new WaitForSeconds(2);
        while(true){
            for(int i = 0;i<10;i++){
                GameObject go = asteroid1;
                float range = UnityEngine.Random.Range(0,4f);
                if(range >3){
                    Instantiate(enemy,new Vector3(Random.Range(-4.0f,3.8f),-26.54f,4.3f),Quaternion.identity);
                    //, SpawnEnemyPos
                }else{
                    if(range >0 && range <=1){
                        go = asteroid1;
                    }else if (range >1 && range <=2){
                        go = asteroid2;
                    }else if (range >2 && range <=3){
                        go = asteroid3;
                    }
                    Instantiate(go,new Vector3(Random.Range(-4.0f,3.8f),-26.54f,4.3f),Quaternion.identity);
                    //, SpawnAsteroidPos
                    
                }
                yield return new WaitForSeconds(1);

            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    int temp = 0;
    public void AddScore(int score){
        temp += score;
        this.score.text = "Score:"+temp.ToString();
    }
   
    public void GameOver(){
        
        StopCoroutine("SpawnWaves");
        play.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
        score.gameObject.SetActive(false);

    }
}
