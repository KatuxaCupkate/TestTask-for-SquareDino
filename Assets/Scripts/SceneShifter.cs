using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneShifter : MonoBehaviour
{

 private void OnEnable() 
 {
     EventBus.OnGetToLastWaypoint += RestartScene;
 }  

 private void OnDisable()  
 
 {
     EventBus.OnGetToLastWaypoint -= RestartScene;
  }
    public void RestartScene()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
