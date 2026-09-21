using UnityEngine;

public class DetectCollission : MonoBehaviour
{
    public int scoreToAdd;
    private GameManager gameManager;
    public AudioClip blockSound;

    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        playerController = FindFirstObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            gameManager.addScore(scoreToAdd);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        }

        else if (other.CompareTag("Player"))
        {
            gameManager.GameOver();
            Destroy(gameObject);
            playerController.disableMovement();
        }
    }
}