using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    static LevelLoader instance;

    private void Start()
    {
        if(instance)
        {
            Destroy(instance);
        }

        instance = this;

    }

    public void LoadLevelByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadLevelByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex +1;

        if(index < SceneManager.sceneCount)
        {
            LoadLevelByIndex(index);
        }
        else
        {
            LoadLevelByIndex(0);
        }
        
    }
}
