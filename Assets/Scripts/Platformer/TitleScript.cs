using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    [SerializeField] GameObject playbtn, rulesbtn, creditsbtn, backbtn1, backbtn2;
    [SerializeField] GameObject maincnv, rulescnv, creditscnv;

    // Start is called before the first frame update
    void Start()
    {
        //Show main menu
        //Hide rules
        //Hide credits

        rulescnv.SetActive(false);
        creditscnv.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playbtnclick()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void rulesbtnclick()
    {
        //Hide main menu
        //Show rules

        rulescnv.SetActive(true);
        maincnv.SetActive(false);
    }

    public void creditsclick()
    {
        //Hide main menu
        //Show credits

        creditscnv.SetActive(true);
        maincnv.SetActive(false);
    }

    public void backbtn1click()
    {
        //Hide rules
        //Show main menu

        rulescnv.SetActive(false);
        maincnv.SetActive(true);
    }

    public void backbtn2click()
    {
        //Hide credits
        //Show main menu

        creditscnv.SetActive(false);
        maincnv.SetActive(true);
    }
}
