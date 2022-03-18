using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
            {

            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
           
        }
    }

