using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkParticleBrain : MonoBehaviour
{
    public ValueHolder valhol;

    public float indSparkLifetime;
    public Color indSparkColour;
    public float indSparkEmisionStrength;
    public float indSparkSize;
    public float indSparkSpeed;
    public float indSparkRotSpeed;

    public Material sparkMat;

    public Vector3 rotateAngle;
    public float RAX;
    public float RAY;
    public float RAZ;

    public float startX;
    public float startY;
    public float startZ;

    private void Start()
    {
        //saves all the data to the individual particle so any changes arent universal
        indSparkLifetime = valhol.sparkLifetime;
        indSparkColour = valhol.sparkColour;
        indSparkEmisionStrength= valhol.sparkEmmisionStrength;
        indSparkSize = valhol.sparkSize;
        indSparkSpeed = valhol.sparkSpeed;
        indSparkRotSpeed = valhol.sparkRotSpeed;

        //changes start size according to input
        transform.localScale = Vector3.one * indSparkSize * .1f;

        //generates a random rotation axis
        RAX = Random.Range(0f, 1f);
        RAY = Random.Range(0f, 1f);
        RAZ = Random.Range(0f, 1f);
        rotateAngle = new Vector3(RAX, RAY, RAZ);

        //spawns spark in a random rotation
        startX = Random.Range(0f, 360f);
        startY = Random.Range(0f, 360f);
        startZ = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(startX, startY, startZ);

        //Retrieves the emission color variable from the spark and assigns it
        sparkMat = GetComponent<MeshRenderer>().material;
        sparkMat.color = indSparkColour;
        sparkMat.EnableKeyword("EMISSION");
        sparkMat.SetColor("_EmissionColor", indSparkColour * indSparkEmisionStrength);
    }

    private void Update()
    {
        //dies after lifetime reaches zero
        indSparkLifetime -= Time.deltaTime;
        if (indSparkLifetime < 0)
        {
            Destroy(this.gameObject);
        }

        //makes spark go upwards by the speed modifier with added variation from its own local space
        transform.Translate(Vector3.up * indSparkSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * indSparkSpeed * Time.deltaTime, Space.Self);
        //rotates fire by rot speed modifier
        transform.Rotate(rotateAngle * indSparkRotSpeed * Time.deltaTime * 10);
    }
}