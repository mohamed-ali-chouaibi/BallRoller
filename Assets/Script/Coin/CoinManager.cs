using UnityEngine;
using TMPro;


public class CoinManager : MonoBehaviour{
    public static CoinManager instance;
    public TextMeshProUGUI TextCoin;
    private int totalCoins = 0;

    private void Awake(){
        if (instance == null){
            instance = this;
        }else {
            Destroy(gameObject);
        }
    }
    public void AddCoin(int amount){
        totalCoins += amount;
        TextCoin.text = totalCoins.ToString();
    }
}
