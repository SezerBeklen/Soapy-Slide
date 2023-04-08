using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject winnScene;
    public GameObject loseScreen;

    private void Update()
    {
          if (cubeScale.cubeScale_instance.cube0.activeInHierarchy == false && cubeScale.cubeScale_instance.obstacle_Coll_Control == false)
           {
                loseScreen.SetActive(true);
                Movement.mov_instance.moveSpeed = 0;
           }
    }

    public void NextButton()
    {
        
          winnScene.SetActive(false);
          if (SceneManager.GetActiveScene().buildIndex == 2)
          {
              SceneManager.LoadScene(0);
          }
          else
          {
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
          }


        /*if (SceneManager.sceneCountInBuildSettings == asyncSceneIndex + 1)
    {
        SceneManager.UnloadSceneAsync(asyncSceneIndex);
        asyncSceneIndex = 1;
        SceneManager.LoadSceneAsync(asyncSceneIndex, LoadSceneMode.Additive);
    }
    else
    {
        if (SceneManager.sceneCount > 1)
        {
            SceneManager.UnloadSceneAsync(asyncSceneIndex);
            asyncSceneIndex++;
        }
        SceneManager.LoadSceneAsync(asyncSceneIndex, LoadSceneMode.Additive);
    }
    */


    }

    public void Retry()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
        loseScreen.SetActive(false);
       /* SceneManager.UnloadSceneAsync(asyncSceneIndex);
        SceneManager.LoadSceneAsync(asyncSceneIndex, LoadSceneMode.Additive); */
         

    }
}
