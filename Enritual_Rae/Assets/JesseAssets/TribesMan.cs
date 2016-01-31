﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TribesMan : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private List<string> BaseMovements;
    private List<string> LearnedMovement;
    [SerializeField]
    private GameObject areaObject;
    [SerializeField]
	private List<string> GoalRitual;
    [SerializeField]
    private int interval = 200;
    [SerializeField]
    private float MaxInNetural = 4.0f;
    private int wait = 0;
    //Constants for movement strings and sprite for
    //easier reading
    private const int MovementLimit = 10;

	private const int NeutralSprite = 0;
    private const int YSprite = 1;
    private const int MSprite = 2;
    private const int CSprite = 3;
    private const int ASprite = 4;
    private const int JumpSprite = 5;
    private const int CrouchSprite = 6;

	public bool isComplete;

    private LearningArea area = null;
    private GameObject player = null;
    private SpriteRenderer TribeSprite;
    private int PatternCounter = -1;
	private float TimeInNeutral;
    private bool isLearning;
    private MainCharacterScript playerscript;
    private MainCharacterScript.PlayerState lastPlayerState = MainCharacterScript.PlayerState.neutral;


    void Start()
    {

        if (area == null)
        {
            area = areaObject.GetComponent<LearningArea>();
        }

        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
            playerscript = player.GetComponent<MainCharacterScript>();
        }

        if(TribeSprite == null)
        {
            TribeSprite = gameObject.GetComponent<SpriteRenderer>();
        }
    }
    
	// Update is called once per frame
	void Update ()
    {
        if (area.isLearning == false && BaseMovements.Count != 0)
        {
            endLearning();
            if ( wait <= 0)
            {
                wait = interval;

				if (PatternCounter >= (BaseMovements.Count - 1))
				{
					PatternCounter = -1;
				}
				PatternCounter++;

				if (BaseMovements[PatternCounter].ToLower() == MainCharacterScript.PlayerState.y.ToString()) {
                    TribeSprite.sprite = sprites[YSprite];
				} else if (BaseMovements[PatternCounter].ToLower() == MainCharacterScript.PlayerState.m.ToString()) {
                    TribeSprite.sprite = sprites[MSprite];
				} else if (BaseMovements[PatternCounter].ToLower() == MainCharacterScript.PlayerState.c.ToString()) {
                    TribeSprite.sprite = sprites[CSprite];
				} else if (BaseMovements[PatternCounter].ToLower() == MainCharacterScript.PlayerState.a.ToString()) {
                    TribeSprite.sprite = sprites[ASprite];
				} else if (BaseMovements[PatternCounter].ToLower() == MainCharacterScript.PlayerState.jump.ToString()) {
                    TribeSprite.sprite = sprites[JumpSprite];
				} else if (BaseMovements[PatternCounter].ToLower() == MainCharacterScript.PlayerState.crouch.ToString()) {
                    TribeSprite.sprite = sprites[CrouchSprite];
                } else {
                    Debug.LogError("This is no known movement");
                }
            } else {
                wait--;
            }
        } else if (area.isLearning == true) {
            if (!isLearning )
            {
                startLearning();
            }
            doLearning();
		}
        else {
            Debug.LogError("There is no movements for the tribesman");
		}
	}

    public void doLearning()
    {
        bool shouldLearn = false;
		MainCharacterScript.PlayerState currentPlayerState = playerscript.GetState ();

		if (currentPlayerState == MainCharacterScript.PlayerState.neutral)
        {
            TimeInNeutral += Time.deltaTime;
            if (TimeInNeutral >= MaxInNetural)
            {
                Debug.Log("Player has been too long in netural");
                endLearning();
                return;
            }
        }
        else
        {
            if (!isLearning)
           {
              startLearning();
           }

			if(currentPlayerState != MainCharacterScript.PlayerState.walking && lastPlayerState != currentPlayerState)
            {
                shouldLearn = true;
				lastPlayerState = currentPlayerState;
            }
       }

       if (shouldLearn)
		{
			if (LearnedMovement.Count == 0) {
				//show light
			}
			print ("Learned:" + lastPlayerState.ToString());
            LearnedMovement.Add(lastPlayerState.ToString());
       }

        if (LearnedMovement.Count >= MovementLimit)
        {
            endLearning();
        }
    }

    void endLearning()
	{
        if(isLearning)
		{
			print ("Ending learning");
			if (LearnedMovement != null && LearnedMovement.Count > 0)
            {
				print ("new pattern:");
				print (LearnedMovement);
                BaseMovements = LearnedMovement;
				// check if BaseMovements = GoalRitual, and play sound if correct, set isComplete to true
				// else play bad sound, set isComplete to false
            }
        }

        isLearning = false;
    }

    void startLearning()
    {
		print ("Starting learning");
		TimeInNeutral = 0;
        LearnedMovement = new List<string>();
        isLearning = true;
        TribeSprite.sprite = sprites[NeutralSprite];
    }

}
