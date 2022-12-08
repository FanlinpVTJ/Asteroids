using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fireButton;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject bossGameObject;
    [SerializeField] private Transform playerInstantiatePivot;
    [SerializeField] private TextMeshProUGUI asteroidsKillCount;
    [SerializeField] private JoystickRotation joystickRotation;
    [SerializeField] private JoystickMovement joystickMovement;
    [SerializeField] private PlayerLaserShot laserShot;
    [SerializeField] private float spawnInterval;
    [SerializeField] private int ascteroidsCountToWin;

    public static GameController staticGameController;
    private AsteroidInstantiate asteroidInstantiate;
    private SceneChanger sceneChanger;
    private HealthSystem bossCount;

    public bool asteroidSpawnerSwitch;
    private int asteroidsKilled = 0;
    private int playerLives = 0;

    public void Awake()
    {
        if (staticGameController == null)
        {
            staticGameController = this;
        }
    }

    private void Start()
    {
        Time.timeScale = 0;
        asteroidInstantiate = GetComponent<AsteroidInstantiate>();
        sceneChanger = GetComponent<SceneChanger>();
        if (bossGameObject != null) bossCount = bossGameObject.GetComponent<HealthSystem>();
        StartGame();
        asteroidsKillCount.text = $"Убито: {asteroidsKilled} астероидов!";
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && sceneChanger.resetGame)
        {
            RestartGame();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            StartScene_0();
        }
        if (asteroidsKilled >= ascteroidsCountToWin && SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(sceneChanger.SceneChangerCoroutine(0,2));
        }
        if (SceneManager.GetActiveScene().buildIndex == 2 && !bossGameObject.activeInHierarchy)
        {
            StartCoroutine(sceneChanger.SceneChangerCoroutine(0, 3));
        }
        if (player.activeSelf == false)
        {
            RestartGame();
        }
    }

    public void StartGame()
    {
        StartCoroutine(sceneChanger.SceneChangerCoroutine(1,1));
        StartCoroutine(AsteroidSpawn());
        PlayerInstantiate();
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        StartCoroutine(sceneChanger.SceneChangerCoroutine(0, SceneManager.GetActiveScene().buildIndex, true));
    }
    public void StartScene_0()
    {
        StartCoroutine(sceneChanger.SceneChangerCoroutine(0, 0));
    }

    public void PlayerInstantiate()
    {
        playerLives++;
        player = Instantiate(player, playerInstantiatePivot.transform.position, Quaternion.Euler(0f, 0f, 0f));
        var playerBehaviour = player.GetComponent<PlayerBehavior>();
        var playerLaserShot = player.GetComponent<PlayerLaserShot>();
        var joysticFireButton = fireButton.GetComponent<ButtonFireScript>();
        var joystickMovementRotation = joystickMovement.GetComponent<JoystickMovement>();
        playerBehaviour.Initialize(joystickRotation, joystickMovement);
        joysticFireButton.Initialize(playerLaserShot, joystickRotation);
        //joystickMovementRotation.Initialize(playerBehaviour);
    }

    public void AsteroidsKilledCount()
    {
        asteroidsKilled++;
        asteroidsKillCount.text = $"Убито: {asteroidsKilled} астероидов!";
    }

    public IEnumerator AsteroidSpawn()
    {
        while (asteroidSpawnerSwitch)
        {
            asteroidInstantiate.GetAsteroidInstantiate();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}   
