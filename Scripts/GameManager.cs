using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;    

    public CardController[] cardPrefabs;

    //Created a list to store already dealt card values
    private List<int> usedCards;

    //  private string folderPath = "PrefabCards";

    // private Dictionary<int, Stack<GameObject>> intOfCard = new Dictionary<int, Stack<GameObject>>();

        //Created a grid to act as the playspace
    public int[,] grid = new int[,]
    {
     //bottom      -->         top
        {3, 0, 0, 0, 0, 0, 0, 2}, //Left
        {3, 0, 0, 0, 0, 0, 0, 2},
        {3, 0, 0, 0, 0, 0, 0, 2},
        {3, 0, 0, 0, 0, 0, 0, 2},
        {0, 0, 0, 0, 0, 0, 0, 1},
        {0, 0, 0, 0, 0, 0, 0, 1},
        {0, 0, 0, 0, 0, 0, 0, 1},
        {0, 0, 0, 0, 0, 0, 0, 1}, //Right

    };

    void Awake ()
    {
        GameManager.instance = this;
/*       
        Attempted at creating a stack that would randomize

        GameObject[] resources = Resources.LoadAll<GameObject>(folderPath);

        //Referenced https://forum.unity.com/threads/randomize-array-in-c.86871/
        for (int i = 0; i < resources.Length; i++)
        {
            GameObject temp = resources[i];
            int r = Random.Range(i, resources.Length);
            resources[i] = resources[r];
            resources[r] = temp;
        }

        foreach (GameObject cardPrefab in resources)
        {
            Stack<GameObject> cardStack = new Stack<GameObject>();
            cardStack.Push(cardPrefab);
            intOfCard.Add((int.Parse(cardPrefab.name)), cardStack);
        }
        */

        usedCards = new List<int>();
}

	// Use this for initialization
	void Start ()
    {

        int playSpaceSizeX = grid.GetLength(0);
        int playSpaceSizeY = grid.GetLength(1);

        //Evaluate the size of the grid, then for each space on the grid, spawn a card
        for (int i = 0; i < playSpaceSizeX; i++)
        {
            for (int j = 0; j < playSpaceSizeY; j++)
            {
                int valueInGrid = grid[i, j];

                if (valueInGrid == 0)
                {
                    //First go at randomizing card choice
                    /* valueInGrid = Random.Range(4, 55);

                     int randomValue = valueInGrid;

                     for (int k = 0; k < playSpaceSizeX; k++)
                     {
                         for (int l = 0; l < playSpaceSizeY; l++)
                         {
                             if (randomValue == valueInGrid)
                             {
                                 valueInGrid = Random.Range(4, 55);

                             }
                         }
                      } */

                    valueInGrid = RandomCard();                                            
                }

                //Spawn the card according to grid space and card type
                CardController cardClone = Instantiate(cardPrefabs[valueInGrid]);
                cardClone.transform.localPosition = new Vector3(i, j, 0);
                cardClone.posInGrid = new IntVector2(i, j);
            }        
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Second Attempt to randomize
    private int RandomCard()
    {
        int chosenCard = 0;
         
        for (int i = 0; i < 52; i++)
        {
            int r = Random.Range(4, 55);

            if (usedCards.Contains(r))
            {
                r = Random.Range(4, 55);
                print("true");
            }

            usedCards.Add(r);
                        
            chosenCard = r;
        }        
        return chosenCard;
    }
}
