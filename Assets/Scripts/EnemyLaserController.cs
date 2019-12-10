using UnityEngine;
using System.Collections;

public class EnemyLaserController : MonoBehaviour {

    public float damage = 100f;

    Vector3 bottom;

	// Use this for initialization
	void Start ()
    {
        Vector3 bottomSide = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - Camera.main.transform.position.z));
        bottom = bottomSide;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y <= bottom.y)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -10, 0);
    }

    public void playerHit()
    {
        Destroy(gameObject);
        Debug.Log("Player hit with laser!");
    }

    public float GetDamage()
    {
        return damage;
    }
}


