using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    GameObject tapTuStartButton;
    //GameObject levelPanel;
    //public GameObject leftPanel;
    //public GameObject rightPanel;

    public GameObject counterPaper;
    public Text counterPaperText;

    public GameObject �ounterMoney;
    public Text �ounterMoneyText; 
    private GameObject player;
    private Player playerScript;
    
    GameObject startMainObject;
    Main startMenuScript;

    private int papper = 0;


    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 0;
        tapTuStartButton = GameObject.Find("TapToStartButton");
        // levelPanel = GameObject.Find("LevelPanel");
        startMainObject = GameObject.Find("Main Camera");
        startMenuScript = startMainObject.GetComponent<Main>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();

        //leftPanel = GameObject.Find("LeftPanel");
        //rightPanel = GameObject.Find("RightPanel");
        //counterPaper = GameObject.Find("CountMoneyPanel");
        //�ounterMoney = GameObject.Find("CountPaperPanel");


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

    public void TapToStart()
    {
        Time.timeScale = 1;
        tapTuStartButton.SetActive(false);
        playerScript.isRun = true;
        counterPaper.SetActive(true);
        �ounterMoney.SetActive(false);
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
    public void papperCounter()
    {
        papper++;
        counterPaperText.text = GetCountUI().ToString();
    }
    public int GetCountUI()
    {
        return papper;
    }
        public void finalTrigger()
    {
        // ��� ������ ���� �������� ������� ��������� �������� 
        �ounterMoney.SetActive(true);
        playerScript.isRun = false;
        //������ �������� ����������
        �ounterMoneyText.text = counterPaperText.text;
        counterPaperText.text = "0";

    }
    /* private void conversions()
       {
       papper = counterPaperText.text

       �ounterMoneyText.text = counterPaperText.text * conversionNumber;
           counterPaperText = "0";
   }*/
}
