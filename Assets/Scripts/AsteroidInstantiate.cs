using UnityEngine;

public class AsteroidInstantiate : MonoBehaviour
{
    [SerializeField] GameObject asteroid;
    [SerializeField] private int asteroidsSpeed;
    [SerializeField] private Transform target;
    [SerializeField] Camera cam;
    private float screenWidth;
    private float screenHeight;
    
    public void GetAsteroidInstantiate()
    {
        screenWidth = (1 / (cam.WorldToViewportPoint(new Vector3(1, 1)).x - 0.5f)) / 2;
        screenHeight = (1 / (cam.WorldToViewportPoint(new Vector3(1, 1)).y - 0.5f)) / 2;
        float randomX = Random.Range(-screenWidth, screenWidth);
        float randomY = Random.Range(-screenHeight, screenHeight);
        GameObject asteroids = Instantiate(asteroid, new Vector2(randomX, randomY), Quaternion.identity);

        var directionVector = target.position - asteroids.transform.position;
        var angleOfDirectionPoint = Mathf.Atan2(directionVector.y, directionVector.x)*Mathf.Rad2Deg;
        asteroids.transform.rotation = Quaternion.Euler(0, 0, angleOfDirectionPoint-90f);
        asteroids.GetComponent<Rigidbody2D>().AddForce((directionVector/ directionVector.magnitude) * asteroidsSpeed, ForceMode2D.Impulse);
    }
}
