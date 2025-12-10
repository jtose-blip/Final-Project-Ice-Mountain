using UnityEngine;

public class SpawnIcicle : MonoBehaviour
{
    public GameObject[] iciclePrefab;
    public float spawnInterval = 1;
    public float spawnDelay = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnIcicles", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void SpawnIcicles()
    {
        int IcicleIndex = Random.Range(0, iciclePrefab.Length);

        Instantiate(iciclePrefab[IcicleIndex], transform.position, iciclePrefab[IcicleIndex].transform.rotation);

        //if (Input.GetKeyDown(KeyCode.E))
          //  Instantiate(iciclePrefab, transform.position, iciclePrefab.transform.rotation);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
