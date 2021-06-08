using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomShooter : MonoBehaviour
{

    public GameObject bombPrefab;
    public float moveSpeed = 5;

    float elapsedTime; //geçen süre
    float freq = 0.2f;
    public Transform bombSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //freqten büyükse
        if ((elapsedTime += Time.deltaTime) > freq)
        {
            //spawn noktası
            //var bomb = Instantiate(bombPrefab, bombSpawn.position, Quaternion.identity);
            //instantiate ile obje oluştur
            var bomb = ObjectPooler.instance.getPoolObject();

            if (bomb != null)
            {
                bomb.transform.position = bombSpawn.position;
                bomb.transform.rotation = bombSpawn.rotation;
                //bombaya bir hız ekledik. ileri yönde bir hız verildi
                bomb.GetComponent<Rigidbody>().velocity = transform.forward *moveSpeed;
            }
            
            
            elapsedTime = 0;
        }
    }
}
