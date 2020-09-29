using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluppyBirdColumnCtrl : MonoBehaviour
{
    private static FluppyBirdColumnCtrl instance = null;

    public GameObject[] columnList = new GameObject[5];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public static FluppyBirdColumnCtrl Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public void ChangeColumn(GameObject passColumn)
    {
        for (int i = 0; i < columnList.Length; i++)
        {
            if (columnList[i] == passColumn)
            {
                int previousIDX = (i + 4) % 5;
                int nextIDX = (i + 2) % 5;
                columnList[(i + 4) % 5].SetActive(false);
                columnList[(i + 2) % 5].SetActive(true);
                float columnHeight = Random.Range(2f, 7f);
                columnList[(i + 2) % 5].transform.localPosition = Vector2.up * columnHeight;
                return;
            }
        }
    }
}
