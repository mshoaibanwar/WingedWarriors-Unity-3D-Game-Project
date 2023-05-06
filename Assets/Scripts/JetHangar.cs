using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class JetHangar : MonoBehaviour
{
    public GameObject[] jets;
    public TMP_Text JetName;
    public TMP_Text JetDescription;
    public Slider TopSpeed;
    public Slider Range;

    public int currentJet;
    public TMP_Text selectText;

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
                    break;
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
                    break;
                }
            }
        }
    }
    void JetDetails(int i)
    {
        currentJet = i;
        if(PlayerPrefs.GetInt("SelectedPlane", 0) == i)
        {
            selectText.text = "Selected";
        }
        else
        {
            selectText.text = "Select";
        }
        switch (i)
        {
            case 0:
                JetName.text = "Super SpitFire";
                JetDescription.text = "The Supermarine Spitfire is a British single-seat fighter aircraft used by the Royal Air Force and other Allied countries before, during, and after World War II. Many variants of the Spitfire were built.";
                TopSpeed.value = 872f;
                Range.value = 1200f;
                break;
             case 1:
                JetName.text = "F86 Saber";
                JetDescription.text = "The North American F-86 Sabre, sometimes called the Sabrejet, is a transonic jet fighter aircraft. Produced by North American Aviation, the Sabre is best known as the United States' first swept-wing fighter.";
                TopSpeed.value = 1046f;
                Range.value = 1611f;
                break;
            case 2:
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

    public void SelectPlane()
    {
        PlayerPrefs.SetInt("SelectedPlane", currentJet);
        selectText.text = "Selected";
    }
}
