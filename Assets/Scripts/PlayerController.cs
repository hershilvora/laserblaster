using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public GameObject laserPrefab;
    public AudioClip shootSound;
    public AudioClip deathSound;
    public float speed = 1f;
    public float health = 100f;
    float xmin;
    float xmax;
    float ymin;
    float ymax;
    float xPadding = 0.3301f;
    float yPadding = 0.25f;

    // Use this for initialization
    void Start ()
    {
        float zdistance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMostSide = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zdistance));
        Vector3 rightMostSide = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, zdistance));
        Vector3 bottomMostSide = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zdistance));
        Vector3 topMostSide = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, zdistance));

        xmin = leftMostSide.x + xPadding;
        xmax = rightMostSide.x - xPadding;
        ymin = bottomMostSide.y + yPadding;
        ymax = topMostSide.y - yPadding;
	}
	
	// Update is called once per frame
	void Update ()
    {

        //x movement
        if (Input.GetKey("left"))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            
        }
        else if (Input.GetKey("right"))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            
        }

        //y movement
        if (Input.GetKey("up"))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;

        }
        else if (Input.GetKey("down"))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;

        }

        //Rotation
        /*
        if (Input.GetKey("d"))
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            RotateRight();
        }
        else if (Input.GetKey("a"))
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            RotateLeft();
        }
        */

        if (Input.GetKeyDown("space"))
        {
            GameObject laserShot = Instantiate(laserPrefab, (new Vector3(transform.position.x, (transform.position.y + yPadding + .001f), transform.position.z)), Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        float newY = Mathf.Clamp(transform.position.y, ymin, ymax);
        transform.position = new Vector3(newX, newY, transform.position.z);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyLaserController enemyLaser = collider.gameObject.GetComponent<EnemyLaserController>();
        enemyLaser.playerHit();
        health -= enemyLaser.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }
    }
    void RotateLeft()
    {
        transform.Rotate(Vector3.forward * 2);
    }

    void RotateRight()
    {
        transform.Rotate(Vector3.forward * -2);
    }
}
