﻿using System.Collections;
using System.Collections.Generic;
using Assets.Enigma.Components.Base_Classes.Shells;
using UnityEngine;

public class CannonBase : MonoBehaviour
{

    private bool _isReloading;

    private readonly ShellBase _shell;
	// Use this for initialization
	public void Start ()
	{
	    GetComponent<Collider>().enabled = false;
	}
	
	// Update is called once per frame
	public void FixedUpdate ()
	{
		if(!_isReloading && Input.GetMouseButtonDown(0))
	    {
            Fire();
	    }

	}

    private void Fire()
    {
        var shellInstance = Instantiate(_shell, this.transform);
        shellInstance.GetComponent<Rigidbody>().velocity = new Vector3(400f, 400f);
    }
}
