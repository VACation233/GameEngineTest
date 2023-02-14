using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject ammoPanel;
    public GameObject scorePanel;
    public GameObject statePanel;
    //public GameObject pausePanel;
    public TMP_Text currentAmmoNum, score, gameState, fireState, weaponState, totalAmmoNum;
    public bool isPaused;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
