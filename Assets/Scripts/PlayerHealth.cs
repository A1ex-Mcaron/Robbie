using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject deathVFXPrefab;

    int trapsLayer;
    // Start is called before the first frame update
    void Start()
    {
        trapsLayer = LayerMask.NameToLayer("Traps");
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == trapsLayer)
        {

            Instantiate(deathVFXPrefab, transform.position, transform.rotation);

            gameObject.SetActive(false);

            AudioManager.PlayDeathAudio();
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
