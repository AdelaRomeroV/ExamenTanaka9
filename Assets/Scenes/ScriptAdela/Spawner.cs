using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn;

    private void Start()
    {
        InvokeRepeating("CreacionDeObjeto", 1, 3);
    }
    private void CreacionDeObjeto()
    {
        GameObject moneda = Instantiate(spawn, transform);
        moneda.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3f), 5);
        Destroy(moneda, 3f);
    }
}