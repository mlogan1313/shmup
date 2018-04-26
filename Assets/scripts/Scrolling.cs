using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.scripts;
using NUnit.Framework;
using UnityEngine;

public class Scrolling : MonoBehaviour {

    public Vector2 Speed = new Vector2(2, 2);

    public Vector3 Direction = new Vector3(-1, 0, 0);

    public bool IsLinkedToCamera = false;

    public bool IsLooping = false;

    private List<SpriteRenderer> _backgroundPart;

	// Use this for initialization
	void Start () {
	    if (IsLooping)
	    {
	        _backgroundPart = new List<SpriteRenderer>();

	        for (int i = 0; i < transform.childCount; i++)
	        {
	            var child = transform.GetChild(i);
	            var r = child.GetComponent<SpriteRenderer>();

	            if (r != null)
	            {
	                _backgroundPart.Add(r);
	            }

                
	        }

	        _backgroundPart = _backgroundPart.OrderBy(t => t.transform.position.x).ToList();

	    }
	}
	
	// Update is called once per frame
	void Update () {
		var movement = new Vector3(
            Speed.x * Direction.x,
            Speed.y * Direction.y,
            0
            );

	    movement *= Time.deltaTime;
	    transform.Translate(movement);

	    if (IsLinkedToCamera)
	    {
	        Camera.main.transform.Translate(movement);
	    }

	    if (IsLooping)
	    {
	        var firstChild = _backgroundPart.FirstOrDefault();

	        if (firstChild != null)
	        {
	            if (firstChild.IsVisibleFrom(Camera.main) == false)
	            {
	                var lastChild = _backgroundPart.LastOrDefault();

	                if (lastChild != null)
	                {
	                    var lastPosition = lastChild.transform.position;
	                    var lastSize = (lastChild.bounds.max - lastChild.bounds.min);

	                    firstChild.transform.position = new Vector3(lastPosition.x + lastSize.x,
	                        firstChild.transform.position.y,
	                        firstChild.transform.position.z);

	                    _backgroundPart.Remove(firstChild);
	                    _backgroundPart.Add(firstChild);
                    }
	                
	            }
	        }
	    }
	}
}
