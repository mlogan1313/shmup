using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public Vector2 Speed = new Vector2(10,10);

    public Vector2 Direction = new Vector2(-1, 0);

    private Vector2 _movement;

    private Rigidbody2D _rigidBodyComponent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    _movement = new Vector2(
            Speed.x * Direction.x,
            Speed.y * Direction.y
        );	
	}

    void FixedUpdate()
    {
        if (_rigidBodyComponent == null) _rigidBodyComponent = GetComponent<Rigidbody2D>();

        _rigidBodyComponent.velocity = _movement;
    }
}

