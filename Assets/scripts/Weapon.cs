using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform ShotPrefab;

    public float ShootingRate = 0.25f;

    private float _shootCooldown;

	// Use this for initialization
	void Start ()
	{
	    _shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	    if (_shootCooldown > 0)
	    {
	        _shootCooldown -= Time.deltaTime;
	    }
	}

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            _shootCooldown = ShootingRate;

            var shotTranform = Instantiate(ShotPrefab);

            shotTranform.position = transform.position;

            Shot shot = shotTranform.gameObject.GetComponent<Shot>();
            if (shot != null)
            {
                shot.IsEnemyShot = isEnemy;
            }

            Move move = shotTranform.gameObject.GetComponent<Move>();
            if (move != null)
            {
                move.Direction = this.transform.right;
            }
        }
    }

    public bool CanAttack
    {
        get { return _shootCooldown <= 0f; }
    }
}
