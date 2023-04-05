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

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
  public void Play()
  {
    SceneManager.LoadScene(5); //Intro
  }

  public void Quit()
  {
    Application.Quit();
  }
    public void More()
    {
    SceneManager.LoadScene(1); //More
    }
}
