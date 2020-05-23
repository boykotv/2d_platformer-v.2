using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExit : MonoBehaviour
{
   public void doExit()
   {
       Debug.Log("Exit Game");
       Application.Quit();
   }
}
