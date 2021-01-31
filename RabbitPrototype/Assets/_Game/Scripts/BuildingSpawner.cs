using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    /// the list of player prefabs to instantiate
    [Tooltip("The list of Building prefabs this manager will instantiate on Start")]
    public GameObject[] BuildingsPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        int bound = 100;
        for (int i = -bound; i < bound; i += 4)
        {
            for (int j = -bound; j < bound; j += 4)
            {
                int t = Random.Range(0, 1);
                int h = Random.Range(1, 4);
                Vector3 pos = new Vector3(i, h/2f, j);
                if (Random.Range(0, 4) == 0)
                {
                    GameObject newBuilding = Instantiate(BuildingsPrefabs[0], pos, Quaternion.identity);
                    newBuilding.transform.localScale = new Vector3(1f, h, 1f);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
