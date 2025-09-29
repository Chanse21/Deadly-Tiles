using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathSpace : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathSpace")) // Replace "Hazard" with the tag of the collision object
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Restart Scene");
        }
    }
}
