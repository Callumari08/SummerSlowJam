using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    public string[] scenes;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void Update()
    {
        //for testing manager
        if (Input.GetKeyDown(KeyCode.I))
        {
            Change_Scene(scenes[1]);
        }
    }

    public void Change_Scene(string i)
    {
        SceneManager.LoadScene(i);
    }
}
