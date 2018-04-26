using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // speed of the ship
    public Vector2 Speed = new Vector2(50, 50);

    private Vector2 _movement;
    private Rigidbody2D _rigidBodyComponent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// get axis info
	    var inputX = Input.GetAxis("Horizontal");
	    var inputY = Input.GetAxis("Vertical");

        _movement = new Vector2(
            Speed.x * inputX,
            Speed.y * inputY
        );

        // shooting
	    bool shoot = Input.GetButtonDown("Fire1");
	    shoot |= Input.GetButtonDown("Fire2");

	    if (shoot)
	    {
	        var weapon = GetComponent<Weapon>();
	        if (weapon != null)
	        {
	            weapon.Attack(false);
	        }
	    }
	}

    void FixedUpdate()
    {
        if (_rigidBodyComponent == null) _rigidBodyComponent = GetComponent<Rigidbody2D>();

        _rigidBodyComponent.velocity = _movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            var enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null) enemyHealth.Damage(enemyHealth.HP);

            damagePlayer = true;
        }

        if (damagePlayer)
        {
            var playerHealth = this.GetComponent<Health>();
            if (playerHealth != null) playerHealth.Damage(1);
        }
    }
}
