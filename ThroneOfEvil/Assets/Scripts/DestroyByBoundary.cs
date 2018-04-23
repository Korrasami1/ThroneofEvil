﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
		if (other.CompareTag("Boulder") || other.CompareTag("Trap") || other.CompareTag("Enemy") || other.CompareTag("BurningBoulder") || other.CompareTag("TarredBoulder") || other.CompareTag("BurningEnemy") || other.CompareTag("FrozenEnemy")|| other.CompareTag("TarredEnemy") || other.CompareTag("FearedEnemy"))
        {
            Destroy(other.gameObject);
        }

    }
}
