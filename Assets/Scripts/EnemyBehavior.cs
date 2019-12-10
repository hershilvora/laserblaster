using UnityEngine;
using System.Collections;


public class EnemyBehavior : MonoBehaviour
{
    public GameObject enemyLaserPrefab;
    public float health = 100;
    float enemyPadding = 0.3371f;
    public float shotsPerSeconds = 0.5f;
    public int scoreVal = 100;
    private ScoreKeeper scoreKeeper;
    public AudioClip enemyShootSound;
    public AudioClip enemyDeathSound;
    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        LaserController playerLaser = collider.gameObject.GetComponent<LaserController>();
        playerLaser.enemyHit();
        health -= playerLaser.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
            scoreKeeper.Score(scoreVal);
            AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);
        }
    }

    void Update()
    {
        float probability = Time.deltaTime * shotsPerSeconds;
        if (Random.value < probability)
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject enemyLaserShot = Instantiate(enemyLaserPrefab, new Vector3(transform.position.x, (transform.position.y - enemyPadding - 0.001f), transform.position.z), Quaternion.identity);
        AudioSource.PlayClipAtPoint(enemyShootSound, transform.position);
    }
}
