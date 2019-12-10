using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour
{

    public float damage = 100f;
    Vector3 top;
    
    // Use this for initialization
    void Start ()
    {
        Vector3 topSide = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, transform.position.z - Camera.main.transform.position.z));
        top = topSide;

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (transform.position.y >= top.y)
        {
            Destroy(gameObject);
        }
        

	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0,10,0);
    }

     public void enemyHit()
    {
        Destroy(gameObject);
        Debug.Log("Enemy hit with laser!");
    }

     public float GetDamage()
    {
        return damage;
    }
}
