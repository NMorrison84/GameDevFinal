using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Scene order
MainMenu
MoreMenu
Tutorial
Credits
Options
Intro
*/

public class PauseMenu : MonoBehaviour
{
  static public int temp;
  public bool isPaused;
  public GameObject PauseMenuObject;
 void Start(){
  if(SceneManager.GetActiveScene().buildIndex != 17){ //Game over
  isPaused = false;
  PauseMenuObject.SetActive(false);
  }else{
    PauseMenuObject.SetActive(true);
  }
 }
 void Update(){
  if(Input.GetKeyDown(KeyCode.Escape)){
    if(isPaused){
      Resume();
    }else{
      Pause();
    }
  }
 }
    // Start is called before the first frame update
  public void Save()
  {
    temp =  SceneManager.GetActiveScene().buildIndex;
    Debug.Log("Saving");
    PauseMenuObject.SetActive(false);
    Time.timeScale = 1f;
    isPaused = false; //Intro
  }
public void Pause(){
  PauseMenuObject.SetActive(true);
  Time.timeScale = 0f;
  isPaused = true;
}
  public void Quit()
  {
    Application.Quit();
  }
    public void Load()
    {
    SceneManager.LoadScene(PauseMenu.temp);
    Debug.Log("Loading");
    PauseMenuObject.SetActive(false);
    Time.timeScale = 1f; //More
    }
  public void Resume()
    {
    PauseMenuObject.SetActive(false);
    Time.timeScale = 1f; //More
    isPaused = false;
    }

}
