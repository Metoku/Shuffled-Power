using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;


public enum BattleStateS2M14 { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class GameControllerS2M14 : MonoBehaviour
{
    //player anim bool


    WaitForSeconds waitTime1 = new WaitForSeconds(2f);


    int randomOperator;// to choose operators
    int randomizer; //randomizer
    int randomizerSub;
    [Header("Hit VFX")] 
    // [SerializeField] private GameObject playerDamaged;
    // [SerializeField] private GameObject enemyDamaged;
    [SerializeField] private ParticleSystem playerDamaged;
    [SerializeField] private ParticleSystem enemyDamaged;
    //equation set answers
    [Header("multiplication Answers & Sets")] 
    public int answer1 = 88;
    public int answer2 = 75;
    public int answer3 = 85;
    public int answer4 = 85;
    public int answer5 = 85;
    public int answer6 = 85;
    public int answer7 = 85;
    public int answer8 = 85;
    public int answer9 = 85;
    public int answer10 = 85;
    public int answer11 = 85;
    public int answer12 = 85;
    public int answer13 = 85;
    public int answer14 = 85;
    public int answer15 = 85;
    public int answer16 = 85;
    public int answer17 = 85;
    public int answer18 = 85;
    public int answer19 = 85;
    public int answer20 = 85;
    
    [SerializeField] private GameObject multiplicationSet1;
    [SerializeField] private GameObject multiplicationSet2;
    [SerializeField] private GameObject multiplicationSet3;
    [SerializeField] private GameObject multiplicationSet4;
    [SerializeField] private GameObject multiplicationSet5;
    [SerializeField] private GameObject multiplicationSet6;
    [SerializeField] private GameObject multiplicationSet7;
    [SerializeField] private GameObject multiplicationSet8;
    [SerializeField] private GameObject multiplicationSet9;
    [SerializeField] private GameObject multiplicationSet10;
    [SerializeField] private GameObject multiplicationSet11;
    [SerializeField] private GameObject multiplicationSet12;
    [SerializeField] private GameObject multiplicationSet13;
    [SerializeField] private GameObject multiplicationSet14;
    [SerializeField] private GameObject multiplicationSet15;
    [SerializeField] private GameObject multiplicationSet16;
    [SerializeField] private GameObject multiplicationSet17;
    [SerializeField] private GameObject multiplicationSet18;
    [SerializeField] private GameObject multiplicationSet19;
    [SerializeField] private GameObject multiplicationSet20;
    
    [Header("division Answers & Sets")] 
    public int answer21;
    public int answer22;
    public int answer23 = 85;
    public int answer24 = 85;
    public int answer25 = 85;
    public int answer26 = 85;
    public int answer27 = 85;
    public int answer28 = 85;
    public int answer29 = 85;
    public int answer30 = 85;
    public int answer31 = 85;
    public int answer32 = 85;
    public int answer33 = 85;
    public int answer34 = 85;
    public int answer35 = 85;
    public int answer36 = 85;
    public int answer37 = 85;
    public int answer38 = 85;
    public int answer39 = 85;
    public int answer40 = 85;
    [Header("Equation Sets")] 
    [SerializeField] private GameObject divisionSet1;
    [SerializeField] private GameObject divisionSet2;
    [SerializeField] private GameObject divisionSet3;
    [SerializeField] private GameObject divisionSet4;
    [SerializeField] private GameObject divisionSet5;
    [SerializeField] private GameObject divisionSet6;
    [SerializeField] private GameObject divisionSet7;
    [SerializeField] private GameObject divisionSet8;
    [SerializeField] private GameObject divisionSet9;
    [SerializeField] private GameObject divisionSet10;
    [SerializeField] private GameObject divisionSet11;
    [SerializeField] private GameObject divisionSet12;
    [SerializeField] private GameObject divisionSet13;
    [SerializeField] private GameObject divisionSet14;
    [SerializeField] private GameObject divisionSet15;
    [SerializeField] private GameObject divisionSet16;
    [SerializeField] private GameObject divisionSet17;
    [SerializeField] private GameObject divisionSet18;
    [SerializeField] private GameObject divisionSet19;
    [SerializeField] private GameObject divisionSet20;

    [Header("Other Controllers")] public LoadController loadController;
    

    [Header("Audio Source & Audio Clip")]
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip playerAtk;
    [SerializeField] private AudioClip playerHealing;
    [SerializeField] private AudioClip enemyAtk;
    [SerializeField] private AudioClip timeRunningOut;
    [SerializeField] private AudioClip playerError;
    [SerializeField] private AudioClip playerWin;
    [SerializeField] private AudioClip playerLose;
    [SerializeField] private AudioClip outOfTime;
    
    [Header("VO Audio Source & Audio Clip")]
    [SerializeField] private AudioSource VoiceAudioSource;
    [SerializeField] private AudioClip battleStartVO;
    [SerializeField] private AudioClip playerTurnVO;
    [SerializeField] private AudioClip playerAttacksVO;
    [SerializeField] private AudioClip enemyTurnVO;
    [SerializeField] private AudioClip enemyAttacksVO;
    [SerializeField] private AudioClip solveTheVO;
    [SerializeField] private AudioClip winVO;
    [SerializeField] private AudioClip loseVO;


    [Header("Battle Elements")] [SerializeField]
    private GameObject player;

    [SerializeField] private GameObject enemy;
    [SerializeField] private Slider playerHealth;
    [SerializeField] private Slider enemyHealth;
    [SerializeField] private Button attackBtn;
    [SerializeField] private Button healBtn;
    [SerializeField] private Button skipBtn;
    [SerializeField] private GameObject battleUI;
    [SerializeField] private GameObject attackPanel; //solving ui

    [SerializeField] TextMeshProUGUI monstnameTxt;
    //equation buttons

    //public GameObject[] equations1;//for random equations
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] TextMeshProUGUI playerHealthTxt;
    [SerializeField] TextMeshProUGUI enemyHealthTxt;


    [Header("Animators")] [SerializeField] private Animator playerAnim;
    [SerializeField] private Animator enemyAnim;

   
    


    [Header("Timer")] float currentTime = 0f;
    float startingTime = 15f;
    [SerializeField] private TextMeshProUGUI timerTxt;


    //shuffle equation variables

    /* [Header("For Shuffling Equation")]
     [SerializeField] private RectTransform[] equationPrefabs;
     [SerializeField] private RectTransform[] spawnLocations;
     [SerializeField] private List<int> retrieveList = new List<int>();*/


    [Header("Battle events")] [SerializeField]
    private GameObject BattleEvents;

    [SerializeField] private TextMeshProUGUI battleEventText;

    private int randomNumber;

    private int playerHP;
    private int enemyHP;
    private int maxPlayerHP;
    private float playerDamage;
    int playerDmgReduction = 0;

    private string monsterName;
    private Coroutine countdown;
    
    //skip mechanic elements
    private bool playerSkipped = false;
    private int enemyBonusDamage = 3;
    private int skipCtr = 0;

    int playerDmg;

    //variables for solving player's attack damage
    [Header("Player solving display")] [SerializeField]
    TextMeshProUGUI display1;

    private string display = "";

    [Header("Camera Switching")] public TrackSwitcher playerSwitch;
    public TrackSwitcher enemySwitch;
    public GameObject playerCam;
    public GameObject enemyCam;

    private List<int> digits = new List<int>(11) { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };
    private List<char> operators = new List<char>(4) { '+', '-', '�', '�' };
    bool enteredOperator = false;
    bool enteredDigit = false;
    bool enteredDot = false;
    bool resetUponDigitInput = false;
    private bool playerTurn = true;
    public BattleStateS2M14 state;
    private int healCounter = 0;

    
    void Start()
    {
        Debug.Log("start?");
        healBtn.interactable = false;
        //shuffleEquations();
        state = BattleStateS2M14.PLAYERTURN;
        playerHP = (int)playerHealth.value;
        enemyHP = (int)enemyHealth.value;
        maxPlayerHP = (int)playerHealth.maxValue;
        enemyAnim.SetBool("idle", true);
        playerAnim.SetBool("idle", true);
        
        StartCoroutine(StartOfBattle());
        monsterName = monstnameTxt.GetComponent<TMPro.TextMeshProUGUI>().text;
        Debug.Log(monsterName);
       

    }


    public IEnumerator StartOfBattle()
    {
        
        yield return waitTime1;
        battleEventText.text = "Battle Start.";
        VoiceAudioSource.clip = battleStartVO;
        VoiceAudioSource.Play();
        yield return waitTime1;
        battleEventText.text = "Player turn.";
        VoiceAudioSource.clip = playerTurnVO;
        VoiceAudioSource.Play();
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
        if (target == player && healCounter < 4 && playerHP < maxPlayerHP)
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
        StartCoroutine(ClickAtkBtn());
    }
    
    IEnumerator ClickAtkBtn()
    {

        battleUI.SetActive(false);
        
        
        StartCoroutine(randomEquation());
        BattleEvents.SetActive(true);
        yield return waitTime1;



    }

    public IEnumerator BtnHeal()
    {
        Heal(player, 10);
        _audioSource.clip = playerHealing;
        _audioSource.Play();
        healCounter++;
        BattleEvents.gameObject.SetActive(true);
        battleEventText.text = "Player heals for 10 HP";
        playerHealthTxt.text = playerHealth.value.ToString();
        yield return new WaitForSeconds(2f);
        BattleEvents.gameObject.SetActive(false);
        if (healCounter < 4 && playerHP == (int)playerHealth.maxValue)
        {
            healBtn.interactable = false;
        }
    }
    
    public void BtnSkip()
    {
        playerSkipped = true;
        if (randomOperator == 1)
        {
            if (randomizer == 1)
            {
                multiplicationSet1.SetActive(false);
            }
            else if (randomizer == 2)
            {
                multiplicationSet2.SetActive(false);
            }
            else if (randomizer == 3)
            {
                multiplicationSet3.SetActive(false);
            }
            else if (randomizer == 4)
            {
                multiplicationSet4.SetActive(false);
            }
            else if (randomizer == 5)
            {
                multiplicationSet5.SetActive(false);
            }
            else if (randomizer == 6)
            {
                multiplicationSet6.SetActive(false);
            }
            else if (randomizer == 7)
            {
                multiplicationSet7.SetActive(false);
            }
            else if (randomizer == 8)
            {
                multiplicationSet8.SetActive(false);
            }
            else if (randomizer == 9)
            {
                multiplicationSet9.SetActive(false);
            }
            else if (randomizer == 10)
            {
                multiplicationSet10.SetActive(false);
            }
            else if (randomizer == 11)
            {
                multiplicationSet11.SetActive(false);
            }
            else if (randomizer == 12)
            {
                multiplicationSet12.SetActive(false);
            }
            else if (randomizer == 13)
            {
                multiplicationSet13.SetActive(false);
            }
            else if (randomizer == 14)
            {
                multiplicationSet14.SetActive(false);
            }
            else if (randomizer == 15)
            {
                multiplicationSet15.SetActive(false);
            }
            else if (randomizer == 16)
            {
                multiplicationSet16.SetActive(false);
            }
            else if (randomizer == 17)
            {
                multiplicationSet17.SetActive(false);
            }
            else if (randomizer == 18)
            {
                multiplicationSet18.SetActive(false);
            }
            else if (randomizer == 19)
            {
                multiplicationSet19.SetActive(false);
            }
            else if (randomizer == 20)
            {
                multiplicationSet20.SetActive(false);
            }
        }
        else if (randomOperator == 2)
        {
            if (randomizerSub == 1)
            {
                divisionSet1.SetActive(false);
            }
            else if (randomizerSub == 2)
            {
                divisionSet2.SetActive(false);
            }
            else if (randomizerSub == 3)
            {
                divisionSet3.SetActive(false);
            }
            else if (randomizerSub == 4)
            {
                divisionSet4.SetActive(false);
            }
            else if (randomizerSub == 5)
            {
                divisionSet5.SetActive(false);
            }
            else if (randomizerSub == 6)
            {
                divisionSet6.SetActive(false);
            }
            else if (randomizerSub == 7)
            {
                divisionSet7.SetActive(false);
            }
            else if (randomizerSub == 8)
            {
                divisionSet8.SetActive(false);
            }
            else if (randomizerSub == 9)
            {
                divisionSet9.SetActive(false);
            }
            else if (randomizerSub == 10)
            {
                divisionSet10.SetActive(false);
            }
            else if (randomizerSub == 11)
            {
                divisionSet11.SetActive(false);
            }
            else if (randomizerSub == 12)
            {
                divisionSet12.SetActive(false);
            }
            else if (randomizerSub == 13)
            {
                divisionSet13.SetActive(false);
            }
            else if (randomizerSub == 14)
            {
                divisionSet14.SetActive(false);
            }
            else if (randomizerSub == 15)
            {
                divisionSet15.SetActive(false);
            }
            else if (randomizerSub == 16)
            {
                divisionSet16.SetActive(false);
            }
            else if (randomizerSub == 17)
            {
                divisionSet17.SetActive(false);
            }
            else if (randomizerSub == 18)
            {
                divisionSet18.SetActive(false);
            }
            else if (randomizerSub == 19)
            {
                divisionSet19.SetActive(false);
            }
            else if (randomizerSub == 20)
            {
                divisionSet20.SetActive(false);
            }
        }
        
        StartCoroutine(randomEquation());
        if (skipCtr > 1)
        {
            enemyBonusDamage++;
        }
        skipCtr++;
        if(skipCtr == 3)
        {
            skipBtn.interactable = false;
        }
        
        /*StopCoroutine(countdown);
        attackPanel.SetActive(false);
        BattleEvents.SetActive(true);
        battleEventText.text = "Player Skipped the Expression, Enemy will receive bonus damage.";
        StartCoroutine(ChangeTurn());*/
        
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
        int chanceToEscape = Random.Range(1, 6);
        if (chanceToEscape <= 4)
        {
            loadController.LoadLevel(1);
        }
        else
        {
            battleUI.SetActive(false);
            BattleEvents.SetActive(true);
            battleEventText.text = "Unable to Escape";
            StartCoroutine(ChangeTurn());
        }
    }

    public IEnumerator ChangeTurn()
    {
        playerTurn = !playerTurn;

        if (!playerTurn)
        {
            
            state = BattleStateS2M14.ENEMYTURN;
            attackPanel.SetActive(false);
            attackBtn.interactable = false;
            healBtn.interactable = false;
           

            StartCoroutine(EnemyTurn());
            yield return waitTime1;

        }
        else
        {
            
            yield return waitTime1;
            BattleEvents.SetActive(false);
            state = BattleStateS2M14.PLAYERTURN;
            battleUI.SetActive(true);
            Debug.Log("Player turn");

            attackBtn.interactable = true;
            if (playerHP == (int)playerHealth.value)
            {
                healBtn.interactable = false;
            }
            else
            {
                healBtn.interactable = true;
            }
            if (healCounter < 3 && playerHP == (int)playerHealth.maxValue)
            {
                healBtn.interactable = true;
            }
            else
            {
                {
                    healBtn.interactable = false;
                }
            }

            
        }
    }

    //Enemy damage;
    private IEnumerator EnemyTurn()
    {
        playerCam.gameObject.SetActive(false);
        enemyCam.gameObject.SetActive(true);
        enemySwitch.ResetCamera();
        yield return new WaitForSeconds(2f);
        battleEventText.text = "Enemy Turn";
        VoiceAudioSource.clip = enemyTurnVO;
        VoiceAudioSource.Play();
        yield return new WaitForSeconds(2f);
        int enemyDmg = Random.Range(14, 17);
        if (playerSkipped == true)
        {
            battleEventText.text = "Player Skipped the Expression, Enemy will receive bonus damage.";
            enemyDmg += enemyBonusDamage;
            skipCtr = 0;
            playerSkipped = false;
            yield return new WaitForSeconds(2f);
            skipBtn.interactable = true;
        }
        battleEventText.text = "Enemy attacks.";
        VoiceAudioSource.clip = enemyAttacksVO;
        VoiceAudioSource.Play();
        yield return new WaitForSeconds(2f);
        
        battleEventText.text = "Enemy deals " + enemyDmg + " damage to the player.";
        yield return new WaitForSeconds(2f);
        Attack(player, enemyDmg);
        enemyAnim.SetBool("attack", true);
        enemyAnim.SetBool("idle", false);
        _audioSource.clip = enemyAtk;
        _audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        enemyAnim.SetBool("attack", false);
        enemyAnim.SetBool("idle", true);
        yield return new WaitForSeconds(0.5f);
        enemyCam.gameObject.SetActive(false);
        playerCam.gameObject.SetActive(true);
        playerSwitch.ResetCamera();
        yield return new WaitForSeconds(2f);
        playerAnim.SetBool("hit", true);
        playerDamaged.Play();
        yield return new WaitForSeconds(1f);
        playerAnim.SetBool("hit", false);
        
        enemyBonusDamage = 3;
        Debug.Log("Enemy Damage: " + enemyDmg);
        
        if (playerHP <= 0)
        {
            state = BattleStateS2M14.LOST;
            playerAnim.SetBool("idle", false);
            playerAnim.SetBool("dead", true);
            StartCoroutine(EndBattle());
        }
        else
        {
            battleEventText.text = "Player turn.";
            VoiceAudioSource.clip = playerTurnVO;
            VoiceAudioSource.Play();
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
        randomOperator = Random.Range(1, 3);
        if (randomOperator == 1)
        {
            
            battleEventText.text = "The expression to be solved is multiplication";
            yield return new WaitForSeconds(1f);
        }
        else if (randomOperator == 2)
        {
            battleEventText.text = "The expression to be solved is division";
            yield return new WaitForSeconds(1f);
        }
        
        yield return new WaitForSeconds(1f);
        BattleEvents.SetActive(false);
        attackPanel.SetActive(true);
        countdown = StartCoroutine(CountdownTimer());
        if (randomOperator == 1)
        {
            UniqueRandomIntMultiplication(1, 21);
            if (randomizer == 1)
            {
                /* GameObject equation = Instantiate(divisionSet1, divisionSet1.transform.position, divisionSet1.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet1.SetActive(true);
            }
            else if (randomizer == 2)
            {
                /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet2.SetActive(true);
            }
            else if (randomizer == 3)
            {
                /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet3.SetActive(true);
            }
            else if (randomizer == 4)
            {
                /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet4.SetActive(true);
            }
            else if (randomizer == 5)
            {
                /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet5.SetActive(true);
            }
            else if (randomizer == 6)
            {
                /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet6.SetActive(true);
            }
            else if (randomizer == 7)
            {
                /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet7.SetActive(true);
            }
            else if (randomizer == 8)
            {
                /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet8.SetActive(true);
            }
            else if (randomizer == 9)
            {
                /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet9.SetActive(true);
            }
            else if (randomizer == 10)
            {
                /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet10.SetActive(true);
            }
            else if (randomizer == 11)
            {
                /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet11.SetActive(true);
            }
            else if (randomizer == 12)
            {
                /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet12.SetActive(true);
            }
            else if (randomizer == 13)
            {
                /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet13.SetActive(true);
            }
            else if (randomizer == 14)
            {
                /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet14.SetActive(true);
            }
            else if (randomizer == 15)
            {
                /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet15.SetActive(true);
            }
            else if (randomizer == 16)
            {
                /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet16.SetActive(true);
            }
            else if (randomizer == 17)
            {
                /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet17.SetActive(true);
            }
            else if (randomizer == 18)
            {
                /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet18.SetActive(true);
            }
            else if (randomizer == 19)
            {
                /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet19.SetActive(true);
            }
            else if (randomizer == 20)
            {
                /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                multiplicationSet20.SetActive(true);
            }
        }
        else if (randomOperator == 2)
        {
            UniqueRandomIntDivision(1, 21);
            switch (randomizerSub)
            {
                case 1:
                    /* GameObject equation = Instantiate(divisionSet1, divisionSet1.transform.position, divisionSet1.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet1.SetActive(true);
                    break;
                case 2:
                    /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet2.SetActive(true);
                    break;
                case 3:
                    /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet3.SetActive(true);
                    break;
                case 4:
                    /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet4.SetActive(true);
                    break;
                case 5:
                    /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet5.SetActive(true);
                    break;
                case 6:
                    /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet6.SetActive(true);
                    break;
                case 7:
                    /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet7.SetActive(true);
                    break;
                case 8:
                    /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet8.SetActive(true);
                    break;
                case 9:
                    /* GameObject equation = Instantiate(divisionSet2, divisionSet2.transform.position, divisionSet2.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet9.SetActive(true);
                    break;
                case 10:
                    /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet10.SetActive(true);
                    break;
                case 11:
                    /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet11.SetActive(true);
                    break;
                case 12:
                    /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet12.SetActive(true);
                    break;
                case 13:
                    /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet13.SetActive(true);
                    break;
                case 14:
                    /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet14.SetActive(true);
                    break;
                case 15:
                    /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet15.SetActive(true);
                    break;
                case 16:
                    /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet16.SetActive(true);
                    break;
                case 17:
                    /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet17.SetActive(true);
                    break;
                case 18:
                    /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet18.SetActive(true);
                    break;
                case 19:
                    /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet19.SetActive(true);
                    break;
                case 20:
                    /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
                 equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
                    divisionSet20.SetActive(true);
                    break;
            }
        }
       
       
        /*else if (randomizer == 21)
        {
            /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);#1#
            divisionSet21.SetActive(true);
        }
        else if (randomizer == 22)
        {
            /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);#1#
            divisionSet22.SetActive(true);
        }
        else if (randomizer == 23)
        {
            /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);#1#
            divisionSet23.SetActive(true);
        }
        else if (randomizer == 24)
        {
            /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);#1#
            divisionSet24.SetActive(true);
        }
        else if (randomizer == 25)
        {
            /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);#1#
            divisionSet25.SetActive(true);
        }
        else if (randomizer == 26)
        {
            /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);#1#
            divisionSet26.SetActive(true);
        }
        else if (randomizer == 27)
        {
            /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);#1#
            divisionSet27.SetActive(true);
        }
        else if (randomizer == 28)
        {
            /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);#1#
            divisionSet28.SetActive(true);
        }
        else if (randomizer == 29)
        {
            /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);#1#
            divisionSet29.SetActive(true);
        }
        else if (randomizer == 30)
        {
            /* GameObject equation = Instantiate(divisionSet3, divisionSet3.transform.position, divisionSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);#1#
            divisionSet30.SetActive(true);
        }*/
        
        
        VoiceAudioSource.clip = solveTheVO;
        VoiceAudioSource.Play();
        Debug.Log("Equation Set: " + randomizerSub);
        Debug.Log("Equation Set: " + randomizer);

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
            if (currentTime > 3)
            {
                timerTxt.color = new Color32(0, 0, 0, 255);
            }
            
            
            if (currentTime <6)
            {
                _audioSource.clip = timeRunningOut;
                _audioSource.Play();
                timerTxt.color = new Color32(255, 0, 0, 255);
            }
            

            if (currentTime <= 0)
            {
                _audioSource.clip = outOfTime;
                _audioSource.Play();
                //disable current set
                if (randomOperator == 1)
                {
                    if (randomizer == 1)
                    {
                        multiplicationSet1.SetActive(false);
                    }
                    else if (randomizer == 2)
                    {
                        multiplicationSet2.SetActive(false);
                    }
                    else if (randomizer == 3)
                    {
                        multiplicationSet3.SetActive(false);
                    }
                    else if (randomizer == 4)
                    {
                        multiplicationSet4.SetActive(false);
                    }
                    else if (randomizer == 5)
                    {
                        multiplicationSet5.SetActive(false);
                    }
                    else if (randomizer == 6)
                    {
                        multiplicationSet6.SetActive(false);
                    }
                    else if (randomizer == 7)
                    {
                        multiplicationSet7.SetActive(false);
                    }
                    else if (randomizer == 8)
                    {
                        multiplicationSet8.SetActive(false);
                    }
                    else if (randomizer == 9)
                    {
                        multiplicationSet9.SetActive(false);
                    }
                    else if (randomizer == 10)
                    {
                        multiplicationSet10.SetActive(false);
                    }
                    else if (randomizer == 11)
                    {
                        multiplicationSet11.SetActive(false);
                    }
                    else if (randomizer == 12)
                    {
                        multiplicationSet12.SetActive(false);
                    }
                    else if (randomizer == 13)
                    {
                        multiplicationSet13.SetActive(false);
                    }
                    else if (randomizer == 14)
                    {
                        multiplicationSet14.SetActive(false);
                    }
                    else if (randomizer == 15)
                    {
                        multiplicationSet15.SetActive(false);
                    }
                    else if (randomizer == 16)
                    {
                        multiplicationSet16.SetActive(false);
                    }
                    else if (randomizer == 17)
                    {
                        multiplicationSet17.SetActive(false);
                    }
                    else if (randomizer == 18)
                    {
                        multiplicationSet18.SetActive(false);
                    }
                    else if (randomizer == 19)
                    {
                        multiplicationSet19.SetActive(false);
                    }
                    else if (randomizer == 20)
                    {
                        multiplicationSet20.SetActive(false);
                    }
                }
                else if (randomOperator == 2)
                {
                    if (randomizerSub == 1)
                    {
                        divisionSet1.SetActive(false);
                    }
                    else if (randomizerSub == 2)
                    {
                        divisionSet2.SetActive(false);
                    }
                    else if (randomizerSub == 3)
                    {
                        divisionSet3.SetActive(false);
                    }
                    else if (randomizerSub == 4)
                    {
                        divisionSet4.SetActive(false);
                    }
                    else if (randomizerSub == 5)
                    {
                        divisionSet5.SetActive(false);
                    }
                    else if (randomizerSub == 6)
                    {
                        divisionSet6.SetActive(false);
                    }
                    else if (randomizerSub == 7)
                    {
                        divisionSet7.SetActive(false);
                    }
                    else if (randomizerSub == 8)
                    {
                        divisionSet8.SetActive(false);
                    }
                    else if (randomizerSub == 9)
                    {
                        divisionSet9.SetActive(false);
                    }
                    else if (randomizerSub == 10)
                    {
                        divisionSet10.SetActive(false);
                    }
                    else if (randomizerSub == 11)
                    {
                        divisionSet11.SetActive(false);
                    }
                    else if (randomizerSub == 12)
                    {
                        divisionSet12.SetActive(false);
                    }
                    else if (randomizerSub == 13)
                    {
                        divisionSet13.SetActive(false);
                    }
                    else if (randomizerSub == 14)
                    {
                        divisionSet14.SetActive(false);
                    }
                    else if (randomizerSub == 15)
                    {
                        divisionSet15.SetActive(false);
                    }
                    else if (randomizerSub == 16)
                    {
                        divisionSet16.SetActive(false);
                    }
                    else if (randomizerSub == 17)
                    {
                        divisionSet17.SetActive(false);
                    }
                    else if (randomizerSub == 18)
                    {
                        divisionSet18.SetActive(false);
                    }
                    else if (randomizerSub == 19)
                    {
                        divisionSet19.SetActive(false);
                    }
                    else if (randomizerSub == 20)
                    {
                        divisionSet20.SetActive(false);
                    }
                }
                // else if (randomizer == 21)
                // {
                //     divisionSet21.SetActive(false);
                // }
                // else if (randomizer == 22)
                // {
                //     divisionSet22.SetActive(false);
                // }
                // else if (randomizer == 23)
                // {
                //     divisionSet23.SetActive(false);
                // }
                // else if (randomizer == 24)
                // {
                //     divisionSet24.SetActive(false);
                // }
                // else if (randomizer == 25)
                // {
                //     divisionSet25.SetActive(false);
                // }
                // else if (randomizer == 26)
                // {
                //     divisionSet26.SetActive(false);
                // }
                // else if (randomizer == 27)
                // {
                //     divisionSet27.SetActive(false);
                // }
                // else if (randomizer == 28)
                // {
                //     divisionSet28.SetActive(false);
                // }
                // else if (randomizer == 29)
                // {
                //     divisionSet29.SetActive(false);
                // }
                // else if (randomizer == 30)
                // {
                //     divisionSet30.SetActive(false);
                // }
                
                //Attack(enemy, (int)currentTime);
                yield return new WaitForSeconds(1f);
                battleEventText.text = "Player deals " + "0" + " damage to the enemy.";
                attackPanel.SetActive(false);
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
                if (display[0] == '�' || display[0] == '�')
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
                if (expressionOperators[w] == '�')
                {
                    orderOfOperationResult = expressionEntries[w] * expressionEntries[w + 1];
                    expressionEntries[w] = orderOfOperationResult;
                    expressionEntries.Remove(expressionEntries[w + 1]);
                    expressionOperators.Remove(expressionOperators[w]);
                    break;
                }
                else if (expressionOperators[w] == '�')
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
        int randomAttackAnim = Random.Range(1,4);
        if (randomOperator == 1)
        {
            if (randomizer == 1)
            {
                if ((int)result == answer1)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);

                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);

                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);

                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyDamaged.Play();
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet1.SetActive(false);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");

                }


            }

            else if (randomizer == 2)
            {
                if ((int)result == answer2)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);

                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);

                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);

                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);

                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("damaged", true);
                    enemyDamaged.Play();
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet2.SetActive(false);
                    if (enemyHP <= 0)
                    {


                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }


            }

            else if (randomizer == 3)
            {
                if ((int)result == answer3)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyDamaged.Play();
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet3.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }
            }


            else if (randomizer == 4)
            {
                if ((int)result == answer4)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyDamaged.Play();
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet4.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }
            }

            else if (randomizer == 5)
            {
                if ((int)result == answer5)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyDamaged.Play();
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet5.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }
            }

            //start of condition
            else if (randomizer == 6)
            {
                if ((int)result == answer6)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    attackPanel.SetActive(false);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyDamaged.Play();
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet6.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }
            }
            //end of condition

            else if (randomizer == 7)
            {
                if ((int)result == answer7)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    attackPanel.SetActive(false);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyDamaged.Play();
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet7.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }
            }

            else if (randomizer == 8)
            {
                if ((int)result == answer8)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet8.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }

            else if (randomizer == 9)
            {
                if ((int)result == answer9)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet9.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }

            else if (randomizer == 10)
            {
                if ((int)result == answer10)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet10.SetActive(false);
                    if (enemyHP <= 0)
                    {

                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }

            //start
            if (randomizer == 11)
            {
                if ((int)result == answer11)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet11.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }


            }
            //end of condition

            //start of condition
            if (randomizer == 12)
            {
                if ((int)result == answer12)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet12.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition


            //start of condition
            if (randomizer == 13)
            {
                if ((int)result == answer13)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    attackPanel.SetActive(false);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet13.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition

            //start of condition
            if (randomizer == 14)
            {
                if ((int)result == answer14)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet14.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition


            //start of condition
            if (randomizer == 15)
            {
                if ((int)result == answer15)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet15.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }
            }
            //end of condition


            //start of condition
            if (randomizer == 16)
            {
                if ((int)result == answer16)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet16.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition


            //start of condition
            if (randomizer == 17)
            {
                if ((int)result == answer17)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    attackPanel.SetActive(false);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet17.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition


            //start of condition
            if (randomizer == 18)
            {
                if ((int)result == answer18)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    attackPanel.SetActive(false);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet18.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition


            //start of condition
            if (randomizer == 19)
            {
                if ((int)result == answer19)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet19.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition


            //start of condition
            if (randomizer == 20)
            {
                if ((int)result == answer20)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    multiplicationSet20.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition
        }
        
        if (randomOperator == 2)
        {


            if (randomizerSub == 1)
            {
                if ((int)result == answer21)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);

                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);

                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);

                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet1.SetActive(false);
                    enemyCam.gameObject.SetActive(false);
                    playerCam.gameObject.SetActive(true);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");

                }


            }

            else if (randomizerSub == 2)
            {
                if ((int)result == answer22)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);

                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);

                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);

                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);

                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet2.SetActive(false);
                    if (enemyHP <= 0)
                    {


                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }


            }

            else if (randomizerSub == 3)
            {
                if ((int)result == answer23)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet3.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }
            }


            else if (randomizerSub == 4)
            {
                if ((int)result == answer24)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet4.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }
            }

            else if (randomizerSub == 5)
            {
                if ((int)result == answer25)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet5.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }
            }

            else if (randomizerSub == 6)
            {
                if ((int)result == answer26)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet6.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }
            }

            else if (randomizerSub == 7)
            {
                if ((int)result == answer27)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet7.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }
            }

            else if (randomizerSub == 8)
            {
                if ((int)result == answer28)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet8.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }

            else if (randomizerSub== 9)
            {
                if ((int)result == answer29)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet9.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }

            else if (randomizerSub == 10)
            {
                if ((int)result == answer30)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet10.SetActive(false);
                    if (enemyHP <= 0)
                    {

                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }

            //start
            if (randomizerSub == 11)
            {
                if ((int)result == answer31)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet11.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }


            }
            //end of condition

            //start of condition
            if (randomizerSub== 12)
            {
                if ((int)result == answer32)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet12.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition


            //start of condition
            if (randomizerSub == 13)
            {
                if ((int)result == answer33)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet13.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition

            //start of condition
            if (randomizerSub == 14)
            {
                if ((int)result == answer34)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet14.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition


            //start of condition
            if (randomizerSub == 15)
            {
                if ((int)result == answer35)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet15.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;
                }
            }
            //end of condition


            //start of condition
            if (randomizerSub == 16)
            {
                if ((int)result == answer36)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet16.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition


            //start of condition
            if (randomizerSub == 17)
            {
                if ((int)result == answer37)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet17.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition


            //start of condition
            if (randomizerSub == 18)
            {
                if ((int)result == answer38)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet18.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition


            //start of condition
            if (randomizerSub== 19)
            {
                if ((int)result == answer39)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet19.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition


            //start of condition
            if (randomizerSub == 20)
            {
                if ((int)result == answer40)
                {
                    StopCoroutine(countdown);
                    BattleEvents.gameObject.SetActive(true);
                    attackPanel.SetActive(false);
                    battleEventText.text = "Player attacks.";
                    VoiceAudioSource.clip = playerAttacksVO;
                    VoiceAudioSource.Play();
                    yield return new WaitForSeconds(1f);
                    playerDamage = currentTime;
                    currentTime = playerDamage;
                    playerDamage = playerDamage - playerDmgReduction;
                    if (playerDamage <= 0)
                    {
                        playerDamage = 0;
                    }

                    Attack(enemy, (int)playerDamage);
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", true);
                            _audioSource.clip = playerAtk;
                            _audioSource.Play();
                            break;
                    }

                    battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                    yield return new WaitForSeconds(0.6f);
                    // 
                    switch (randomAttackAnim)
                    {
                        case 1:
                            playerAnim.SetBool("attack1", false);
                            break;
                        case 2:
                            playerAnim.SetBool("attack2", false);
                            break;
                        case 3:
                            playerAnim.SetBool("attack3", false);
                            break;
                    }

                    yield return new WaitForSeconds(0.6f);
                    enemyCam.gameObject.SetActive(true);
                    playerCam.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", false);
                    enemyAnim.SetBool("damaged", true);
                    enemyAnim.SetBool("damaged", true);
                    yield return new WaitForSeconds(1f);
                    enemyAnim.SetBool("idle", true);
                    enemyAnim.SetBool("damaged", false);
                    divisionSet20.SetActive(false);
                    //attackPanel.SetActive(false);
                    if (enemyHP <= 0)
                    {
                        state = BattleStateS2M14.WON;
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
                    _audioSource.clip = playerError;
                    _audioSource.Play();
                    timerTxt.text = currentTime.ToString("0");
                    timerTxt.color = Color.yellow;

                }
            }
            //end of condition
        }
        
        

       /*
            else
            {
                ClearAllEntries();
                currentTime--;
                _audioSource.clip = playerError;
                _audioSource.Play();
                timerTxt.text = currentTime.ToString("0");
                timerTxt.color = Color.yellow;

            }
        }
        //end of condition
        
        //start of condition
        if (randomizer == 26)
        {
            if ((int)result == answer26)
            {
                StopCoroutine(countdown);
                BattleEvents.gameObject.SetActive(true);
                attackPanel.SetActive(false);
                playerDamage = currentTime;
                currentTime = playerDamage;
                playerDamage = playerDamage - playerDmgReduction;
                if (playerDamage <= 0)
                {
                    playerDamage = 0;
                }
                Attack(enemy, (int)playerDamage);
                switch (randomAttackAnim)
                {
                    case 1:
                        playerAnim.SetBool("attack1", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                    case 2:
                        playerAnim.SetBool("attack2", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                    case 3:
                        playerAnim.SetBool("attack3", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                }
                battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                yield return new WaitForSeconds(0.6f);
                // 
                switch (randomAttackAnim)
                {
                    case 1:
                        playerAnim.SetBool("attack1", false);
                        break;
                    case 2:
                        playerAnim.SetBool("attack2", false);
                        break;
                    case 3:
                        playerAnim.SetBool("attack3", false);
                        break;
                }
                yield return new WaitForSeconds(0.6f);
                enemyCam.gameObject.SetActive(true);
                playerCam.gameObject.SetActive(false);
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", false);
                enemyAnim.SetBool("damaged", true);
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", true);
                enemyAnim.SetBool("damaged", false);
                divisionSet26.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M14.WON;
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
                _audioSource.clip = playerError;
                _audioSource.Play();
                timerTxt.text = currentTime.ToString("0");
                timerTxt.color = Color.yellow;

            }
        }
        //end of condition
        
        
        //start of condition
        if (randomizer == 27)
        {
            if ((int)result == answer27)
            {
                StopCoroutine(countdown);
                BattleEvents.gameObject.SetActive(true);
                attackPanel.SetActive(false);
                playerDamage = currentTime;
                currentTime = playerDamage;
                playerDamage = playerDamage - playerDmgReduction;
                if (playerDamage <= 0)
                {
                    playerDamage = 0;
                }
                Attack(enemy, (int)playerDamage);
                switch (randomAttackAnim)
                {
                    case 1:
                        playerAnim.SetBool("attack1", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                    case 2:
                        playerAnim.SetBool("attack2", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                    case 3:
                        playerAnim.SetBool("attack3", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                }
                battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                yield return new WaitForSeconds(0.6f);
                // 
                switch (randomAttackAnim)
                {
                    case 1:
                        playerAnim.SetBool("attack1", false);
                        break;
                    case 2:
                        playerAnim.SetBool("attack2", false);
                        break;
                    case 3:
                        playerAnim.SetBool("attack3", false);
                        break;
                }
                yield return new WaitForSeconds(0.6f);
                enemyCam.gameObject.SetActive(true);
                playerCam.gameObject.SetActive(false);
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", false);
                enemyAnim.SetBool("damaged", true);
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", true);
                enemyAnim.SetBool("damaged", false);
                
                divisionSet27.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M14.WON;
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
                    battleEventText.text = "Enemy Turn.";
                    resetUponDigitInput = true;
                    ClearAllEntries();
                }
            }
            else
            {
                ClearAllEntries();
                currentTime--;
                _audioSource.clip = playerError;
                _audioSource.Play();
                timerTxt.text = currentTime.ToString("0");
                timerTxt.color = Color.yellow;

            }
        }
        //end of condition
        
        
        //start of condition
        if (randomizer == 28)
        {
            StopCoroutine(countdown);
            if ((int)result == answer28)
            {
                BattleEvents.gameObject.SetActive(true);
                attackPanel.SetActive(false);
                playerDamage = currentTime;
                currentTime = playerDamage;
                playerDamage = playerDamage - playerDmgReduction;
                if (playerDamage <= 0)
                {
                    playerDamage = 0;
                }
                Attack(enemy, (int)playerDamage);
                switch (randomAttackAnim)
                {
                    case 1:
                        playerAnim.SetBool("attack1", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                    case 2:
                        playerAnim.SetBool("attack2", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                    case 3:
                        playerAnim.SetBool("attack3", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                }
                battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                yield return new WaitForSeconds(0.6f);
                // 
                switch (randomAttackAnim)
                {
                    case 1:
                        playerAnim.SetBool("attack1", false);
                        break;
                    case 2:
                        playerAnim.SetBool("attack2", false);
                        break;
                    case 3:
                        playerAnim.SetBool("attack3", false);
                        break;
                }
                yield return new WaitForSeconds(0.6f);
                enemyCam.gameObject.SetActive(true);
                playerCam.gameObject.SetActive(false);
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", false);
                enemyAnim.SetBool("damaged", true);
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", true);
                enemyAnim.SetBool("damaged", false);
                divisionSet28.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M14.WON;
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
                _audioSource.clip = playerError;
                _audioSource.Play();
                timerTxt.text = currentTime.ToString("0");
                timerTxt.color = Color.yellow;

            }
        }
        //end of condition
        
        
        //start of condition
        if (randomizer == 29)
        {
            if ((int)result == answer29)
            {
                StopCoroutine(countdown);
                BattleEvents.gameObject.SetActive(true);
                attackPanel.SetActive(false);
                playerDamage = currentTime;
                currentTime = playerDamage;
                playerDamage = playerDamage - playerDmgReduction;
                if (playerDamage <= 0)
                {
                    playerDamage = 0;
                }
                Attack(enemy, (int)playerDamage);
                switch (randomAttackAnim)
                {
                    case 1:
                        playerAnim.SetBool("attack1", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                    case 2:
                        playerAnim.SetBool("attack2", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                    case 3:
                        playerAnim.SetBool("attack3", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                }
                battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                yield return new WaitForSeconds(0.6f);
                // 
                switch (randomAttackAnim)
                {
                    case 1:
                        playerAnim.SetBool("attack1", false);
                        break;
                    case 2:
                        playerAnim.SetBool("attack2", false);
                        break;
                    case 3:
                        playerAnim.SetBool("attack3", false);
                        break;
                }
                yield return new WaitForSeconds(0.6f);
                enemyCam.gameObject.SetActive(true);
                playerCam.gameObject.SetActive(false);
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", false);
                enemyAnim.SetBool("damaged", true);
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", true);
                enemyAnim.SetBool("damaged", false);
                divisionSet29.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M14.WON;
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
                _audioSource.clip = playerError;
                _audioSource.Play();
                timerTxt.text = currentTime.ToString("0");
                timerTxt.color = Color.yellow;

            }
        }
        //end of condition
        
        
        
        
        
        //start of condition
        if (randomizer == 30)
        {
            if ((int)result == answer30)
            {
                StopCoroutine(countdown);
                BattleEvents.gameObject.SetActive(true);
                attackPanel.SetActive(false);
                playerDamage = currentTime;
                currentTime = playerDamage;
                playerDamage = playerDamage - playerDmgReduction;
                if (playerDamage <= 0)
                {
                    playerDamage = 0;
                }
                Attack(enemy, (int)playerDamage);
                switch (randomAttackAnim)
                {
                    case 1:
                        playerAnim.SetBool("attack1", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                    case 2:
                        playerAnim.SetBool("attack2", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                    case 3:
                        playerAnim.SetBool("attack3", true);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                }
                battleEventText.text = "Player deals " + playerDamage + " damage to the enemy.";
                yield return new WaitForSeconds(0.6f);
                // 
                switch (randomAttackAnim)
                {
                    case 1:
                        playerAnim.SetBool("attack1", false);
                        break;
                    case 2:
                        playerAnim.SetBool("attack2", false);
                        break;
                    case 3:
                        playerAnim.SetBool("attack3", false);
                        break;
                }
                yield return new WaitForSeconds(0.6f);
                enemyCam.gameObject.SetActive(true);
                playerCam.gameObject.SetActive(false);
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", false);
                enemyAnim.SetBool("damaged", true);
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", true);
                enemyAnim.SetBool("damaged", false);
                divisionSet30.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M14.WON;
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
                _audioSource.clip = playerError;
                _audioSource.Play();
                timerTxt.text = currentTime.ToString("0");
                timerTxt.color = Color.yellow;

            }
        }*/
        //end of condition
        
       
        
    }

    public void ClearAllEntries() // C
    {
        display = "";
        display1.text = display;
        enteredOperator = false;
        enteredDot = false;
        resetUponDigitInput = false;
    }

    


    IEnumerator EndBattle()
    {
        if (state == BattleStateS2M14.WON)
        {
            BattleEvents.SetActive(false);
            attackPanel.SetActive(false);
            battleUI.SetActive(false);
            Destroy(enemy);
            _audioSource.clip = playerWin;
            _audioSource.Play();
            winPanel.SetActive(true);
            VoiceAudioSource.clip = winVO;
            VoiceAudioSource.Play();
            yield return new WaitForSeconds(2f);
            loadController.LoadLevel(26);
            //loadController.LoadLevel(1);
            ProgressController.progressInstance.B14Win = true;
            DataPersistenceManager.instance.SaveGame();
            DataPersistenceManager.instance.LoadGame();
            


        }
        else if (state == BattleStateS2M14.LOST)
        {
            _audioSource.clip = playerLose;
            _audioSource.Play();
            VoiceAudioSource.clip = loseVO;
            VoiceAudioSource.Play();
            BattleEvents.SetActive(false);
            attackPanel.SetActive(false);
            battleUI.SetActive(false);
            losePanel.SetActive(true);
            yield return new WaitForSeconds(2f);

        }
    }

    public void returnToMainMenu() // load main menu scene
    {
        loadController.LoadLevel(0);
    }

    public void restartBattle() //restart battle if the player lost
    {
        Scene scene = SceneManager.GetActiveScene();
        loadController.LoadLevel(scene.buildIndex);
    }
    
    
    public int UniqueRandomIntMultiplication(int min, int max)
    {
        int val = Random.Range(min, max);
        while(randomizer == val)
        {
            val = Random.Range(min, max);
        }
        randomizer = val;
        return val;
    }
    
    public int UniqueRandomIntDivision(int min, int max)
    {
        int val = Random.Range(min, max);
        while(randomizer == val)
        {
            val = Random.Range(min, max);
        }
        randomizerSub = val;
        return val;
    }
    
    

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