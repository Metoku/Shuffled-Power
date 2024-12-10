using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EquationController : MonoBehaviour
{
    public static EquationController instance; //Instance to make is available in other scripts without reference

    //[SerializeField] private GameObject gameComplete;
    //Scriptable data which store our questions data
    // [SerializeField] private QuizDataScriptable questionDataScriptable;
    //[SerializeField] private Image questionImage;           //image element to show the image




    //private GameStatus gameStatus = GameStatus.Playing;     //to keep track of game status

    private int currentAnswerIndex = 0;   //index to keep track of current answer and current question
    //private bool correctAnswer = true;                      //bool to decide if answer is correct or not
    private string answerNum;                              //string to store answer of current question

    [SerializeField] private Equation[] answerNumberList;     //list of answers word in the game
    private char[] numbersArray = new char[3];               //array which store char of each options

    [SerializeField] private Equation[] optionsNumberList;    //list of options word in the game

    private List<int> selectedNumbersIndex;                   //list which keep track of option word index w.r.t answer word index
   

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        selectedNumbersIndex = new List<int>();           //create a new list at start
        SetEquation();                                  //set question
    }

    void SetEquation()
    {
       

        ResetEquation();                               //reset the answers and options value to orignal     

        selectedNumbersIndex.Clear();                     //clear the list for new question
        Array.Clear(numbersArray, 0, numbersArray.Length);  //clear the array

        //add the correct char to the wordsArray
        for (int i = 0; i < answerNum.Length; i++)
        {
            numbersArray[i] = answerNum[i];
        }

        //add the dummy char to wordsArray
        for (int j = answerNum.Length; j < numbersArray.Length; j++)
        {
            numbersArray[j] = (char)UnityEngine.Random.Range(65, 90);
        }

       

        //set the options words Text value
        for (int k = 0; k < optionsNumberList.Length; k++)
        {
            optionsNumberList[k].SetNumber(numbersArray[k]);
        }

    }

    //Method called on Reset Button click and on new question
    public void ResetEquation()
    {
        //activate all the answerWordList gameobject and set their word to "_"
        for (int i = 0; i < answerNumberList.Length; i++)
        {
            answerNumberList[i].gameObject.SetActive(true);
            answerNumberList[i].SetNumber('_');
        }

        //Now deactivate the unwanted answerWordList gameobject (object more than answer string length)
        for (int i = answerNum.Length; i < answerNumberList.Length; i++)
        {
            answerNumberList[i].gameObject.SetActive(false);
        }

        //activate all the optionsWordList objects
        for (int i = 0; i < optionsNumberList.Length; i++)
        {
            optionsNumberList[i].gameObject.SetActive(true);
        }

        
    }

    /// <summary>
    /// When we click on any options button this method is called
    /// </summary>
    /// <param name="value"></param>
    public void SelectedOption(Equation value)
    {
        

        selectedNumbersIndex.Add(value.transform.GetSiblingIndex()); //add the child index to selectedWordsIndex list
        value.gameObject.SetActive(false); //deactivate options object
        answerNumberList[currentAnswerIndex].SetNumber(value.numValue); //set the answer word list

        currentAnswerIndex++;   //increase currentAnswerIndex

        //if currentAnswerIndex is equal to answerWord length
        if (currentAnswerIndex == answerNum.Length)
        {
            //correctAnswer = true;   //default value
            //loop through answerWordList
            for (int i = 0; i < answerNum.Length; i++)
            {
                int[] Aint = Array.ConvertAll(numbersArray, c => (int)Char.GetNumericValue(c));



                /* //if answerWord[i] is not same as answerWordList[i].wordValue
                 if (char.ToUpper(answerWord[i]) != char.ToUpper(answerWordList[i].wordValue))
                 {
                     correctAnswer = false; //set it false
                     break; //and break from the loop
                 }*/
                Debug.Log(Aint);
            }
            
           
        }
    }

    public void ResetLastWord()
    {
        if (selectedNumbersIndex.Count > 0)
        {
            int index = selectedNumbersIndex[selectedNumbersIndex.Count - 1];
            optionsNumberList[index].gameObject.SetActive(true);
            selectedNumbersIndex.RemoveAt(selectedNumbersIndex.Count - 1);

            currentAnswerIndex--;
            answerNumberList[currentAnswerIndex].SetNumber('_');
        }
    }

}

