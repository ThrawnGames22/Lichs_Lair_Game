using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AcidTripController : MonoBehaviour
{
    public VolumeProfile NormalProfile;
    public VolumeProfile AcidProfile;
    public Volume SceneVolume;
    public float EffectTime;
    public AchievementController Acheivement;
    // Start is called before the first frame update
    void Start()
    {
      SceneVolume.profile = NormalProfile;
    }

    //void Awake()
    //{
    //    Acheivement = GameObject.Find("Acid Trip").GetComponent<AchievementController>();
    //}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AcidTrip()
    {
        SceneVolume.profile = AcidProfile;
        StartCoroutine(EffectTimer());
        Acheivement.SetAchievmentActive();
    }

    public IEnumerator EffectTimer()
    {
      yield return new WaitForSeconds(EffectTime);
      StopEffects();
    }

    public void StopEffects()
    {
      StopCoroutine(EffectTimer());
      SceneVolume.profile = NormalProfile;
      print("Oh Thank God Its Over");
    }
}
