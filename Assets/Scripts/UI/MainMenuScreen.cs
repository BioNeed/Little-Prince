using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private int _sceneToLoad;

    public void StartGame()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}
