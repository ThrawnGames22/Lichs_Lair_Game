using UnityEngine;
using System.Collections;
using UnityEditor.ShaderGraph.Internal;

public class CameraShake : MonoBehaviour
{
	public bool start = false;
    public AnimationCurve curve;

    public float duration = 1f;

    private void Update() {
        if(start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    public IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float ElapsedTime = 0f;

        while(ElapsedTime < duration)
        {
            ElapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(ElapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }
    }

}