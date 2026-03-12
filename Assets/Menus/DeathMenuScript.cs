using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
