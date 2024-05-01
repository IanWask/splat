using UnityEngine;

public class coins : MonoBehaviour
{
    public float speed = 5f;
    public int value = 0;

    private float topEdge;

    private void Start(){
        topEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).y + 150f;
    }

    private void Update(){
        transform.position += Vector3.up * speed * Time.deltaTime;

        if(transform.position.y >= topEdge){
        Destroy(gameObject);
    }
    }

    
}
