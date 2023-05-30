using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    public GameObject thanksPanel;
    public Image thanksPanelBlack;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(thanksPanel, 4);
    }

    // Update is called once per frame
    void Update()
    {

        if (thanksPanelBlack != null)
        {
            thanksPanelBlack.color -= new Color(0f, 0f, 0f, 0.01f);
        }     

        if (Time.timeSinceLevelLoad >= 3f)
        {
            SceneManager.LoadScene("GAME", LoadSceneMode.Single);
        }
    }
}
