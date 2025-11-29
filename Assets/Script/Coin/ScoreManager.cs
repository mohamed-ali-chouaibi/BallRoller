using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI TextScore;
    private int score = 0;
    public int distanceMultiplier = 1;
    private Transform player;

    private void Awake(){
        if (instance == null){
            instance = this;
        }else {
            Destroy(gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update(){
        UpdateScore();
        
    }

    private void UpdateScore(){
           score = Mathf.FloorToInt(player.position.z * distanceMultiplier);
           TextScore.text = score.ToString();
    }
}
