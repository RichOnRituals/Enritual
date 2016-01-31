using UnityEngine;
using System.Collections;

public class LearningArea : MonoBehaviour
{
  public bool  isLearning = false;

  void OnTriggerEnter(Collider coll)
  {

        if (coll.gameObject.tag == "Player")
        {
           Debug.Log("You have entered the zone");
           isLearning = true;
        }
  }

   void OnTriggerExit(Collider coll)
   {
       if (coll.gameObject.tag == "Player")
       {
          Debug.Log("You have exited the zone");
          isLearning = false;
       }
    }

}
