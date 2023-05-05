using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPScreenHP : MonoBehaviour
{

    public Player304 hp;

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = hp.healthPoints.ToString();
        text.textStyle = TMP_Style.NormalStyle;
        text.fontStyle = FontStyles.Normal;
        text.color = Color.black;

        if (hp.healthPoints <= 0)
        {
            Destroy(gameObject);
        }

    }
}
