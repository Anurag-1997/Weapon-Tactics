using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool sharedInstance;
    public List<GameObject> PooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    private void Awake()
    {
        sharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PooledObjects = new List<GameObject>();
        GameObject temp;
        for(int i=0;i<amountToPool;i++)
        {
            temp = Instantiate(objectToPool);
            temp.SetActive(false);
            PooledObjects.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
