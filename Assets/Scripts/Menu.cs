using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    GameObject tapTuStartButton;
    GameObject levelPanel;
    public GameObject leftPanel;
   // public GameObject rightPanel;
    public GameObject counterPaper;
    public GameObject ñounterMoney;
    GameObject startMainObject;
    Menu startMenuScript;
   
    
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 0;
        tapTuStartButton = GameObject.Find("TapToStartButton");
        levelPanel = GameObject.Find("LevelPanel");
        startMainObject = GameObject.Find("Main Camera");
        startMenuScript = startMainObject.GetComponent<Menu>();
       
        //leftPanel = GameObject.Find("LeftPanel");
        //rightPanel = GameObject.Find("RightPanel");
        //counterPaper = GameObject.Find("CountMoneyPanel");
        //ñounterMoney = GameObject.Find("CountPaperPanel");


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
            if (Input.touchCount > 0)
            {
                TapToStart();
                Debug.Log("Touch");
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                TapToStart();
                Debug.Log("clik");
            }
    }

    public void TapToStart()
    {
        Time.timeScale = 1;
        tapTuStartButton.SetActive(false);
        levelPanel.SetActive(false);
        counterPaper.SetActive(true);
        ñounterMoney.SetActive(false);
        //rightPanel.SetActive(true);
        leftPanel.SetActive(true);
        startMenuScript.enabled = false;
       
    }
}
