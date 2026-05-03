using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartWin : MonoBehaviour
{
    public GameObject winText;
    public GameObject redLightGroup;

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameEnded)
        {
            gameEnded = true;

            redLightGroup.SetActive(true);
            winText.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}