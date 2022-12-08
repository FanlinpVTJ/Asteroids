using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectDestroyCoroutine : MonoBehaviour
{
    [SerializeField] SpriteRenderer explosionStart;
    [SerializeField] SpriteRenderer explosionMid;
    [SerializeField] SpriteRenderer explosionEnd;

    public void StartCoroutine(bool changeGameObjectSetActiv, bool destroyGameObject)
    {
        StartCoroutine(ExplosionSpriteSpawn(changeGameObjectSetActiv, destroyGameObject));
    }
    private IEnumerator ExplosionSpriteSpawn(bool changeGameObjectSetActiv, bool destroyGameObject)
    {
        explosionStart = Instantiate(explosionStart, gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(0.05f);
        Destroy(explosionStart.gameObject);
        explosionMid = Instantiate(explosionMid, gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(0.05f);
        Destroy(explosionMid.gameObject);
        explosionEnd = Instantiate(explosionEnd, gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(0.05f);
        Destroy(explosionEnd.gameObject); 

        if (changeGameObjectSetActiv)
        {
            gameObject.SetActive(false);
        }
        if (destroyGameObject)
        {
            GameController.staticGameController.AsteroidsKilledCount();
            Destroy(gameObject);
        }
    }
}
