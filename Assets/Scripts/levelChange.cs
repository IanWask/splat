using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class save : MonoBehaviour
{

    public float pX;
    public float pY;
    public float pZ;

    // Use this for initialization
    void Start()
    {
        // Check if the values have been saved
        if (PlayerPrefs.GetInt("Saved") == 1)
        {
            pX = PlayerPrefs.GetFloat("p_x");
            pY = PlayerPrefs.GetFloat("p_y");
            pZ = PlayerPrefs.GetFloat("p_z");

            transform.position = new Vector3(pX, pY, pZ);

            // Reset, so that the save will be used only once
            PlayerPrefs.SetInt("Saved", 0);
            PlayerPrefs.Save();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            position_save();
            Debug.Log("Save");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            position_load();
            Debug.Log("Load");
        }

    }
    void position_save()
    {
        PlayerPrefs.SetFloat("p_x", transform.position.x);
        PlayerPrefs.SetFloat("p_y", transform.position.y);
        PlayerPrefs.SetFloat("p_z", transform.position.z);

        PlayerPrefs.SetInt("Saved", 1);
        // You need to actually save the values!
        PlayerPrefs.Save();
    }
    void position_load()
    {
        print("Switching Scene to " + sceneBuildIndex);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}