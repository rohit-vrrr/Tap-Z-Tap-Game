using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public bool gameOver;
    public GameObject ruby;
    Vector3 lastPos;
    float size;         // platform size

    // Start is called before the first frame update
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for(int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    public void StartSpawn()            // Starts to spawn platforms only when game starts
    {
        InvokeRepeating("SpawnPlatforms", 1.5f, 0.2f);
    }

    private void SpawnPlatforms()
    {
        int rand = Random.Range(0, 6);
        if(rand < 3)
        {
            SpawnX();
        }
        else if(rand >= 3)
        {
            SpawnZ();
        }
    }

    private void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);          // generating Ruby
        if (rand < 1)
        {
            Instantiate(ruby, new Vector3(pos.x, pos.y + 1, pos.z), ruby.transform.rotation);
        }
    }

    private void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);          // generating Ruby
        if (rand < 1)
        {
            Instantiate(ruby, new Vector3(pos.x, pos.y + 1, pos.z), ruby.transform.rotation);
        }
    }
}
