using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColourPickerUI : MonoBehaviour
{
    public Slider red;
    public Slider green;
    public Slider blue;
    public Slider alpha;

    public Image visualiser;

    public ValueHolder valhol;

    //Assigns the visualiser colour to the fireStartColour value
    public void AssignFireStart()
    {
        valhol.fireStartColour = visualiser.color;
    }
    //Assigns the visualiser colour to the fireMidColour value
    public void AssignFireMid()
    {
        valhol.fireMidColour = visualiser.color;
    }
    //Assigns the visualiser colour to the fireEndColour value
    public void AssignFireEnd()
    {
        valhol.fireEndColour = visualiser.color;
    }
    //Assigns the visualiser colour to the sparkColour value
    public void AssignSparkCol()
    {
        valhol.sparkColour = visualiser.color;
    }

    // Start is called before the first frame update
    void Start()
    {
        //resets values at the start of the program
        red.value = 0;
        green.value = 0;
        blue.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //assigns the values from the sliders to the visualiser
        visualiser.color = new Color (red.value, green.value, blue.value, alpha.value);
    }
}
