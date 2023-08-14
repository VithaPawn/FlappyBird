using UnityEngine;

public class PipeGenerator : MonoBehaviour {
    [SerializeField] private Transform pipePrefab;

    private float pipeSpawnTimerMax = 1.5f;
    private float minHeightPipe = -1f;
    private float maxHeightPipe = 2f;
    private float pipeSpawnTimer;


    private void Awake()
    {
        pipeSpawnTimer = pipeSpawnTimerMax;

    }

    private void Update()
    {
        pipeSpawnTimer -= Time.deltaTime;
        if (pipeSpawnTimer <= 0)
        {
            Instantiate(pipePrefab, new Vector3(10, Random.Range(minHeightPipe, maxHeightPipe), 0), Quaternion.identity);
            pipeSpawnTimer = pipeSpawnTimerMax;
        }
    }
}
