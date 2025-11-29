using UnityEngine;

public class ObstacleGenerator : MonoBehaviour{
    public GameObject[] obstaclePrefabs;
    public GameObject[] coinPrefabs;
    public Transform player;
    public Vector3 spawnPostion;
    public float coinChance = 0.5f;
    public float distanceBetweenObstacles = 15f;
    public float horizonDistance = 200f;

    void Update(){
        float distance = Vector3.Distance(player.position, spawnPostion);

        if (distance < horizonDistance){
            int x = Random.Range(-3, 4);
            spawnPostion = new Vector3(x, 1.5f, spawnPostion.z + distanceBetweenObstacles);

            if (Random.value < coinChance){
                spawnPostion.y = 0.6f;
                GameObject coinPrefab = coinPrefabs[Random.Range(0, coinPrefabs.Length)];
                Instantiate(coinPrefab, spawnPostion, Quaternion.identity);
            }else{
                GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
                Instantiate(obstaclePrefab, spawnPostion, Quaternion.identity);
            }
        }
    }
}
