using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private D_Cube data;

    private float lifeTime = 8f;
    private bool isCollected = false;

    private void Awake()
    {
        Init();
    }
    private void Update()
    {
        Timers();
    }

    private void Timers()
    {
        //ge�tikten sonra arkadaki k�pler full random'sa pool'a eklensin
        if (GroundGenerator.Instance.GetIsFullRandomGenerating())
        {
            //return to pool
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0 && !isCollected)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void Init()
    {
        if (data.isRandom) data.isAlly = UnityEngine.Random.Range(0, 2) == 0 ? true : false;
        data.materialTintColor = data.isAlly ? Color.blue : Color.yellow;
        //lifeTime = 8f;

        data.material = GetComponent<MeshRenderer>().material;
        data.material.SetColor("_MainColor", data.materialTintColor);
    }

    [System.Obsolete] //Player'da childcount'a ula�mak i�in
    private void OnTriggerEnter(Collider collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            Transform rootTransform = player.transform.Find("alive").transform;
            isCollected = true;

            if (data.isAlly)
            {
                ScoreboardUI.Instance.UpdateScore(1);

                //eklenen dost cube'� Player gameObject'inde en tepeye koyar�z
                transform.SetParent(rootTransform);
                this.transform.position = new Vector3(
                collision.transform.localPosition.x,
                collision.transform.localPosition.y * (rootTransform.GetChildCount() + 1),
                collision.transform.localPosition.z);

                //colliderlar ald�ktan sonra aktive olmas�n diye
                GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                ScoreboardUI.Instance.UpdateScore(-1);

                //k�plerimiz biterse �l�r�z yoksa k�p say�m�z azal�r
                if (/*player*/rootTransform.GetChildCount() == 0) //sadece player objesi kald�ysa
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    Destroy(rootTransform.GetChild(rootTransform.childCount - 1).gameObject);
                }
                gameObject.SetActive(false);

            }
        }
    }


}
