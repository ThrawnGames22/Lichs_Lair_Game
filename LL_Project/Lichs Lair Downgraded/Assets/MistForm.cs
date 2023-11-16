using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

public class MistForm : MonoBehaviour
{
    public VolumeProfile StandardVolume;
    public VolumeProfile MistEffect;

    public Volume GlobalVolume;

    public float EffectTime;

    public UtilitySpell utilitySpell;

    public GameObject Player;

    public int PlayerSpeedToAffect;

    public SkinnedMeshRenderer PlayerRenderer;

    public bool IsShadowWizard;
    public bool IsFireMage;
    public bool IsPaladin;

    public ClassData SWCD;
    public ClassData FMCD;
    public ClassData PDCD;


    

    [Header("Shadow Wizard Materials")]

    public Material SPlayerElement0;
    public Material SPlayerElement1;
    public Material SPlayerElement2;
    public Material SPlayerElement3;
    public Material SPlayerElement4;
    public Material SPlayerElement5;
    public Material SPlayerElement6;
    public Material SPlayerElement7;
    public Material SPlayerElement8;
    public Material SPlayerElement9;
    public Material SPlayerElement10;


    [Header("Shadow Wizard Materials")]

    public Material RPlayerElement0;
    public Material RPlayerElement1;
    public Material RPlayerElement2;
    public Material RPlayerElement3;
    public Material RPlayerElement4;
    public Material RPlayerElement5;
    public Material RPlayerElement6;
    public Material RPlayerElement7;
    public Material RPlayerElement8;

    [Header("Paladin Materials")]

    public Material PPlayerElement0;
    public Material PPlayerElement1;
    public Material PPlayerElement2;
    public Material PPlayerElement3;
    public Material PPlayerElement4;
    public Material PPlayerElement5;
    public Material PPlayerElement6;
    public Material PPlayerElement7;
    public Material PPlayerElement8;
    public Material PPlayerElement9;

    

    [Header("Mist Material")]
    public Material MistMaterial;

    [Header("Enemies")]
    public List<GameObject> Enemies;
    public List<GameObject> FistObject;
    
    

    public bool IsActive;
    // Start is called before the first frame update
    void Start()
    {
        GlobalVolume = GameObject.Find("Global Volume").GetComponent<Volume>();
        EffectTime = utilitySpell.spellToCast.Lifetime;
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerRenderer = GameObject.FindGameObjectWithTag("PlayerRenderer").GetComponent<SkinnedMeshRenderer>();

        StartCoroutine(Mist());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<PlayerController>().IsShadowWizard)
        {
            IsShadowWizard = true;
            IsFireMage = false;
            IsPaladin = false;
        }

        if(Player.GetComponent<PlayerController>().IsFireMage)
        {
            IsShadowWizard = false;
            IsFireMage = true;
            IsPaladin = false;
        }

        if(Player.GetComponent<PlayerController>().IsPaladin)
        {
            IsShadowWizard = false;
            IsFireMage = false;
            IsPaladin = true;
        }

        Enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        FistObject = new List<GameObject>(GameObject.FindGameObjectsWithTag("EnemyCollider"));

        if(IsActive)
        {
            Player.GetComponent<PlayerHealth>().DamageScreen = null;
            foreach(GameObject enemy in Enemies)
        {
            enemy.GetComponent<EnemyHealth>().DisableCollider = true;
            enemy.GetComponent<EnemyController>().DamageToApply = 0;

        }

        
        foreach(GameObject Fist in FistObject)
        {
            Fist.GetComponent<FistCollider>().enabled = false;
            //Fist.GetComponent<SphereCollider>().enabled = false;

        }
        }

        if(!IsActive)
        {
            Player.GetComponent<PlayerHealth>().DamageScreen = Player.GetComponent<PlayerHealth>().DamageScreenObject;
            foreach(GameObject enemy in Enemies)
        {
            enemy.GetComponent<EnemyHealth>().DisableCollider = false;
            enemy.GetComponent<EnemyController>().DamageToApply =enemy.GetComponent<EnemyController>().OriginalDamageToApply;
        }

        foreach(GameObject Fist in FistObject)
        {
            Fist.GetComponent<FistCollider>().enabled = true;
            //Fist.GetComponent<SphereCollider>().enabled = true;

        }
        }
    }

    public IEnumerator Mist()
    {
        
        Material[] mats = PlayerRenderer.materials;
        //Time.timeScale = 0.5f;
        Player.GetComponent<PlayerController>().speed = PlayerSpeedToAffect;
        //GlobalVolume.profile = MistEffect;
        mats[0] = MistMaterial;
        mats[1] = MistMaterial;
        mats[2] = MistMaterial;
        mats[3] = MistMaterial;
        mats[4] = MistMaterial;
        mats[5] = MistMaterial;
        mats[6] = MistMaterial;
        mats[7] = MistMaterial;
        mats[8] = MistMaterial;
        mats[9] = MistMaterial;
        mats[10] = MistMaterial;

        PlayerRenderer.materials = mats;
        IsActive = true;
        
       



        
        yield return new WaitForSeconds(EffectTime);
        IsActive = false;

        //foreach(GameObject enemy in Enemies)
        //{
        //    enemy.GetComponent<EnemyHealth>().DisableCollider = false;
        //}

        if(IsShadowWizard)
        {

        mats[0] = SPlayerElement0;
        mats[1] = SPlayerElement1;
        mats[2] = SPlayerElement2;
        mats[3] = SPlayerElement3;
        mats[4] = SPlayerElement4;
        mats[5] = SPlayerElement5;
        mats[6] = SPlayerElement6;
        mats[7] = SPlayerElement7;
        mats[8] = SPlayerElement8;
        mats[9] = SPlayerElement9;
        mats[10] = SPlayerElement10;

        PlayerRenderer.materials = mats;
        }

        if(IsFireMage)
        {

        mats[0] = RPlayerElement0;
        mats[1] = RPlayerElement1;
        mats[2] = RPlayerElement2;
        mats[3] = RPlayerElement3;
        mats[4] = RPlayerElement4;
        mats[5] = RPlayerElement5;
        mats[6] = RPlayerElement6;
        mats[7] = RPlayerElement7;
        mats[8] = RPlayerElement8;
        }

        if(IsPaladin)
        {

        mats[0] = PPlayerElement0;
        mats[1] = PPlayerElement1;
        mats[2] = PPlayerElement2;
        mats[3] = RPlayerElement3;
        mats[4] = PPlayerElement4;
        mats[5] = RPlayerElement5;
        mats[6] = PPlayerElement6;
        mats[7] = PPlayerElement7;
        mats[8] = PPlayerElement8;
        mats[9] = PPlayerElement9;

        }
        


        //GlobalVolume.profile = StandardVolume;
        //Time.timeScale = 1f;
        Player.GetComponent<PlayerController>().speed = 5;
        
        Destroy(this.gameObject, 1);
     
    }
}
