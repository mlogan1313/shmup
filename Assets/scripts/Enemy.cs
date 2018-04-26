using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Weapon[] _weapons;

	// Use this for initialization
	void Start () {
	    
	}

    void Awake()
    {
        _weapons = GetComponentsInChildren<Weapon>();
    }
	
	// Update is called once per frame
	void Update () {
	    foreach (var weapon in _weapons)
	    {
	        if (weapon != null && weapon.CanAttack)
	        {
	            weapon.Attack(true);
	        }
        }
	    
	}
}
