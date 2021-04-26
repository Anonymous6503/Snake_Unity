using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
   private static Gamemanager _instance;

   public static Gamemanager Instance { get; private set; }

   private void Awake()
   {
      Instance = this;
      
   }

   public void Play()
   {
      SceneManager.LoadScene(1);
   }
   
   public void Quit()
   {
      Application.Quit();
   }
}
