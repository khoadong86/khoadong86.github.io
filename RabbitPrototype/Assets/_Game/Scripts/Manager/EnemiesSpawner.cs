using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemiesSpawner : MonoBehaviour
{
    [Header("Player Linked to Spawner")]
    public GameObject Player;
    [Header("Instantiate Enemies")]
    public float TimeCycle = 1f;
    /// the list of player prefabs to instantiate
    [Tooltip("The list of Enemies prefabs this manager will instantiate on Start")]
    public GameObject[] EnemiesPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        DOVirtual.DelayedCall(TimeCycle, () =>
        {
            Instantiate(EnemiesPrefabs[Random.Range(0, EnemiesPrefabs.Length)],
                new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)), Quaternion.identity);
        }, false).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
