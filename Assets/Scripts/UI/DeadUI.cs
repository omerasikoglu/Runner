using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadUI : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.anyKeyDown) { SceneManager.LoadScene(0); PlayerPrefs.SetInt("level", 1); }
    }
    private void OnEnable()
    {
        gameObject.SetActive(true);
    }
}