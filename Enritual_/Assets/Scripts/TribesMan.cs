using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TribesMan : MonoBehaviour
{
    //GameObject with sprite assets
    [SerializeField]
    string[] BaseMovements;
    [SerializeField]
    private string[] LearnedMovement = new string[MovementLimit];
    [SerializeField]
    private bool isLearning = false;
    [SerializeField]
    private int MovementCounter = 0;
    [SerializeField]
    private GameObject areaObject;
    [SerializeField]
    private string[] GoalRitual;
    private const int MovementLimit = 6;
    private const string Ymove = "y";
    private const string Mmove = "m";
    private const string Cmove = "c";
    private const string Amove = "a";
    private const string jump = "j";
    private const string crouch = "t";
    private string[] allowedkeys = { Ymove, Mmove, Cmove, Amove, jump, crouch };
    private Transform tribesman = null;
    private LearningArea area = null;
    private GameObject player = null;
    
    void Start()
    {
        if (tribesman == null)
        {
            tribesman = gameObject.GetComponent<Transform>();
        }

        if (area == null)
        {
            area = areaObject.GetComponent<LearningArea>();
        }

        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }
    
	// Update is called once per frame
	void Update ()
    {
        if (area.isLearning == false && BaseMovements.Length != 0)
        {
            player.GetComponentInChildren<BasicPlayer>().enabled = true;
            //StartCoroutine(doBaseMovement());
        }

       else if (area.isLearning == true && BaseMovements.Length != 0)
       {
            player.GetComponentInChildren<BasicPlayer>().enabled = false;
            doLearning();
       }

       else
       {
            Debug.LogError("There is no movements for the tribesman");
       }

	}

    IEnumerator doBaseMovement()
    {
        for (int i = 0; i < BaseMovements.Length; i++)
        {
            if (BaseMovements[i].ToLower() == Ymove)
            {
                Debug.Log("Y");
            }

            else if (BaseMovements[i].ToLower() == Mmove)
            {
                Debug.Log("M");
            }

            else if (BaseMovements[i].ToLower() == Cmove)
            {
                Debug.Log("C");
            }

            else if (BaseMovements[i].ToLower() == Amove)
            {
                Debug.Log("A");
            }

            else if (BaseMovements[i].ToLower() == jump)
            {
                Debug.Log("J");
            }

            else if (BaseMovements[i].ToLower() == crouch)
            {
                Debug.Log("CR");
            }

            else
            {
                Debug.LogError("This is no known movement");
            }

        }

        yield return new WaitForSeconds(1f);
    }

     public void doLearning()
    {
        if (Input.anyKey && MovementCounter != MovementLimit && Input.inputString.Length > 0)
        {
            foreach (string x in allowedkeys)
            {
                if (x.Contains(Input.inputString))
                {
                    LearnedMovement[MovementCounter] = Input.inputString.ToLower();
                    MovementCounter++;
                    //add if/else statement to play the player sprite movements
                }
            }
        }


        if (MovementCounter == MovementLimit)
        {
            Debug.Log(MovementCounter);
            Debug.Log("Limit reached");
            MovementCounter = 0;
            if (LearnedMovement.SequenceEqual(GoalRitual) == true)
            {
                Debug.Log("You win");
                BaseMovements = LearnedMovement;
            }

            area.isLearning = false;
        }
    }

}
