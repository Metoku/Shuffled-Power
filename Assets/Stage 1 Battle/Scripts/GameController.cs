using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class GameController : MonoBehaviour
{
 
    

    WaitForSeconds waitTime1 = new WaitForSeconds(2f);
    

    int randomizer;//randomizer
    //equation set answers
    [Header("Answer Sets")]
    public int answer1 = 88;
    public int answer2 = 77;
    public int answer3 = 85;
    public int answer4 = 85;
    public int answer5 = 85;
    public int answer6 = 85;
    public int answer7 = 85;
    public int answer8 = 85;
    public int answer9 = 85;
    public int answer10 = 85;

    [Header("Other Controllers")]
    public LoadController loadController;
    public DataPersistenceManager persistenceManager;
    


    [Header("Battle Elements")]
    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject enemy = null;
    [SerializeField] private Slider playerHealth = null;
    [SerializeField] private Slider enemyHealth = null;
    [SerializeField] private Button attackBtn = null;
    [SerializeField] private Button healBtn = null;
    [SerializeField] private Button escapeBtn = null;
    [SerializeField] private GameObject battleUI = null;
    [SerializeField] private GameObject equationPanel = null; //solving ui
    [SerializeField] TextMeshProUGUI monstnameTxt = null;
    //equation buttons
    
    //public GameObject[] equations1;//for random equations
    [SerializeField] private GameObject losePanel = null; 
    [SerializeField] private GameObject winPanel = null; 
    [SerializeField] TextMeshProUGUI playerHealthTxt = null;


    [Header("Animators")]
    [SerializeField] private Animator playerAnim;
    [SerializeField] private Animator enemyAnim;

    [Header("Equation Sets")]
    [SerializeField] private GameObject additionSet1 = null;
    [SerializeField] private GameObject additionSet2 = null;
    [SerializeField] private GameObject additionSet3 = null;
 

    [Header("Timer")]
    float currentTime = 0f;
    float startingTime = 15f;
    [SerializeField] private TextMeshProUGUI timerTxt;


    //shuffle equation variables

   /* [Header("For Shuffling Equation")]
    [SerializeField] private RectTransform[] equationPrefabs;
    [SerializeField] private RectTransform[] spawnLocations;
    [SerializeField] private List<int> retrieveList = new List<int>();*/


    [Header("Battle events")]
    [SerializeField] private GameObject BattleEvents;
    [SerializeField] private TextMeshProUGUI battleEventText;

    private int randomNumber;

    private int playerHP;
    private int enemyHP;
    private int maxPlayerHP;

    private string monsterName;

    int playerDmg;
    //variables for solving player's attack damage
    [Header("Player solving display")]
    [SerializeField] TextMeshProUGUI display1;
    private string display = "";

    [Header("Camera Switching")] 
    public TrackSwitcher playerSwitch;
    public TrackSwitcher enemySwitch;
    public GameObject playerCam;
    public GameObject enemyCam;
    
    private List<int> digits = new List<int>(11) { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
    private List<char> operators = new List<char>(4) { '+', '-', '×', '÷' };
    bool enteredOperator = false;
    bool enteredDigit = false;
    bool enteredDot = false;
    bool resetUponDigitInput = false;
    private bool playerTurn = true;
    public BattleState state;
    private int healCounter = 0;


    void Start()
    {
        //shuffleEquations();
        state = BattleState.PLAYERTURN;
        playerHP = (int)playerHealth.value;
        enemyHP = (int)enemyHealth.value;
        maxPlayerHP = (int)playerHealth.maxValue;
        enemyAnim.SetBool("idle", true);
        playerAnim.SetBool("idle", true);
        
        StartCoroutine(StartOfBattle());
        monsterName = monstnameTxt.GetComponent<TMPro.TextMeshProUGUI>().text;
        Debug.Log(monsterName);
        /* monstnameTxt.text = monsterName;
         Debug.Log(monsterName);
         Debug.Log(monstnameTxt.text);*/

    }


   public IEnumerator StartOfBattle()
    {
        yield return waitTime1;
        battleEventText.text = "Battle Start.";
        yield return waitTime1;
        battleEventText.text = "Player turn.";
        yield return waitTime1;
        BattleEvents.SetActive(false);
        battleUI.SetActive(true);
    }

    /*private void  shuffleEquations()
    {
        spawnLocations.Shuffle(5);
        retrieveList = new List<int>(new int[spawnLocations.Length]);

        for (int i = 0; i < spawnLocations.Length; i++)
        {
            randomNumber = UnityEngine.Random.Range(1, (equationPrefabs.Length) + 1);
            while (retrieveList.Contains(randomNumber))
            {
                randomNumber = UnityEngine.Random.Range(1, (equationPrefabs.Length) + 1);
            }
            retrieveList[i] = randomNumber;
            equationPrefabs[(retrieveList[i] - 1)].anchorMin = spawnLocations[(retrieveList[i] - 1)].anchorMin;
            equationPrefabs[(retrieveList[i] - 1)].anchorMax = spawnLocations[(retrieveList[i] - 1)].anchorMax;
            equationPrefabs[(retrieveList[i] - 1)].localPosition = spawnLocations[(retrieveList[i] - 1)].localPosition;
            equationPrefabs[(retrieveList[i] - 1)].anchoredPosition = spawnLocations[(retrieveList[i] - 1)].anchoredPosition;





        }


    }*/



    private void Attack(GameObject target, int damage)
    {
        if (target == enemy)
        {
            enemyHealth.value -= damage;
            enemyHP = (int)enemyHealth.value;
        }
        else
        {
            playerHealth.value -= damage;
            playerHealthTxt.text = playerHealth.value.ToString();
            playerHP = (int)playerHealth.value;
        }
    }

    private void Heal(GameObject target, int amount)
    {
        healCounter++;
        if (target == player && healCounter < 3 && playerHP < maxPlayerHP)
        {
            playerHealth.value += amount;
        }
        else
        {
            healBtn.interactable = false;
        }
       
    }

    public void BtnAttack()
    {

        battleUI.SetActive(false);
        equationPanel.SetActive(true);
        StartCoroutine(randomEquation());
        StartCoroutine(CountdownTimer());


    }

    public IEnumerator BtnHeal()
    {
        Heal(player, 5);
        healCounter++;
        BattleEvents.gameObject.SetActive(true);
        battleEventText.text = "Player heals for 5 HP";
        yield return new WaitForSeconds(2f);
        BattleEvents.gameObject.SetActive(false);
        if (healCounter == 3)
        {
            healBtn.interactable = false;
        }
    }

    public void BtnHeals()
    {
        StartCoroutine(BtnHeal());
    }
    public void BtnSolve()
    {
        StartCoroutine(CalculateAnswer());


    }

    public void BtnEscape()
    {
        //loadController.LoadLevel(1);
    }
    public IEnumerator ChangeTurn()
    {
        playerTurn = !playerTurn;

        if (!playerTurn)
        {
            state = BattleState.ENEMYTURN;
            equationPanel.SetActive(false);
            attackBtn.interactable = false;
            healBtn.interactable = false;
            escapeBtn.interactable = false;

            StartCoroutine(EnemyTurn());
            yield return waitTime1;

        }    
        else
        {
            yield return waitTime1;
            BattleEvents.SetActive(false);
            state = BattleState.PLAYERTURN;
            battleUI.SetActive(true);
            Debug.Log("Player turn");
            
            attackBtn.interactable = true;
            if(healCounter < 3) 
            {
                healBtn.interactable = true;
            }
            else
            {
                {
                    healBtn.interactable = false;
                }
            }
            
            escapeBtn.interactable = true;
        }    
    }
    //Enemy damage;
    private IEnumerator EnemyTurn()
    {
        playerCam.gameObject.SetActive(false);
        enemyCam.gameObject.SetActive(true);
        enemySwitch.ResetCamera();
        yield return new WaitForSeconds(2f);
        battleEventText.text = "Enemy turn.";
        
        yield return new WaitForSeconds(2f);
        battleEventText.text = "Enemy rolls dice to receive a buff on his damage.";
        int enemyDmg = 4;
        int die = Random.Range(1,6);
        enemyDmg += die;
        yield return new WaitForSeconds(2f);
        battleEventText.text = "Enemy rolls "+ die +" on the dice.";
        yield return new WaitForSeconds(2f);
        battleEventText.text = "Enemy receives an addtional " + die + " for his damage";
        yield return new WaitForSeconds(2f);
        battleEventText.text = "Dealing " + enemyDmg + " damage to the player.";

        Attack(player, enemyDmg);
        enemyAnim.SetBool("attack", true);
        enemyAnim.SetBool("idle", false);
        yield return new WaitForSeconds(2f);
        enemyAnim.SetBool("attack", false);
        enemyAnim.SetBool("idle", true);
        
        playerAnim.SetBool("idle", false);
        playerAnim.SetBool("hit", true);
        yield return new WaitForSeconds(1f);
        playerAnim.SetBool("idle", true);
        playerAnim.SetBool("hit", false);
        battleEventText.text = "Player Turn.";

        Debug.Log("Enemy Damage: " + enemyDmg);
        if(playerHP <= 0)
        {
            state = BattleState.LOST;
            playerAnim.SetBool("idle", false);
            playerAnim.SetBool("dead", true);
            StartCoroutine(EndBattle());
        }
        else {
            StartCoroutine(ChangeTurn());
            enemyCam.gameObject.SetActive(false);
            playerCam.gameObject.SetActive(true);
            playerSwitch.ResetCamera();
            //BattleEvents.gameObject.SetActive(false);

        }
        

    }


    //calculating player damage
    public void DigitPushed(string digit)
    {
        if (resetUponDigitInput)
        {
            resetUponDigitInput = false;
            display = "0";
        }
        if (enteredDot == true && digit == ".")
            return;
        if (digit == ".")
            enteredDot = true;
        if (display == "0" && digit != ".")
            display = display.Substring(0, display.Length - 1);
        display += digit;
        display1.text = display;
        enteredOperator = false;
    }

    public void OperatorPushed(string operation)
    {
        if (enteredOperator == true)
            return;
        display += operation;
        display1.text = display;
        enteredOperator = true;
        enteredDot = false;
        resetUponDigitInput = false;
    }

    public void RemoveDigit()
    {
        resetUponDigitInput = false;
        if (display.Length - 1 <= 0)
        {
            display = "0";
            return;
        }
        if (display[display.Length - 1] == '.')
            enteredDot = false;
        display = display.Substring(0, display.Length - 1);
        display1.text = display;
    }



    private IEnumerator randomEquation()
    {
        yield return new WaitForSeconds(0.5f);
        randomizer = Random.Range(1, 4);
        if (randomizer == 1)
        {
            /* GameObject equation = Instantiate(additionSet1, additionSet1.transform.position, additionSet1.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            additionSet1.SetActive(true);
        }
        else if (randomizer == 2)
        {
            /* GameObject equation = Instantiate(additionSet2, additionSet2.transform.position, additionSet2.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            additionSet2.SetActive(true);
        }
        else
        {
            /* GameObject equation = Instantiate(additionSet3, additionSet3.transform.position, additionSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            additionSet3.SetActive(true);
        }
        Debug.Log("Equation Set: "+randomizer);
        
    }

    

    private IEnumerator CountdownTimer()
    {
        yield return new WaitForSeconds(0.5f);
        currentTime = startingTime;
        timerTxt.text = currentTime.ToString("0");
        while (currentTime > 0)
        {
            Debug.Log("Countdown: " + currentTime);
            yield return new WaitForSeconds(1.0f);
            currentTime--;
            timerTxt.text = currentTime.ToString("0");
            if(currentTime <= 3)
            {
                timerTxt.color = new Color32(255, 0, 0, 255);
            }
            else if(currentTime>3)
            {
                timerTxt.color = new Color32(0, 0, 0, 255);
            }
            
            if (currentTime <= 0)
            {
                Attack(enemy, (int)currentTime);
                yield return new WaitForSeconds(1f);
                battleEventText.text = "Player deals " + "0" + " damage to the enemy.";
                additionSet3.SetActive(false);
                equationPanel.SetActive(false);
                yield return new WaitForSeconds(1f);
                BattleEvents.gameObject.SetActive(true);
                yield return new WaitForSeconds(1f);
                StartCoroutine(ChangeTurn());
                yield return new WaitForSeconds(1f);
                battleEventText.text = "Enemy Turn";
                resetUponDigitInput = true;
                ClearAllEntries();


            }
            
        }
       


       

    }
        private IEnumerator CalculateAnswer()
    {
        string entry = string.Empty;
        int expressionLength = display.Length;
        List<float> expressionEntries = new List<float>();
        List<char> expressionOperators = new List<char>();
        int mdNumber = 0;

        for (int x = 0; x < expressionLength; x++)
        {
            if (digits.Contains(display[0]))
            {
                entry += display[0].ToString();
                if (display.Length == 1)
                    expressionEntries.Add(float.Parse(entry, System.Globalization.CultureInfo.InvariantCulture));
            }
            else if (operators.Contains(display[0]))
            {
                if (display[0] == '×' || display[0] == '÷')
                    mdNumber++;
                expressionEntries.Add(float.Parse(entry, System.Globalization.CultureInfo.InvariantCulture));
                expressionOperators.Add(display[0]);
                entry = string.Empty;
            }
            display = display.Substring(1);
            display1.text = display;
        }

        for (int y = 0; y < mdNumber; y++)
        {
            for (int w = 0; w < Mathf.Infinity; w++)
            {
                float orderOfOperationResult;
                if (expressionOperators[w] == '×')
                {
                    orderOfOperationResult = expressionEntries[w] * expressionEntries[w + 1];
                    expressionEntries[w] = orderOfOperationResult;
                    expressionEntries.Remove(expressionEntries[w + 1]);
                    expressionOperators.Remove(expressionOperators[w]);
                    break;
                }
                else if (expressionOperators[w] == '÷')
                {
                    orderOfOperationResult = expressionEntries[w] / expressionEntries[w + 1];
                    expressionEntries[w] = orderOfOperationResult;
                    expressionEntries.Remove(expressionEntries[w + 1]);
                    expressionOperators.Remove(expressionOperators[w]);
                    break;
                }
            }
        }

        float result = expressionEntries[0];
        for (int z = 0; z < expressionOperators.Count; z++)
        {
            if (expressionOperators[z] == '+')
                result += expressionEntries[z + 1];
            else if (expressionOperators[z] == '-')
                result -= expressionEntries[z + 1];
        }
        
        display = result.ToString();
        display1.text = display;

        if(randomizer == 1)
        {
            if((int)result == answer1)
            {
                BattleEvents.gameObject.SetActive(true);
                equationPanel.SetActive(false);
                Attack(enemy, (int)currentTime);
                playerAnim.SetBool("hit", false);
                playerAnim.SetBool("idle", false);
                playerAnim.SetBool("attack", true);
                yield return new WaitForSeconds(1f);
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";// 
                yield return new WaitForSeconds(1f);
                playerAnim.SetBool("attack", false);
                playerAnim.SetBool("idle", true);
                enemyAnim.SetBool("idle", false);
                enemyAnim.SetBool("damaged", true);
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", true);
                enemyAnim.SetBool("damaged", false);
                additionSet1.SetActive(false);
                //equationPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleState.WON;
                    enemyAnim.SetBool("die", true);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", false);
                    StartCoroutine(EndBattle());
                }
                else
                {
                    yield return new WaitForSeconds(1f);
                    BattleEvents.gameObject.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    StartCoroutine(ChangeTurn());
                    yield return new WaitForSeconds(1f);
                    battleEventText.text = "Enemy Turn";
                    resetUponDigitInput = true;
                    ClearAllEntries();
                }
            }
            else
            {
                ClearAllEntries();
                currentTime--;
                timerTxt.text = currentTime.ToString("0");

            }
            

        }

        else if(randomizer == 2)
        {
            if ((int)result == answer2)
            {
                Attack(enemy, (int)currentTime);
                playerAnim.SetBool("hit", false);
                playerAnim.SetBool("idle", false);
                playerAnim.SetBool("attack", true);
                yield return new WaitForSeconds(1f);
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";// 
                yield return new WaitForSeconds(1f);
                playerAnim.SetBool("attack", false);
                playerAnim.SetBool("idle", true);
                enemyAnim.SetBool("idle", false);
                enemyAnim.SetBool("damaged", true);
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", true);
                enemyAnim.SetBool("damaged", false);
                additionSet2.SetActive(false);
                if (enemyHP <= 0)
                {
                    
                    
                    state = BattleState.WON;
                    enemyAnim.SetBool("die", true);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", false);

                    StartCoroutine(EndBattle());
                }
                else
                {
                    yield return new WaitForSeconds(1f);
                    BattleEvents.gameObject.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    StartCoroutine(ChangeTurn());
                    yield return new WaitForSeconds(1f);
                    battleEventText.text = "Enemy Turn";
                    resetUponDigitInput = true;
                    ClearAllEntries();
                }

            }
            else
            {
                ClearAllEntries();
                currentTime--;
                timerTxt.text = currentTime.ToString("0");
            }

           
        }
        else if (randomizer == 3)
        {
            if ((int)result == answer3)
            {
                BattleEvents.gameObject.SetActive(true);
                equationPanel.SetActive(false);
                Attack(enemy, (int)currentTime);
                playerAnim.SetBool("idle", false);
                playerAnim.SetBool("attack", true);
                yield return new WaitForSeconds(1f);
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";// 
                yield return new WaitForSeconds(1f);
                playerAnim.SetBool("idle", true);
                enemyAnim.SetBool("idle", false);
                enemyAnim.SetBool("wolfHit", true);
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", true);
                additionSet3.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleState.WON;
                    enemyAnim.SetBool("die", true);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", false);
                    StartCoroutine(EndBattle());

                    StartCoroutine(EndBattle());
                }
                else
                {
                    yield return new WaitForSeconds(1f);
                    BattleEvents.gameObject.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    StartCoroutine(ChangeTurn());
                    yield return new WaitForSeconds(1f);
                    battleEventText.text = "Enemy Turn";
                    resetUponDigitInput = true;
                    ClearAllEntries();
                }
                
            }
            else
            {
                ClearAllEntries();
                currentTime--;
                timerTxt.text = currentTime.ToString("0");
            }

            
        }

        


       
        /*if (enemyHP <= 0)
        {
            state = BattleState.WON;
            
            
            StartCoroutine(EndBattle());
        }
        else
        {



            //BattleEvents.gameObject.SetActive(false);
            equationPanel.SetActive(false);
            StartCoroutine(ChangeTurn());
            yield return new WaitForSeconds(1f);
            battleEventText.text = "Enemy Turn";
            //Destroy(additionSetParent.transform.GetChild(0).gameObject);
            
            resetUponDigitInput = true;
            
            ClearAllEntries();
           
            *//*equationBtns[0].interactable = true;
            equationBtns[1].interactable = true;
            equationBtns[2].interactable = true;
            equationBtns[3].interactable = true;
            equationBtns[4].interactable = true;*//*
            BattleEvents.gameObject.SetActive(true);
            
            yield return new WaitForSeconds(2);
           
        }*/
        
        
        
    }

    public void ClearAllEntries() // C
    {
        display = "";
        display1.text = display;
        enteredOperator = false;
        enteredDot = false;
        resetUponDigitInput = false;
    }

    //win and lose conditions


    IEnumerator EndBattle()
    {
        if (state == BattleState.WON)
        {
            BattleEvents.SetActive(false);
            equationPanel.SetActive(false);
            battleUI.SetActive(false);
            Destroy(enemy);
            winPanel.SetActive(true);
            yield return new WaitForSeconds(2f);
            loadController.LoadLevel(1);
            //loadController.LoadLevel(1);
            persistenceManager.LoadGame();
            // DontDestroyOnLoad(this.gameObject);
            //OnSceneLoaded("village_test", mode);

            /*GameObject gameObject = GameObject.Find("MB");
            gameObject.SetActive(false);*/
            // SavingSystem.i.Load("saveSlot1");


        }
        else if (state == BattleState.LOST)
        {
            equationPanel.SetActive(false);
            battleUI.SetActive(false);
            losePanel.SetActive(true);
            yield return new WaitForSeconds(2f);

        }
    }

    public void returnToMainMenu()// load main menu scene
    {
        loadController.LoadLevel(0);
    }
    public void restartBattle()//restart battle if the player lost
    {
        Scene scene = SceneManager.GetActiveScene();
        loadController.LoadLevel(scene.buildIndex);
    }

  //for removing enemies after being defeated.
       /* GameObject gameObjectM1 = GameObject.Find("M1");
        GameObject gameObjectM2 = GameObject.Find("M2");
        GameObject gameObjectM3 = GameObject.Find("M3");

        if (monsterName.Equals("Monster 1"))
        {

            // Destroy(gameObjectM1);
            Debug.Log("kill");
            GameObject.Find("M1").SetActive(false);
            gameObjectM1.SetActive(false);
        }
        else if (monsterName.Equals("Monster 2"))
        {
            gameObjectM2.SetActive(false);
            //Destroy(gameObjectM2);
        }
        else if (monsterName.Equals("Monster 3"))
        {
            gameObjectM3.SetActive(false);
            // Destroy(gameObjectM3);
        }
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);*/
    

}
