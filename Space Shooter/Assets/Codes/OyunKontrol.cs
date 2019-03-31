using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour {
    public GameObject Asteroid;
    public GameObject sahne;
    public float baslangicbekleme, olusturmabekleme, dongubekleme;
    int score;
    public Text score_yazi,oyun_bitti,yeniden_basla;
    bool oyunbittimi = false, yenidenbaslasinmi = false;
    void Start () {
        score = 0;
        score_yazi.text = "Score: " + score;
        StartCoroutine(olustur());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && yenidenbaslasinmi)
        {
            SceneManager.LoadScene("Level1");
        }
    }

    IEnumerator olustur()
    {
        yield return new WaitForSeconds(baslangicbekleme);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(Asteroid, new Vector3(Random.Range(-sahne.transform.localScale.x / 2 + 1, sahne.transform.localScale.x / 2 - 1), 0, sahne.transform.localScale.y / 2), Quaternion.identity);
                yield return new WaitForSeconds(olusturmabekleme);

            }
            if (oyunbittimi)
            {
                yeniden_basla.text = "Press R for Restart";
                yenidenbaslasinmi = true;
                break;
            }
            yield return new WaitForSeconds(dongubekleme);
        }

    }
    public void ScoreArttir(int gelenScore)
    {
        score += gelenScore;
        score_yazi.text = "Score: " + score;
    }
    public void OyunBitti()
    {
        oyunbittimi = true;
        oyun_bitti.text = "Game Over";
    }

}
