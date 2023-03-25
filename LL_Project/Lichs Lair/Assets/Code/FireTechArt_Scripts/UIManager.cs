using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public ValueHolder valhol;

    //FireSpawn Values
        public TextMeshProUGUI fireSpawnFrequency;

    //Fire Values
        public TextMeshProUGUI fireLifetime;
        public Image fireStartColour;
        public Image fireMidColour;
        public Image fireEndColour;
        public TextMeshProUGUI colorChangeSpeed;
        public TextMeshProUGUI fireEmisionStrength;
        public TextMeshProUGUI fireSize;
        public TextMeshProUGUI fireGrowthRate;
        public TextMeshProUGUI fireSpeed;
        public TextMeshProUGUI fireRotSpeed;

    //Fire Value Interactables
        public Slider sliderFireFreq;
        public Slider sliderFireLife;
        //fireStartColour
        //fireMidColour
        //fireEndColour
        public Slider sliderFireColSpeed;
        public Slider sliderFireEmiStren;
        public Slider sliderFireSize;
        public Slider sliderFireGrowRate;
        public Slider sliderFireSpeed;
        public Slider sliderFireRotSpeed;

    //Spark Values
        public TextMeshProUGUI sparksOn;
        public TextMeshProUGUI sparkSpawnFrequency;
        public TextMeshProUGUI sparkLifetime;
        public Image sparkColour;
        public TextMeshProUGUI sparkEmmisionStrength;
        public TextMeshProUGUI sparkSize;
        public TextMeshProUGUI sparkSpeed;
        public TextMeshProUGUI sparkRotSpeed;

    //Spark Value Interactables
        //sparksOn
        public Slider sliderSparkSpawnFrequency;
        public Slider sliderSparkLifetime;
        //sparkColour
        public Slider sliderSparkEmmisionStrength;
        public Slider sliderSparkSize;
        public Slider sliderSparkSpeed;
        public Slider sliderSparkRotSpeed;

    //Changes the SparksOn Bool
    public void SparksOn()
    {
        if(valhol.sparksOn == true)
        {
            valhol.sparksOn = false;
        }
        else if (valhol.sparksOn == false)
        {
            valhol.sparksOn = true;
        }
    }

    //Preset Fire Styles
    //Changes the flame to a normal cosy flame
    public void CosyFlame()
    {
        valhol.fireSpawnFrequency = 2f;
        valhol.fireLifetime = 5f;
        valhol.fireStartColour = new Color(1f, .803f, 0f, 0f);
        valhol.fireMidColour = new Color(1f, 0f, .043f, 1f);
        valhol.fireEndColour = new Color(0f, 0f, 0f, 0f);
        valhol.colorChangeSpeed = 10f;
        valhol.fireEmisionStrength = 2f;
        valhol.fireSize = 2.4f;
        valhol.fireGrowthRate = .5f;
        valhol.fireSpeed = 2f;
        valhol.fireRotSpeed = 7.2f;

        valhol.sparksOn = true;
        valhol.sparkSpawnFrequency = 1.2f;
        valhol.sparkLifetime = 6.2f;
        valhol.sparkColour = new Color(1f, .866f, .023f, 1f);
        valhol.sparkEmmisionStrength = 3.6f;
        valhol.sparkSize = 3.8f;
        valhol.sparkSpeed = 6.2f;
        valhol.sparkRotSpeed = 13.8f;
    }

    //Changes the flame to an icy cold flame
    public void ColdFlame()
    {
        valhol.fireSpawnFrequency = 1.5f;
        valhol.fireLifetime = 8f;
        valhol.fireStartColour = new Color(.607f, .827f, 1f, 0f);
        valhol.fireMidColour = new Color(0f, .486f, 1f, 1f);
        valhol.fireEndColour = new Color(0f, 0f, 0f, 0f);
        valhol.colorChangeSpeed = 10f;
        valhol.fireEmisionStrength = 2f;
        valhol.fireSize = 2.4f;
        valhol.fireGrowthRate = .2f;
        valhol.fireSpeed = 1.5f;
        valhol.fireRotSpeed = 2.8f;

        valhol.sparksOn = true;
        valhol.sparkSpawnFrequency = 5f;
        valhol.sparkLifetime = 3f;
        valhol.sparkColour = new Color(1f, 1f, 1f, 1f);
        valhol.sparkEmmisionStrength = 3.6f;
        valhol.sparkSize = 2f;
        valhol.sparkSpeed = 5f;
        valhol.sparkRotSpeed = 7f;
    }

    //Changes the flame to an icky poison flame
    public void PoisonFlame()
    {
        valhol.fireSpawnFrequency = 2f;
        valhol.fireLifetime = 7f;
        valhol.fireStartColour = new Color(1f, .6f, 0f, 0f);
        valhol.fireMidColour = new Color(0f, .341f, .027f, .5f);
        valhol.fireEndColour = new Color(0f, 0f, 0f, 0f);
        valhol.colorChangeSpeed = 8f;
        valhol.fireEmisionStrength = 1.3f;
        valhol.fireSize = 2.4f;
        valhol.fireGrowthRate = .9f;
        valhol.fireSpeed = 3f;
        valhol.fireRotSpeed = 7.2f;

        valhol.sparksOn = true;
        valhol.sparkSpawnFrequency = 8.4f;
        valhol.sparkLifetime = 2.4f;
        valhol.sparkColour = new Color(0f, .341f, .027f, .25f);
        valhol.sparkEmmisionStrength = 0f;
        valhol.sparkSize = 6.1f;
        valhol.sparkSpeed = 8.4f;
        valhol.sparkRotSpeed = 14f;
    }

    //Changes the flame to a mysterious shadow flame
    public void ShadowFlame()
    {
        valhol.fireSpawnFrequency = 5.5f;
        valhol.fireLifetime = 2.5f;
        valhol.fireStartColour = new Color(1f, 0f, .403f, 0f);
        valhol.fireMidColour = new Color(0f, .137f, 1f, 1f);
        valhol.fireEndColour = new Color(0f, 0f, 0f, 0f);
        valhol.colorChangeSpeed = 10f;
        valhol.fireEmisionStrength = 1.24f;
        valhol.fireSize = 2.4f;
        valhol.fireGrowthRate = -1f;
        valhol.fireSpeed = 4.9f;
        valhol.fireRotSpeed = 20f;

        valhol.sparksOn = true;
        valhol.sparkSpawnFrequency = 3.5f;
        valhol.sparkLifetime = 8.4f;
        valhol.sparkColour = new Color(0.493f, 0f, 1f, 1f);
        valhol.sparkEmmisionStrength = 1f;
        valhol.sparkSize = 2f;
        valhol.sparkSpeed = 1.5f;
        valhol.sparkRotSpeed = 4f;
    }

    private void Start()
    {
        //Defaults the flame to Cosy Flame when the program first opens
        CosyFlame();

        //Fire Slider Listeners. Record all the values in the 'Fire Stats' section of the UI
            sliderFireFreq.onValueChanged.AddListener((v) =>
            {
                valhol.fireSpawnFrequency = v;

            });

            sliderFireLife.onValueChanged.AddListener((v) =>
            {
                valhol.fireLifetime = v;

            });
        
            sliderFireColSpeed.onValueChanged.AddListener((v) =>
            {
                valhol.colorChangeSpeed = v;

            });

            sliderFireEmiStren.onValueChanged.AddListener((v) =>
            {
                valhol.fireEmisionStrength = v;

            });

            sliderFireSize.onValueChanged.AddListener((v) =>
            {
                valhol.fireSize = v;

            });

            sliderFireGrowRate.onValueChanged.AddListener((v) =>
            {
                valhol.fireGrowthRate = v;

            });

            sliderFireSpeed.onValueChanged.AddListener((v) =>
            {
                valhol.fireSpeed = v;

            });

            sliderFireRotSpeed.onValueChanged.AddListener((v) =>
            {
                valhol.fireRotSpeed = v;

            });

        //Spark Listeners. Record all the values in the 'Spark Stats' section of the UI
            sliderSparkSpawnFrequency.onValueChanged.AddListener((v) =>
            {
                valhol.sparkSpawnFrequency = v;

            });

            sliderSparkLifetime.onValueChanged.AddListener((v) =>
            {
                valhol.sparkLifetime = v;

            });

            sliderSparkEmmisionStrength.onValueChanged.AddListener((v) =>
            {
                valhol.sparkEmmisionStrength = v;

            });

            sliderSparkSize.onValueChanged.AddListener((v) =>
            {
                valhol.sparkSize = v;

            });

            sliderSparkSpeed.onValueChanged.AddListener((v) =>
            {
                valhol.sparkSpeed = v;

            });

            sliderSparkRotSpeed.onValueChanged.AddListener((v) =>
            {
                valhol.sparkRotSpeed = v;

            });
    }

    // Update is called once per frame
    void Update()
    {
        //FIRE Slider Updates
            //Frequency
                if (valhol.fireSpawnFrequency != sliderFireFreq.value)
                {
                    sliderFireFreq.value = valhol.fireSpawnFrequency;
                }
            //Liftime
                if (valhol.fireLifetime != sliderFireLife.value)
                {
                    sliderFireLife.value = valhol.fireLifetime;
                }
            //Colour Change Speed
                if (valhol.colorChangeSpeed != sliderFireColSpeed.value)
                {
                    sliderFireColSpeed.value = valhol.colorChangeSpeed;
                }
            //Emission Strength
                if (valhol.fireEmisionStrength != sliderFireEmiStren.value)
                {
                    sliderFireEmiStren.value = valhol.fireEmisionStrength;
                }
            //Size
                if (valhol.fireSize != sliderFireSize.value)
                {
                    sliderFireSize.value = valhol.fireSize;
                }
            //Growth Rate
                if (valhol.fireGrowthRate != sliderFireGrowRate.value)
                {
                    sliderFireGrowRate.value = valhol.fireGrowthRate;
                }
            //Speed
                if (valhol.fireSpeed != sliderFireSpeed.value)
                {
                    sliderFireSpeed.value = valhol.fireSpeed;
                }
            //Rotation Speed
                if (valhol.fireRotSpeed != sliderFireRotSpeed.value)
                {
                    sliderFireRotSpeed.value = valhol.fireRotSpeed;
                }
        //SPARK Slider Updates
            //Spawn Frequency
                if (valhol.sparkSpawnFrequency != sliderSparkSpawnFrequency.value)
                {
                    sliderSparkSpawnFrequency.value = valhol.sparkSpawnFrequency;
                }
            //Lifetime
                if (valhol.sparkLifetime != sliderSparkLifetime.value)
                {
                    sliderSparkLifetime.value = valhol.sparkLifetime;
                }
            //Emission Strength
                if (valhol.sparkEmmisionStrength != sliderSparkEmmisionStrength.value)
                {
                    sliderSparkEmmisionStrength.value = valhol.sparkEmmisionStrength;
                }

            //Size
                if (valhol.sparkSize != sliderSparkSize.value)
                {
                    sliderSparkSize.value = valhol.sparkSize;
                }
            //Speed
                if (valhol.sparkSpeed != sliderSparkSpeed.value)
                {
                    sliderSparkSpeed.value = valhol.sparkSpeed;
                }
            //Rotation Speed
                if (valhol.sparkRotSpeed != sliderSparkRotSpeed.value)
                {
                    sliderSparkRotSpeed.value = valhol.sparkRotSpeed;
                }




    //Fire Value Update. Changes all numbers in the UI so they represent their respective items
        fireSpawnFrequency.text = "" + valhol.fireSpawnFrequency.ToString("0.0");
        fireLifetime.text = "" + valhol.fireLifetime.ToString("0.0");
        fireStartColour.color = new Color(valhol.fireStartColour.r, valhol.fireStartColour.g, valhol.fireStartColour.b, 1f);
        fireMidColour.color = valhol.fireMidColour;
        fireEndColour.color = new Color(valhol.fireEndColour.r, valhol.fireEndColour.g, valhol.fireEndColour.b, 1f);
        colorChangeSpeed.text = "" + valhol.colorChangeSpeed.ToString("0.0");
        fireEmisionStrength.text = "" + valhol.fireEmisionStrength.ToString("0.0");
        fireSize.text = "" + valhol.fireSize.ToString("0.0");
        fireGrowthRate.text = "" + valhol.fireGrowthRate.ToString("0.0");
        fireSpeed.text = "" + valhol.fireSpeed.ToString("0.0");
        fireRotSpeed.text = "" + valhol.fireRotSpeed.ToString("0.0");

        //Spark Value Update. Changes all numbers in the UI so they represent their respective items
        if(valhol.sparksOn == true)
        {
            sparksOn.text = "On";
        }
        else
        {
            sparksOn.text = "Off";
        }
        sparkSpawnFrequency.text = "" + valhol.sparkSpawnFrequency.ToString("0.0");
        sparkLifetime.text = "" + valhol.sparkLifetime.ToString("0.0");
        sparkColour.color = valhol.sparkColour;
        sparkEmmisionStrength.text = "" + valhol.sparkEmmisionStrength.ToString("0.0");
        sparkSize.text = "" + valhol.sparkSize.ToString("0.0");
        sparkSpeed.text = "" + valhol.sparkSpeed.ToString("0.0");
        sparkRotSpeed.text = "" + valhol.sparkRotSpeed.ToString("0.0");
    }
}
