using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> jellyPrefabs;

    void Start()
    {
        StartCoroutine(CreateJellyRoutine());
    }

    IEnumerator CreateJellyRoutine()
    {
        while (true)
        {
            CreateRandomJelly();
            yield return new WaitForSeconds(1);
        }
    }

    private void CreateRandomJelly()
    {
        if (jellyPrefabs.Count == 0)
        {
            Debug.LogError("jellyPrefabs");
            return;
        }

        GameObject selectedJellyPrefab = jellyPrefabs[Random.Range(0, jellyPrefabs.Count)];

        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.2f, 0.8f), 1.1f, 0));
        pos.z = 0.0f;

        Instantiate(selectedJellyPrefab, pos, Quaternion.identity);
    }
}