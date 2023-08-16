using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    public string[] scenes;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Change_Scene(string i)
    {
        SceneManager.LoadScene(i);
    }
}
