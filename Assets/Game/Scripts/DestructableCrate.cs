using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableCrate : MonoBehaviour {

    [SerializeField]
	private GameObject _destructableCrate;

// swap the crate with destructible crate
    public void DestroyCrate()
    {
        Destroy(this.gameObject);
        Instantiate(_destructableCrate, transform.position, transform.rotation);
    }
	
	
	
}
