using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIControls : MonoBehaviour
{
    [SerializeField] private GameObject playerName;
    [SerializeField] private GameObject playerAge;
    [SerializeField] private int ageIS;
    [SerializeField] private Color32[] colors;
    [SerializeField] private float size;
    [SerializeField] private float rorate;
    [SerializeField] private GameObject moose;
    [SerializeField] private Slider colorSlider;
    [SerializeField] private Slider rotateSlider;
    [SerializeField] private Slider sizeSlider;
    [SerializeField] private TextMeshProUGUI input;

    private void Awake()
    {
        //Sets up the colors the moose can change to
        colors = new Color32[4];
        colors[0] = new Color32(185, 0, 185, 255);
        colors[1] = new Color32(0, 127, 255, 255);
        colors[2] = new Color32(0, 0, 255, 255);
        colors[3] = new Color32(0, 255, 255, 255);
        
        //Shows the player thier info in the game scene
        input.text = "Hi " + PlayerPrefs.GetString("name", "default") + ", your age is " + PlayerPrefs.GetString("age");
    }  

    //Takes Player's name
    public void NameInput()
    {
        PlayerPrefs.SetString("name", playerName.GetComponent<TMP_InputField>().text);

        Debug.Log(PlayerPrefs.GetString("name", "default"));
    }

    //Takes player's age
    public void AgeInput()
    {
        PlayerPrefs.SetString("age", playerAge.GetComponent<TMP_InputField>().text);

        Debug.Log(PlayerPrefs.GetInt("age", 0));
    }

    // Tells slider to rotate the moose
    public void Rotate()
    {
        float mooseRotValue = (rotateSlider.value * 90f) - 45;
        moose.transform.eulerAngles = new Vector3(0, 0, mooseRotValue);
    }

    // Tells slider to size up/down the moose
    public void Scale()
    {
        float newMooseSize = sizeSlider.value;
        moose.transform.localScale = new Vector2(newMooseSize, newMooseSize);
    }

    // Tells slider to change the color of the moose
    public void ColorChange()
    {
        float newMooseColor = colorSlider.value;
        moose.GetComponent<SpriteRenderer>().color = colors[(int)newMooseColor];
    }

    //Tells Button to load the game
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
