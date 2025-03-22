using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int player;
    public GameObject explosionVFXPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == player)
        {
            Instantiate(explosionVFXPrefab, transform.position, transform.rotation);

            gameObject.SetActive(false);

            AudioManager.PlayOrbAudio();

        }
    }


}
