using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlay : MonoBehaviour
{
   public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
