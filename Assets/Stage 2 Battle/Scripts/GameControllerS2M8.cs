using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;


public enum BattleStateS2M8 { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class GameControllerS2M8 : MonoBehaviour
{
    //player anim bool

    public LoadController loadController;
    WaitForSeconds waitTime1 = new WaitForSeconds(2f);
  
    

    int randomizer; //randomizer

    //equation set answers
    [Header("Answer Sets")] public int answer1 = 88;
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
    public int answer21 = 85;
    public int answer22 = 85;
    public int answer23 = 85;
    public int answer24 = 85;
    public int answer25 = 85;
    public int answer26 = 85;
    public int answer27 = 85;
    public int answer28 = 85;
    public int answer29 = 85;
    public int answer30 = 85;
    

    [Header("Hit VFX")] 
    // [SerializeField] private GameObject playerDamaged;
    // [SerializeField] private GameObject enemyDamaged;
    [SerializeField] private ParticleSystem playerDamaged;
    [SerializeField] private ParticleSystem enemyDamaged;
    
    
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

    [Header("Equation Sets")] 
    
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
    [SerializeField] private GameObject multiplicationSet21;
    [SerializeField] private GameObject multiplicationSet22;
    [SerializeField] private GameObject multiplicationSet23;
    [SerializeField] private GameObject multiplicationSet24;
    [SerializeField] private GameObject multiplicationSet25;
    [SerializeField] private GameObject multiplicationSet26;
    [SerializeField] private GameObject multiplicationSet27;
    [SerializeField] private GameObject multiplicationSet28;
    [SerializeField] private GameObject multiplicationSet29;
    [SerializeField] private GameObject multiplicationSet30;


    [Header("Timer")] float currentTime = 0f;
    float startingTime = 30f;
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
    public BattleStateS2M8 state;
    private int healCounter = 0;

    
    void Start()
    {
        healBtn.interactable = false;
        //shuffleEquations();
        state = BattleStateS2M8.PLAYERTURN;
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

   



    private void Attack(GameObject target, int damage)
    {
        if (target == enemy)
        {
            enemyHealth.value -= damage;
            enemyHP = (int)enemyHealth.value;
            enemyHealthTxt.text = enemyHealth.value.ToString();
        }
        else
        {
            playerHP -= damage;
            playerHealth.value = playerHP;
            playerHealthTxt.text = playerHP.ToString();
            // playerHP = (int)playerHealth.value;
            // playerHealth.value
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

     public void BtnSkip()
    {
        playerSkipped = true;
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
        else if (randomizer == 21)
        {
            multiplicationSet21.SetActive(false);
        }
        else if (randomizer == 22)
        {
            multiplicationSet22.SetActive(false);
        }
        else if (randomizer == 23)
        {
            multiplicationSet23.SetActive(false);
        }
        else if (randomizer == 24)
        {
            multiplicationSet24.SetActive(false);
        }
        else if (randomizer == 25)
        {
            multiplicationSet25.SetActive(false);
        }
        else if (randomizer == 26)
        {
            multiplicationSet26.SetActive(false);
        }
        else if (randomizer == 27)
        {
            multiplicationSet27.SetActive(false);
        }
        else if (randomizer == 28)
        {
            multiplicationSet28.SetActive(false);
        }
        else if (randomizer == 29)
        {
            multiplicationSet29.SetActive(false);
        }
        else if (randomizer == 30)
        {
            multiplicationSet30.SetActive(false);
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
    
    public void BtnAttack()
    {

        battleUI.SetActive(false);
        attackPanel.SetActive(true);
        StartCoroutine(randomEquation());
        countdown = StartCoroutine(CountdownTimer());


    }

    public IEnumerator BtnHeal()
    {
        Heal(player, 20);
        _audioSource.clip = playerHealing;
        _audioSource.Play();
        healCounter++;
        BattleEvents.gameObject.SetActive(true);
        battleEventText.text = "Player heals for 20 HP";
        playerHealthTxt.text = playerHealth.value.ToString();
        yield return new WaitForSeconds(2f);
        BattleEvents.gameObject.SetActive(false);
        if (healCounter <4 && playerHP == (int)playerHealth.maxValue)
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

 

    public IEnumerator ChangeTurn()
    {
        playerTurn = !playerTurn;

        if (!playerTurn)
        {
            Debug.Log("Enemy turn");
            state = BattleStateS2M8.ENEMYTURN;
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
            state = BattleStateS2M8.PLAYERTURN;
            battleUI.SetActive(true);
            Debug.Log("Player turn");

            attackBtn.interactable = true;
            if (playerHP == (int)playerHealth.maxValue)
            {
                healBtn.interactable = false;
            }
            else
            {
                healBtn.interactable = true;
            }
            if (healCounter < 3 && playerHP < (int)playerHealth.maxValue)
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
        
        battleEventText.text = "Enemy turn.";
        VoiceAudioSource.clip = enemyTurnVO;
        VoiceAudioSource.Play();
        yield return new WaitForSeconds(2f);
        int enemyDmg = Random.Range(10, 13);
        
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
    
        Attack(player, enemyDmg);
        
        enemyAnim.SetBool("attack", true);
        enemyAnim.SetBool("idle", false);
        _audioSource.clip = enemyAtk;
        _audioSource.Play();
        yield return new WaitForSeconds(1f);
        enemyAnim.SetBool("attack", false);
        enemyAnim.SetBool("idle", true);
        yield return new WaitForSeconds(0.6f);
        enemyCam.gameObject.SetActive(false);
        playerCam.gameObject.SetActive(true);
        playerSwitch.ResetCamera();
        yield return new WaitForSeconds(2f);
        playerAnim.SetBool("hit", true);
        playerDamaged.Play();
        yield return new WaitForSeconds(1f);
        playerAnim.SetBool("hit", false);
        
        yield return new WaitForSeconds(1f);
        enemyBonusDamage = 3;
        Debug.Log("Enemy Damage: " + enemyDmg);
        
        if (playerHP <= 0)
        {
            state = BattleStateS2M8.LOST;
            playerAnim.SetBool("idle", false);
            playerAnim.SetBool("dead", true);
            StartCoroutine(EndBattle());
        }
        else
        {
            battleEventText.text = "Player turn.";
            VoiceAudioSource.clip = playerTurnVO;
            VoiceAudioSource.Play();
            yield return new WaitForSeconds(1f);
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
        randomizer = Random.Range(1, 31);
        if (randomizer == 1)
        {
            /* GameObject equation = Instantiate(multiplicationSet1, multiplicationSet1.transform.position, multiplicationSet1.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet1.SetActive(true);
        }
        else if (randomizer == 2)
        {
            /* GameObject equation = Instantiate(multiplicationSet2, multiplicationSet2.transform.position, multiplicationSet2.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet2.SetActive(true);
        }
        else if (randomizer == 3)
        {
            /* GameObject equation = Instantiate(multiplicationSet2, multiplicationSet2.transform.position, multiplicationSet2.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet3.SetActive(true);
        }
        else if (randomizer == 4)
        {
            /* GameObject equation = Instantiate(multiplicationSet2, multiplicationSet2.transform.position, multiplicationSet2.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet4.SetActive(true);
        }
        else if (randomizer == 5)
        {
            /* GameObject equation = Instantiate(multiplicationSet2, multiplicationSet2.transform.position, multiplicationSet2.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet5.SetActive(true);
        }
        else if (randomizer == 6)
        {
            /* GameObject equation = Instantiate(multiplicationSet2, multiplicationSet2.transform.position, multiplicationSet2.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet6.SetActive(true);
        }
        else if (randomizer == 7)
        {
            /* GameObject equation = Instantiate(multiplicationSet2, multiplicationSet2.transform.position, multiplicationSet2.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet7.SetActive(true);
        }
        else if (randomizer == 8)
        {
            /* GameObject equation = Instantiate(multiplicationSet2, multiplicationSet2.transform.position, multiplicationSet2.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet8.SetActive(true);
        }
        else if (randomizer == 9)
        {
            /* GameObject equation = Instantiate(multiplicationSet2, multiplicationSet2.transform.position, multiplicationSet2.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet9.SetActive(true);
        }
        else if (randomizer == 10)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet10.SetActive(true);
        }
        else if (randomizer == 11)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet11.SetActive(true);
        }
        else if (randomizer == 12)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet12.SetActive(true);
        }
        else if (randomizer == 13)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet13.SetActive(true);
        }
        else if (randomizer == 14)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet14.SetActive(true);
        }
        else if (randomizer == 15)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet15.SetActive(true);
        }
        else if (randomizer == 16)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet16.SetActive(true);
        }
        else if (randomizer == 17)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet17.SetActive(true);
        }
        else if (randomizer == 18)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet18.SetActive(true);
        }
        else if (randomizer == 19)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet19.SetActive(true);
        }
        else if (randomizer == 20)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet20.SetActive(true);
        }
        else if (randomizer == 21)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet21.SetActive(true);
        }
        else if (randomizer == 22)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet22.SetActive(true);
        }
        else if (randomizer == 23)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet23.SetActive(true);
        }
        else if (randomizer == 24)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet24.SetActive(true);
        }
        else if (randomizer == 25)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet25.SetActive(true);
        }
        else if (randomizer == 26)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet26.SetActive(true);
        }
        else if (randomizer == 27)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet27.SetActive(true);
        }
        else if (randomizer == 28)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet28.SetActive(true);
        }
        else if (randomizer == 29)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet29.SetActive(true);
        }
        else if (randomizer == 30)
        {
            /* GameObject equation = Instantiate(multiplicationSet3, multiplicationSet3.transform.position, multiplicationSet3.transform.rotation) as GameObject;
             equation.transform.SetParent(GameObject.Find("EquationParent").transform, false);*/
            multiplicationSet30.SetActive(true);
        }
        
        
        VoiceAudioSource.clip = solveTheVO;
        VoiceAudioSource.Play();
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
            if (currentTime >5)
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
                else if (randomizer == 21)
                {
                    multiplicationSet21.SetActive(false);
                }
                else if (randomizer == 22)
                {
                    multiplicationSet22.SetActive(false);
                }
                else if (randomizer == 23)
                {
                    multiplicationSet23.SetActive(false);
                }
                else if (randomizer == 24)
                {
                    multiplicationSet24.SetActive(false);
                }
                else if (randomizer == 25)
                {
                    multiplicationSet25.SetActive(false);
                }
                else if (randomizer == 26)
                {
                    multiplicationSet26.SetActive(false);
                }
                else if (randomizer == 27)
                {
                    multiplicationSet27.SetActive(false);
                }
                else if (randomizer == 28)
                {
                    multiplicationSet28.SetActive(false);
                }
                else if (randomizer == 29)
                {
                    multiplicationSet29.SetActive(false);
                }
                else if (randomizer == 30)
                {
                    multiplicationSet30.SetActive(false);
                }
                
                //Attack(enemy, (int)currentTime);
                yield return new WaitForSeconds(1f);
                battleEventText.text = "Player deals " + "0" + " damage to the enemy.";
                attackPanel.SetActive(false);
                yield return new WaitForSeconds(1f);
                BattleEvents.gameObject.SetActive(true);
                yield return new WaitForSeconds(1f);
                StartCoroutine(ChangeTurn());
                yield return new WaitForSeconds(1f);
                
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                yield return new WaitForSeconds(2f);
                enemyAnim.SetBool("idle", false);
                enemyAnim.SetBool("damaged", true);
                enemyDamaged.Play();
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", true);
                enemyAnim.SetBool("damaged", false);
                multiplicationSet1.SetActive(false);
                enemyCam.gameObject.SetActive(false);
                playerCam.gameObject.SetActive(true);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                    battleEventText.text = "Enemy Turn";battleEventText.text = "Enemy Turn";
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet2.SetActive(false);
                if (enemyHP <= 0)
                {


                    state = BattleStateS2M8.WON;
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
                    battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                        state = BattleStateS2M8.WON;
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
                    battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                        state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                    state = BattleStateS2M8.WON;
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
            
        else if (randomizer == 6)
        {
            if ((int)result == answer6)
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                    state = BattleStateS2M8.WON;
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
            
        else if (randomizer == 7)
        {
            if ((int)result == answer7)
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
                yield return new WaitForSeconds(0.6f);
                // 
                switch (randomAttackAnim)
                {
                    case 1:
                        playerAnim.SetBool("attack1", false);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                    case 2:
                        playerAnim.SetBool("attack2", false);
                        _audioSource.clip = playerAtk;
                        _audioSource.Play();
                        break;
                    case 3:
                        playerAnim.SetBool("attack3", false);
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
                    state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet8.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet9.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet10.SetActive(false);
                if (enemyHP <= 0)
                {
                    
                    state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet11.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                enemyAnim.SetBool("idle", false);
                enemyAnim.SetBool("damaged", true);
                enemyDamaged.Play();
                yield return new WaitForSeconds(1f);
                enemyAnim.SetBool("idle", true);
                enemyAnim.SetBool("damaged", false);
                multiplicationSet12.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                attackPanel.SetActive(false);
                battleEventText.text = "Player attacks.";
                VoiceAudioSource.clip = playerAttacksVO;
                VoiceAudioSource.Play();
                yield return new WaitForSeconds(1f);
                playerDamage = currentTime;
                currentTime = playerDamage;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet13.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet14.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet15.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet16.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                attackPanel.SetActive(false);
                battleEventText.text = "Player attacks.";
                VoiceAudioSource.clip = playerAttacksVO;
                VoiceAudioSource.Play();
                yield return new WaitForSeconds(1f);
                playerDamage = currentTime;
                currentTime = playerDamage;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet17.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                attackPanel.SetActive(false);
                battleEventText.text = "Player attacks.";
                VoiceAudioSource.clip = playerAttacksVO;
                VoiceAudioSource.Play();
                yield return new WaitForSeconds(1f);
                playerDamage = currentTime;
                currentTime = playerDamage;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet18.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet19.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet20.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
        if (randomizer == 21)
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet21.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
        if (randomizer == 22)
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet22.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
        if (randomizer == 23)
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet23.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
        if (randomizer == 24)
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet24.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
        if (randomizer == 25)
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet25.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
        if (randomizer == 26)
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet26.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player attacks.";
                VoiceAudioSource.clip = playerAttacksVO;
                VoiceAudioSource.Play();
                yield return new WaitForSeconds(1f);
                playerDamage = currentTime;
                currentTime = playerDamage;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                
                multiplicationSet27.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
        if (randomizer == 28)
        {
            StopCoroutine(countdown);
            if ((int)result == answer28)
            {
                BattleEvents.gameObject.SetActive(true);
                attackPanel.SetActive(false);
                battleEventText.text = "Player attacks.";
                VoiceAudioSource.clip = playerAttacksVO;
                VoiceAudioSource.Play();
                yield return new WaitForSeconds(1f);
                playerDamage = currentTime;
                currentTime = playerDamage;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet28.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player attacks.";
                VoiceAudioSource.clip = playerAttacksVO;
                VoiceAudioSource.Play();
                yield return new WaitForSeconds(1f);
                playerDamage = currentTime;
                currentTime = playerDamage;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet29.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
                battleEventText.text = "Player attacks.";
                VoiceAudioSource.clip = playerAttacksVO;
                VoiceAudioSource.Play();
                yield return new WaitForSeconds(1f);
                playerDamage = currentTime;
                currentTime = playerDamage;
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
                battleEventText.text = "Player deals " + currentTime + " damage to the enemy.";
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
                multiplicationSet30.SetActive(false);
                //attackPanel.SetActive(false);
                if (enemyHP <= 0)
                {
                    state = BattleStateS2M8.WON;
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
        if (state == BattleStateS2M8.WON)
        {
            BattleEvents.SetActive(false);
            attackPanel.SetActive(false);
            battleUI.SetActive(false);
            Destroy(enemy);
            _audioSource.clip = playerWin;
            _audioSource.Play();
            VoiceAudioSource.clip = winVO;
            VoiceAudioSource.Play();
            winPanel.SetActive(true);
            yield return new WaitForSeconds(2f);
            loadController.LoadLevel(9);
            //loadController.LoadLevel(8);
            ProgressController.progressInstance.B8Win = true;
            DataPersistenceManager.instance.SaveGame();
            DataPersistenceManager.instance.LoadGame();
            // DontDestroyOnLoad(this.gameObject);
            //OnSceneLoaded("village_test", mode);

            /*GameObject gameObject = GameObject.Find("MB");
            gameObject.SetActive(false);*/
            // SavingSystem.i.Load("saveSlot1");


        }
        else if (state == BattleStateS2M8.LOST)
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

}

