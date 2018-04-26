using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public int Damage = 1;

    public bool IsEnemyShot = false;

	// Use this for initialization
	void Start ()
	{
        // limit live time to avoid leaks
	    Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
