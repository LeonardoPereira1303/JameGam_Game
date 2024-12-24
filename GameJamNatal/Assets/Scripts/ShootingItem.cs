using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingItem : MonoBehaviour
{
    AudioManager audioManager;
    public float speed;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    private void Update()
    {
        transform.Translate(transform.right * transform.localScale.x * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;

        if (collision.GetComponent<ShootingAction>())
            collision.GetComponent<ShootingAction>().Action();
            
        audioManager.PlaySFX(audioManager.sfxTakeDamage);
        Destroy(gameObject);
    }

}
