using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;
    public GameObject objectToPool;
    List<GameObject> pooledObjects;
    public int numberOfObject;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        pooledObjects = new List<GameObject>();
        AddObjectsToPool();    
    }

    private void AddObjectsToPool()
    {
        for (int i = 0; i < numberOfObject; i++)
        {
            var obj = Instantiate(objectToPool, transform);
            obj.SetActive(false); //obje görünmez yapıldı
            pooledObjects.Add(obj); //eklendi
        }
    }

    public GameObject getPoolObject()
    {
       for (int i = 0; i < pooledObjects.Count; i++)
        {
            //obje kullanımda değilse
            if (!pooledObjects[i].activeSelf)
            {
                return pooledObjects[i];
            }
            return null;
        }
   }
}

