using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    GameObject tapTuStartButton;
    [SerializeField]
    GameObject finalPanel;
    //public GameObject leftPanel;
    //public GameObject rightPanel;

    [SerializeField]
    private GameObject counterPaper;
    [SerializeField]
    private Text counterPaperText;

    [SerializeField]
    private GameObject ñounterMoney;
    [SerializeField]
    private Text ñounterMoneyText;
    [SerializeField]
    private float speedCounterMoney;
    [SerializeField]
    GameObject newCounterMoneyPointTransformObject;
    Transform newCounterMoneyPointTransform;
    bool ñounterMoneyComeToCenter = false;

    GameObject joystickPanelObject;
    UISwipeHandler joystickScript;

    private GameObject player;
    private Player playerScript;

    private int papperCount = 0;

    [SerializeField]
    int conversionNumber = 0; 
    [SerializeField]
    int conversionNumberToTrap = 0;



    // Start is called before the first frame update
    private void Awake()
    {
       
        tapTuStartButton = GameObject.Find("TapToStartButton");
        //newCounterMoneyPointTransformObject = GameObject.Find("newCounterMoneyPointTransformObject");
        newCounterMoneyPointTransform = newCounterMoneyPointTransformObject.GetComponent<Transform>();
       // finalPanel = GameObject.Find("FinalPanel");
        joystickPanelObject = GameObject.Find("JoystickPanel");
        joystickScript = joystickPanelObject.GetComponent<UISwipeHandler>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) || (Input.GetKeyDown(KeyCode.Mouse0)))
        {
            TapToStart();
            Debug.Log("Touch");
        }

    }
    private void LateUpdate()
    {
        if(ñounterMoneyComeToCenter == true)
        {
            ñounterMoney.transform.position = Vector3.MoveTowards(transform.position, newCounterMoneyPointTransform.position, speedCounterMoney * Time.deltaTime);
        }
        
    }

    public void TapToStart()
    {
        //Time.timeScale = 1;
        tapTuStartButton.SetActive(false);
        playerScript.isRun = true;
        counterPaper.SetActive(true);
        ñounterMoney.SetActive(false);
        this.enabled = false;
        //rightPanel.SetActive(true);
        //leftPanel.SetActive(true);
        //startMenuScript.enabled = false; 
        //levelPanel.SetActive(false);
    }
    public void CountPapperText()
    {
        //counterPaper.GetComponent<text
    }
    public void recalculationOfPpaper()
    {
        papperCount++;
        counterPaperText.text =papperCount.ToString();
    }
    public void recalculationOfPpaperBecauseCollidTrap()
    {
        papperCount -= conversionNumberToTrap;
        counterPaperText.text = papperCount.ToString();
    }
    
        public void finalTrigger()
    {
        joystickScript.enabled = false;
        // playerScript.comeToBoss();
        //çàïóñê àíèìàöèè ïåðñåñ÷åòà
        finalPanel.SetActive(true);
        ñounterMoneyComeToCenter = true; ;
        ñounterMoney.SetActive(true);
        conversionsPaperInMoney();
       



    }
     private void conversionsPaperInMoney()
   {
        ñounterMoneyText.text = (papperCount * conversionNumber).ToString();
        papperCount = 0;
   }


    
    
}
