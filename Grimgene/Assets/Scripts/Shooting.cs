using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public float firespeed;

    private Rigidbody2D rb;

    public GameObject fireblasteffect;
 
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        rb.velocity = new Vector2(firespeed * transform.localScale.x, 0);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player1")
        {
            FindObjectOfType<GameManager>().HurtP1();
        }

        if (other.tag == "Player2")
        {
            FindObjectOfType<GameManager>().HurtP2();
        }

        Instantiate(fireblasteffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
