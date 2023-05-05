using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JetHangar : MonoBehaviour
{
    public GameObject[] jets;
    public TMP_Text JetName;
    public TMP_Text JetDescription;
    public Slider TopSpeed;
    public Slider Range;
    // Start is called before the first frame update
    void Start()
    {
        jets[0].SetActive(true);
        JetDetails(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Next()
    {
        for(int i=0; i<jets.Length; i++)
        {
            if(jets[i].activeSelf)
            {
                if((i+1) < jets.Length)
                {
                    jets[i+1].SetActive(true);
                    jets[i].SetActive(false);
                    JetDetails(i+1);
                }
            }
        }
    }
    public void Previous()
    {
        for(int i=jets.Length-1; i>=0; i--)
        {
            if((i-1) >= 0)
            {
                if(jets[i].activeSelf)
                {
                    jets[i-1].SetActive(true);
                    jets[i].SetActive(false);
                    JetDetails(i-1);
                }
            }
        }
    }
    void JetDetails(int i)
    {
        switch (i)
        {
            case 0:
                JetName.text = "F86 Saber";
                JetDescription.text = "The North American F-86 Sabre, sometimes called the Sabrejet, is a transonic jet fighter aircraft. Produced by North American Aviation, the Sabre is best known as the United States' first swept-wing fighter.";
                TopSpeed.value = 1046f;
                Range.value = 1611f;
                break;
            case 1:
                JetName.text = "F16";
                JetDescription.text = "The F-16 Fighting Falcon is an American single-engine multirole fighter aircraft originally developed by General Dynamics. Designed as an air superiority day fighter, it evolved into a successful all-weather multirole aircraft.";
                TopSpeed.value = 2123f;
                Range.value = 4220f;
                break;

            default:
                JetName.text = "F86 Saber";
                JetDescription.text = "The North American F-86 Sabre, sometimes called the Sabrejet, is a transonic jet fighter aircraft. Produced by North American Aviation, the Sabre is best known as the United States' first swept-wing fighter.";
                TopSpeed.value = 1046f;
                Range.value = 1611f;
                break;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
