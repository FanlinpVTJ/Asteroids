using System;
using System.Collections;
using UnityEngine;

public class PlayerOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            playerCollider.enabled = false;
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            audioSource.Play();
            StartCoroutine(RestartBecousePlayerDeath());
        }
    }
    private IEnumerator RestartBecousePlayerDeath()
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        yield return null;
    }
}