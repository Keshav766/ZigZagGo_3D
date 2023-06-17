using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject diamondPrefab;


    Vector3 lastPos;
    float size;
    public bool gameOver = false;

    void Start()
    {
        lastPos = platformPrefab.transform.position;
        size = platformPrefab.transform.localScale.x;
    }

    public void StartSpawnSequence()
    {
        InvokeRepeating("SpawnPlatform", 0f, 0.1f);
    }

    void SpawnPlatform()
    {
        if (gameOver)
        {
            return;
        }
        int rand = Random.Range(0, 10);
        if (rand < 5)
            SpawnX();
        else if (rand >= 5)
            SpawnZ();
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platformPrefab, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand == 2)
        {
            Instantiate(diamondPrefab, new Vector3(pos.x, pos.y + 1.5f, pos.z), diamondPrefab.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platformPrefab, pos, Quaternion.identity);


        int rand = Random.Range(0, 4);
        if (rand == 2)
        {
            Instantiate(diamondPrefab, new Vector3(pos.x, pos.y + 1.5f, pos.z), diamondPrefab.transform.rotation);
        }
    }

}
