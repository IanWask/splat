using UnityEngine;

public class Spawner : MonoBehaviour
{
   public GameObject prefab;

   public float spawnRate = 1f;

   public float minWidth = -1f;

   public float maxWidth = 1f;

    private void OnEnable(){
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable(){
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn(){

        GameObject snake1 = Instantiate(prefab, transform.position, Quaternion.identity);
        snake1.transform.position += Vector3.left * Random.Range(minWidth, maxWidth);

    }

}
