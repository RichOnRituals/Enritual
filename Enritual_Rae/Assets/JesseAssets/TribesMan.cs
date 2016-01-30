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
    private const int MovementLimit = 10;
    private const string Ymove = "1";
    private const string Mmove = "2";
    private const string Cmove = "3";
    private const string Amove = "4";
    private const string jump = "5";
	private const string crouch = "6";
	private const int NeturalSprite = 0;
    private const int YSprite = 1;
    private const int MSprite = 2;
    private const int CSprite = 3;
    private const int ASprite = 4;
    private const int JumpSprite = 5;
    private const int CrouchSprite = 6;
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
            if ( wait <= 0)
            {
                wait = interval;

                if (BaseMovements[PatternCounter].ToLower() == Ymove) {
                    TribeSprite.sprite = sprites[YSprite];
                    PatternCounter++;
                } else if (BaseMovements[PatternCounter].ToLower() == Mmove) {
                    TribeSprite.sprite = sprites[MSprite];
                    PatternCounter++;
                } else if (BaseMovements[PatternCounter].ToLower() == Cmove) {
                    TribeSprite.sprite = sprites[CSprite];
                    PatternCounter++;
                } else if (BaseMovements[PatternCounter].ToLower() == Amove) {
                    TribeSprite.sprite = sprites[ASprite];
                    PatternCounter++;
                } else if (BaseMovements[PatternCounter].ToLower() == jump) {
                    TribeSprite.sprite = sprites[JumpSprite];
                    PatternCounter++;
                } else if (BaseMovements[PatternCounter].ToLower() == crouch) {
                    TribeSprite.sprite = sprites[CrouchSprite];
                    PatternCounter++;
                } else {
                    Debug.LogError("This is no known movement");
                }

                if (PatternCounter >= BaseMovements.Length)
                {
                    PatternCounter = 0;
                }
            } else {
                wait--;
            }
        } else if (area.isLearning == true) {
            TribeSprite.sprite = sprites[NeturalSprite];
            doLearning();
		} else {
            Debug.LogError("There is no movements for the tribesman");
		}
	}

    public void doLearning()
    {
        if (Input.anyKey && MovementCounter < MovementLimit && Input.inputString.Length > 0)
        {
            foreach (string x in allowedkeys)
            {
                if (x.Contains(Input.inputString))
                {
                    LearnedMovement[MovementCounter] = Input.inputString.ToLower();
                    MovementCounter++;
					break;
                    //add if/else statement to play the player sprite movements
                }
            }
        }


		BaseMovements = LearnedMovement;
        if (MovementCounter >= MovementLimit)
        {
            Debug.Log(MovementCounter);
            Debug.Log("Limit reached");
            MovementCounter = 0;
//            if (LearnedMovement.SequenceEqual(GoalRitual) == true)
//            {
//                Debug.Log("You win");
//                BaseMovements = LearnedMovement;
//            }

            area.isLearning = false;
        }
    }

}
