using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollector : MonoBehaviour
{
    private Dictionary<float, GameObject> cubeDic;
    private int height = 0;

    private void Awake()
    {
        cubeDic = new Dictionary<float, GameObject>();
        cubeDic.Clear();
        height = 0;
    }
    private void OnTriggerEnter(Collider collision)
    {
        Cube cube = collision.GetComponent<Cube>();
        if (cube != null)
        {
            if (cube.GetIsAlly())
            {
                ScoreboardUI.Instance.UpdateScore(1);
                //En tepeye yeni küp koyarýz
                collision.transform.SetParent(transform);
                height++;
                collision.transform.localPosition = new Vector3(0, height, 0);
                cubeDic.Add(height, collision.gameObject);

                //Ignore bcs visual balance
                Physics.IgnoreCollision(transform.GetComponent<BoxCollider>(), collision.GetComponent<BoxCollider>());
                UpdateCollider();
            }
            else
            {
                for (int i = 0; i < cube.GetCubeDamage(); i++)
                {
                    ScoreboardUI.Instance.UpdateScore(-1);

                    Destroy(collision.gameObject);
                    
                    if (cubeDic.ContainsKey(height))
                    {
                        Destroy(cubeDic[height]);
                        cubeDic.Remove(height);
                    }
                    height--;
                    UpdateCollider();
                }
            }
        }
    }

    private void UpdateCollider()
    {
        transform.GetComponent<BoxCollider>().center = new Vector3(0, height * 0.5f, 0);
        transform.GetComponent<BoxCollider>().size = new Vector3(1, 1 + height, 1);
    }
}
