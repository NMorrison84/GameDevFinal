using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Scene order
MainMenu
MoreMenu
Tutorial
Credits
Intro
*/



public class MoreMenu : MonoBehaviour
{
  public static int sceneCount = 0;
    // Start is called before the first frame update
  public void Tutorial()
  {
    sceneCount = 2;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Tutorial
  }

  public void Back()
  {
    if(sceneCount == 2){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }else if(sceneCount == 3){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }else{

    }
  }
    public void Credits()
    {
      sceneCount = 3;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
