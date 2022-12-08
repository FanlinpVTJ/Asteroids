using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Video.VideoPlayer;

public class AsteroidsOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            audioSource.Play();
            StartCoroutine(AsteroidDeath());
        }
    }

    private IEnumerator AsteroidDeath()
    {
        GameController.staticGameController.AsteroidsKilledCount();
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        yield return null;
    }
}
