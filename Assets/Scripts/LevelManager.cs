using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    
    public void Loadlevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
    public void QuitRequest()
    {
        Debug.Log("I want to quit");
        Application.Quit();
    }

    public void LoadPreviousLevel(string name)
    {
        Debug.Log("Previous Level load requested for: " + name);
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    //public void LoadNextLevel()
    //{
    //    Application.LoadLevel(Application.loadedLevel + 1);
    //}

    //public void brickDestroyed()
   // {
    //    if (Brick.breakableBrick <= 0)
     //   {
    //        LoadNextLevel();
    //    }
  //  }
}
