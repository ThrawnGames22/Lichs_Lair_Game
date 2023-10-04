using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnchorPos : MonoBehaviour
{
    public RectTransform rectTransformToSlotTo;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(-485.6f, 165.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
