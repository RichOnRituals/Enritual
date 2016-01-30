using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TribesMan : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private string[] BaseMovements;
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
    [SerializeField]
    private int interval = 200;
    private int wait = 200;
    //Constants for movement strings and sprite for
    //easier reading
    private const int MovementLimit = 6;
    private const string Ymove = "y";
    private const string Mmove = "m";
    private const string Cmove = "c";
    private const string Amove = "a";
    private const string jump = "j";
    private const string crouch = "t";
    private const int YSprite = 0;
    private const int MSprite = 1;
    private const int CSprite = 2;
    private const int ASprite = 3;
    private const int JumpSprite = 4;
    private const int CrouchSprite = 5;
    private const int NeturalSprite = 6;
    //String to check only for certain key values
    private string[] allowedkeys = { Ymove, Mmove, Cmove, Amove, jump, crouch };
    private Transform tribesman = null;
    private LearningArea area = null;
    private GameObject player = null;
    private SpriteRenderer TribeSprite;
    private int PatternCounter;

    
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

        if(TribeSprite == null)
        {
            TribeSprite = gameObject.GetComponent<SpriteRenderer>();
        }
    }
    
	// Update is called once per frame
	void Update ()
    {
        if (area.isLearning == false && BaseMovements.Length != 0)
        {
            player.GetComponentInChildren<BasicPlayer>().enabled = true;
            if ( wait <= 0)
            {
                wait = interval;

                if (BaseMovements[PatternCounter].ToLower() == Ymove)
                {
                    TribeSprite.sprite = sprites[YSprite];
                    PatternCounter++;
                }

                else if (BaseMovements[PatternCounter].ToLower() == Mmove)
                {
                    Debug.Log("M");
                    TribeSprite.sprite = sprites[MSprite];
                    PatternCounter++;
                }

                else if (BaseMovements[PatternCounter].ToLower() == Cmove)
                {
                    Debug.Log("C");
                    TribeSprite.sprite = sprites[CSprite];
                    PatternCounter++;
                }

                else if (BaseMovements[PatternCounter].ToLower() == Amove)
                {
                    Debug.Log("A");
                    TribeSprite.sprite = sprites[ASprite];
                    PatternCounter++;
                }

                else if (BaseMovements[PatternCounter].ToLower() == jump)
                {
                    Debug.Log("J");
                    //TribeSprite.sprite = sprites[JumpSprite];
                    PatternCounter++;
                }

                else if (BaseMovements[PatternCounter].ToLower() == crouch)
                {
                    Debug.Log("CR");
                    //TribeSprite.sprite = sprites[CrouchSprite];
                    PatternCounter++;
                }

                else
                {
                    Debug.LogError("This is no known movement");
                }

                if (PatternCounter >= BaseMovements.Length)
                {
                    PatternCounter = 0;
                }
            }

            else
            {
                wait--;
            }
        }

       else if (area.isLearning == true && BaseMovements.Length != 0)
       {
            player.GetComponentInChildren<BasicPlayer>().enabled = false;
            TribeSprite.sprite = sprites[NeturalSprite];
            doLearning();
       }

       else
       {
            Debug.LogError("There is no movements for the tribesman");
       }

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
