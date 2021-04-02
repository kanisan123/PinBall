using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour
{
    Material myMaterial;

    // Emissionの最小値
    private float minEmission = 0.3f;
    // Emissionの強度
    private float magEmission = 2.0f;
    // 角度(sin関数に入れる位相)
    private int degree = 0;
    //発光速度
    private int speed = 10;
    // ターゲットのデフォルトの色
    Color defaultColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        // タグによって光らせる色を変える
        if (tag == "SmallStarTag")
        {
            defaultColor = Color.white;
        }
        else if (tag == "LargeStarTag")
        {
            defaultColor = Color.yellow;
        }
        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            defaultColor = Color.cyan;
        }

        //オブジェクトにアタッチしているMaterialを取得
        myMaterial = GetComponent<Renderer>().material;

        //オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", defaultColor * minEmission);
    }

    // Update is called once per frame
    void Update()
    {

        if (degree >= 0)
        {
            // 光らせる強度を計算する
            Color emissionColor = defaultColor * (minEmission + Mathf.Sin(degree * Mathf.Deg2Rad) * magEmission);

            // エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //現在の角度を小さくする
            degree -= speed;
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        //角度を180に設定 (徐々に明るく、90度で最も明るくなり、徐々に暗くなる)
        degree = 180;
    }
}
