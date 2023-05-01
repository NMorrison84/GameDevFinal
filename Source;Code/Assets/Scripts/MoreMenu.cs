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



public class MoreMenu : MonoBehaviour
{
    // Start is called before the first frame update
  public void Tutorial()
  {
    SceneManager.LoadScene(2); //Tutorial
  }
 public void Options()
  {
    SceneManager.LoadScene(3); //Tutorial
  }
  public void Back()
  {
    SceneManager.LoadScene(0);
  }
    public void Credits()
    {
    SceneManager.LoadScene(3);
    }
}
