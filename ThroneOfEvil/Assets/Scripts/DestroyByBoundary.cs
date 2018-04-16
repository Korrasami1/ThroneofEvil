using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
		if (other.tag == "Boulder" || other.tag == "Trap" || other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

    }
}
