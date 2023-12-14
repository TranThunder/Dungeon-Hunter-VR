using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    public AnimationCurve opacityCurve;
    public AnimationCurve scaleCurve;
    public AnimationCurve heightcurve;
    public float yOffset;
    TextMeshProUGUI textMeshProUGUI;
    float time = 0;
    Vector3 origin;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI=transform.GetComponentInChildren<TextMeshProUGUI>();
        origin = transform.position;
        cam=Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward=cam.transform.forward;
        textMeshProUGUI.color = new Color(1,1,1,opacityCurve.Evaluate(time));
        transform.localScale=Vector3.one*scaleCurve.Evaluate(time);
        transform.position= origin+new Vector3(0,yOffset+heightcurve.Evaluate(time),0);
        time += Time.deltaTime;
        if (time >= 1)
        {
            Destroy(gameObject);
        }
    }
}
