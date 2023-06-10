using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ObstacleLoopManager : MonoBehaviour
{
    // Objects need to spawn dynamically
    public GameObject[] ObstaclePrefabs;

    // transform of the Player
    private Transform playerTransform;
    public float SpawnZ = 100.0f;
    private float SpawnLength = 100.0f;
    private float safeZone = 101.0f;
    private int AmtObstacleGroup = 2;
    private List<GameObject> ActiveObstacleGroups;
    private int LastPrefabIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
        ActiveObstacleGroups = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < AmtObstacleGroup; i++){
            SpawnObstacleGroup();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(playerTransform.position.z - safeZone> (SpawnZ - AmtObstacleGroup * SpawnLength))
        {
            SpawnObstacleGroup();

            DeleteObstacleGoup();
        }
    }

    private void SpawnObstacleGroup(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(ObstaclePrefabs[RamdomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * SpawnZ;
        SpawnZ += SpawnLength;
        ActiveObstacleGroups.Add(go);
    }

    private void DeleteObstacleGoup()
    {
        Destroy(ActiveObstacleGroups[0]);
        ActiveObstacleGroups.RemoveAt(0);
    }

    private int RamdomPrefabIndex()
    {
        if (ObstaclePrefabs.Length <= 1)
            return 0;

        int RandomIndex = LastPrefabIndex;
        while (RandomIndex == LastPrefabIndex)
        {
            RandomIndex = Random.Range(0, ObstaclePrefabs.Length);
        }

        LastPrefabIndex = RandomIndex;
        return RandomIndex;
    }
}
