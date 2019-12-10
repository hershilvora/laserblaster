using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed;
    public float spawnDelay = 0.5f;
    private bool hitRight = false;
    float xmin;
    float xmax;
    // Use this for initialization
    void Start ()
    {
        SpawnUntilFull();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < xmax && hitRight == false)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (transform.position.x >= xmax)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            hitRight = true;
        }
        else if (transform.position.x > xmin && hitRight == true)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (transform.position.x <= xmin)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            hitRight = false;
        }

        if (AllMembersDead())
        {
            Debug.Log("Empty Spawn");
            SpawnUntilFull();
        }

       
    }

    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition != null)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }

        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }

        float zdistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMostSide = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zdistance));
        Vector3 rightMostSide = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, zdistance));
        xmin = leftMostSide.x + (width / 2);
        xmax = rightMostSide.x - (width / 2);

    }
    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }

    bool AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }               
        }
        return true;
    }

    void Spawn()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }

        float zdistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMostSide = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zdistance));
        Vector3 rightMostSide = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, zdistance));
        xmin = leftMostSide.x + (width / 2);
        xmax = rightMostSide.x - (width / 2);
    }
    
}
