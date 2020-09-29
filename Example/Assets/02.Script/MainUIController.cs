using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
    public bool isMain;
    private void Start()
    {
        if (isMain)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickBack();
        }
    }
    public void OnClickTank()
    {
        SceneManager.LoadScene("3DTank");
    }
    public void OnClickFPS()
    {
        SceneManager.LoadScene("3DFPS");
    }
    public void OnClickTPS()
    {
        SceneManager.LoadScene("3DTPS");
    }
    public void OnClickZombie()
    {
        SceneManager.LoadScene("3DZombie");
    }
    public void OnClickFluppyBird()
    {
        SceneManager.LoadScene("2DFluppyBird");
    }
    public void OnClickShooting()
    {
        SceneManager.LoadScene("2DShooting");
    }
    public void OnClickBack()
    {
        if (isMain)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
