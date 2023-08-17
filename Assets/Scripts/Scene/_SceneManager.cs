using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    public static _SceneManager instance { get; private set; }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null) {
            instance = this;
        } else {
            Destroy (gameObject);  
        }
    }

    public void Change_Scene(string i)
    {
        SceneManager.LoadScene(i);
    }
}
