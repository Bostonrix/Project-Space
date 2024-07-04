using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicManager : MonoBehaviour
{
    public GameObject PostImage;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("changeComic", 5);
        Invoke("scnChng", 10);
    }

    void changeComic() {
        PostImage.SetActive(true);
    }

    void scnChng() {
        // float timer = 0f;
        // while (timer < 5) {
        //     timer += 1 * Time.deltaTime;
        // }
        SceneManager.LoadScene("SampleScene");
    }
}
