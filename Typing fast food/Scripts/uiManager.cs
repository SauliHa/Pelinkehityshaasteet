using System;
using Random = UnityEngine.Random;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
    public Text customerOrderText;
    public Text todayCustomerText;
    public Text satisfiedCustomersText;
    public Text unsatisfiedCustomersText;
    public Text totalCashText;
    public Text todaysCashText;
    public Text dayText;
    public GameObject gameOverScreen;
    public GameObject dayCompleteScreen;
    public GameObject customerSpawner;

    public int maxUnsatisfied;

    GameObject currentCustomer;
    AudioSource aud;

    string[] possibleOrders;
    string currentOrder;
    string currentOrderFilled;
    string currentOrderLeft;
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));

    int satisfiedCustomers;
    int unsatisfiedCustomers;
    int totalCustomersToday;
    int servedCustomersToday;
    int totalCash;
    int todayCash;
    int day;

    float wordTimer;
    float timeForWord;

    string currentChar;
    bool currentOrderActive;
    bool dayActive;

    void Start()
    {
        possibleOrders = new string[] { "Big Mac", "Double Big Mac", "Fries", "Happy Meal", "Cheese Burger", "Double Cheese Burger", "Vegan Salad", "Chicken salad", "Ice cream" };
        aud = GetComponent<AudioSource>();
        satisfiedCustomers = 0;
        unsatisfiedCustomers = 0;
        totalCash = 0;
        day = 0;
        timeForWord = 5.4f;
        initiateDay();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown && currentOrderActive && dayActive)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    fillLetter(keyCode.ToString());
                }
            }
        }

        if(wordTimer > 0f)
        {
            wordTimer -= Time.deltaTime;
        }else if(wordTimer <= 0f && currentOrderActive){
            orderFailed();
        }
    }

    void initiateDay()
    {
        day++;
        totalCustomersToday = Random.Range(6, 13);
        dayActive = true;
        gameOverScreen.SetActive(false);
        dayCompleteScreen.SetActive(false);
        servedCustomersToday = 0;
        todayCash = 0;
        timeForWord -= 0.4f;
        Debug.Log("time " + timeForWord);
        dayText.text = "Day " + day;
        todayCustomerText.text = "Today's customers: " + servedCustomersToday + " / " + totalCustomersToday;
        satisfiedCustomersText.text = "Satisfied: " + satisfiedCustomers;
        unsatisfiedCustomersText.text = "Unsatisfied: " + unsatisfiedCustomers;
        customerOrderText.text = "";
        customerSpawner.GetComponent<customerSpawnScript>().createCustomer();
    }

    public void nextOrder(GameObject customer)
    {
        currentCustomer = customer;
        int randomOrder = Random.Range(0, possibleOrders.Length);
        currentOrder = possibleOrders[randomOrder];
        currentOrderLeft = possibleOrders[randomOrder];
        customerOrderText.text = currentOrder;
        currentOrderFilled = "";     
        currentOrderActive = true;
        wordTimer = timeForWord;
    }

    void fillLetter(string pressedLetter)
    {
        currentChar = currentOrderLeft[0].ToString().ToUpper();
        if(currentChar == pressedLetter)
        {
            currentOrderFilled = currentOrderFilled + currentOrderLeft[0];
            currentOrderLeft = currentOrderLeft.Substring(1);
            
            if (currentOrderLeft.Length <= 0)
            {
                orderFinished();
            }
            else
            {
                if (currentOrderLeft[0].ToString() == " ")
                {
                    currentOrderFilled = currentOrderFilled + currentOrderLeft[0];
                    currentOrderLeft = currentOrderLeft.Substring(1);
                }
                
                customerOrderText.text = "<color=yellow>" + currentOrderFilled + "</color>" + currentOrderLeft;
            }     
        }
        else
        {
            Debug.Log("wrong letter pressed");
        }
    }

    void orderFinished()
    {
        currentOrderActive = false;
        customerOrderText.text = "<color=green>" + currentOrder + "</color>";
        satisfiedCustomers++;
        servedCustomersToday++;
        todayCash += 5;
        totalCash += 5;
        todayCustomerText.text = "Today's customers: " + servedCustomersToday + " / " + totalCustomersToday;
        satisfiedCustomersText.text = "Satisfied: " + satisfiedCustomers;
        totalCashText.text = totalCash + "€";        
        currentCustomer.GetComponent<customerScript>().startMoving();
        aud.Play();

        if (servedCustomersToday >= totalCustomersToday)
            dayFinished();
        else
            customerSpawner.GetComponent<customerSpawnScript>().createCustomer();   
    }

    void orderFailed()
    {
        currentOrderActive = false;
        customerOrderText.text = "<color=red>" + currentOrder + "</color>";
        unsatisfiedCustomers++;
        servedCustomersToday++;
        todayCustomerText.text = "Today's customers: " + servedCustomersToday + " / " + totalCustomersToday;
        unsatisfiedCustomersText.text = "Unsatisfied: " + unsatisfiedCustomers;
        
        currentCustomer.GetComponent<customerScript>().startMoving();
      
        if(unsatisfiedCustomers > maxUnsatisfied)
            gameOver();
        else if (servedCustomersToday >= totalCustomersToday)
            dayFinished();
        else
            customerSpawner.GetComponent<customerSpawnScript>().createCustomer();    
    }

    void dayFinished()
    {

        dayActive = false;
        dayCompleteScreen.SetActive(true);
        todaysCashText.text = "Today's earnings: " + todayCash + "€";
    }

    void gameOver()
    {
        gameOverScreen.SetActive(true);
        dayActive = false;
    }

    public void tryAgain()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void nextDay()
    {
        initiateDay();
    }
}
