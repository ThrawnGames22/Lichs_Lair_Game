using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticleBrain : MonoBehaviour
{
    public ValueHolder valhol;

    public float indFireLifetime;
    public Color indFireStartColour;
    public Color indFireMidColour;
    public Color indFireEndColour;
    public float indFireEmisionStrength;
    public float indFireSize;
    public float indFireGrowthRate;
    public float indFireSpeed;
    public float indColorChangeSpeed;
    public float indFireRotSpeed;

    private float halfLife;
    public Color targetColor;
    public Color lerpedColor;
    private Material fireMat;
    public Light fireLight;

    public Vector3 startSize;

    public Vector3 rotateAngle;
    public float RAX;
    public float RAY;
    public float RAZ;

    public float startX;
    public float startY;
    public float startZ;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flammable"))
        {
            other.gameObject.AddComponent<FireSpawn>();
            other.tag = "Burning";
        }
    }

    private void Start()
    {
        //saves all the data to the individual particle so any changes arent universal
        indFireLifetime = valhol.fireLifetime;
        indFireStartColour = valhol.fireStartColour;
        indFireMidColour = valhol.fireMidColour;
        indFireEndColour = valhol.fireEndColour;
        indFireEmisionStrength = valhol.fireEmisionStrength;
        indFireSize = valhol.fireSize;
        indFireGrowthRate = valhol.fireGrowthRate;
        indFireSpeed = valhol.fireSpeed;
        indColorChangeSpeed = valhol.colorChangeSpeed;
        indFireRotSpeed = valhol.fireRotSpeed;
        //Records half life of fire particle for use in colour lerping
        halfLife = indFireLifetime * .5f;

        //changes start size according to input
        startSize = Vector3.one * indFireSize;
        transform.localScale = startSize;

        //generates a random rotation axis
        RAX = Random.Range(0f, 1f);
        RAY = Random.Range(0f, 1f);
        RAZ = Random.Range(0f, 1f);
        rotateAngle = new Vector3(RAX, RAY, RAZ);

        //spawns fire in a random rotation
        startX = Random.Range(0f, 360f);
        startY = Random.Range(0f, 360f);
        startZ = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(startX, startY, startZ);

        //Retrieves the emission variable from the fire and assigns it
        fireMat = GetComponent<MeshRenderer>().material;
        fireMat.color = indFireStartColour;
        fireMat.EnableKeyword("EMISSION");
    }

    private void Update()
    {
        //dies after lifetime reaches zero
        indFireLifetime -= Time.deltaTime;
        if (indFireLifetime < 0)
        {
            Destroy(this.gameObject);
        }

        
        //determines what colour fire should lerp to based on lifetime
        if(indFireLifetime > halfLife)
        {
            targetColor = indFireMidColour;
        }
        else if (indFireLifetime < halfLife)
        {
            targetColor = indFireEndColour;
        }
        //lerps colours
        fireMat.color = lerpedColor = Color.Lerp(fireMat.color, targetColor, indColorChangeSpeed * Time.deltaTime * .1f);
        //changes emsision colour to be the same so fire glows
        fireMat.SetColor("_EmissionColor", fireMat.color * indFireEmisionStrength);
        fireLight.color = lerpedColor;

        //makes fire go upwards by the speed modifier
        transform.Translate(Vector3.up * indFireSpeed * Time.deltaTime, Space.World);
        //rotates fire by rot speed modifier
        transform.Rotate(rotateAngle * indFireRotSpeed * Time.deltaTime * 10);

        //makes fire grow/shrink as per the growth rate
        transform.localScale = startSize * indFireSize;
        indFireSize += indFireGrowthRate * Time.deltaTime;
    }
}

