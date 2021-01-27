using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenerateCards : MonoBehaviour
{
    public GameObject card, canvas;
    public Text score;
    public int rows = 2;
    public int cols = 4;
    public float rowsOffset = 4f;
    public float colsOffset = 3.33f;
    float genCardx, genCardy;
    public Sprite front1, front2, front3, front4;
    int checkFront1 = 0, checkFront2 = 0, checkFront3 = 0, checkFront4 = 0, ok = 0, r, scoreVal = 0;
    [HideInInspector] public Hide card1, card2;
    // Start is called before the first frame update
    void Start()
    {
        genCardx = card.transform.position.x;
        genCardy = card.transform.position.y;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject genCard = card as GameObject;
                if (!(i == 0 && j == 0))
                {
                    genCardx = genCardx + colsOffset;
                    genCard = Instantiate(card, new Vector3(genCardx, genCardy, 0), Quaternion.identity, canvas.transform) as GameObject;
                }
                r = Random.Range(1, 5);
                ok = 0;
                while (ok == 0)
                {
                    if (r == 1)
                    {
                        if (checkFront1 < 2)
                        {
                            genCard.GetComponentInChildren<Image>().sprite = front1;
                            checkFront1 += 1;
                            ok = 1;
                        }
                        else
                        {
                            r = Random.Range(2, 5);
                        }
                    }
                    if (r == 2)
                    {
                        if (checkFront2 < 2)
                        {
                            genCard.GetComponentInChildren<Image>().sprite = front2;
                            checkFront2 += 1;
                            ok = 1;
                        }
                        else
                        {
                            do
                            {
                                r = Random.Range(1, 5);
                            } while (r == 2);
                        }
                    }
                    if (r == 3)
                    {
                        if (checkFront3 < 2)
                        {
                            genCard.GetComponentInChildren<Image>().sprite = front3;
                            checkFront3 += 1;
                            ok = 1;
                        }
                        else
                        {
                            do
                            {
                                r = Random.Range(1, 5);
                            } while (r == 3);
                        }
                    }
                    if (r == 4)
                    {
                        if (checkFront4 < 2)
                        {
                            genCard.GetComponentInChildren<Image>().sprite = front4;
                            checkFront4 += 1;
                            ok = 1;
                        }
                        else
                        {
                            r = Random.Range(1, 4);
                        }
                    }
                }
            }
            genCardx = card.transform.position.x - colsOffset;
            genCardy = genCardy - rowsOffset;
        }
        score.GetComponent<Text>().text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FindMatch(Hide card)
    {
        if(card1 == null)
        {
            card1 = card;
        }
        else
        {
            card2 = card;
            StartCoroutine(HideCards());
        }
    }

    private IEnumerator HideCards()
    {
        if (card1.GetComponentInChildren<Image>().sprite == card2.GetComponentInChildren<Image>().sprite)
        {
            Debug.Log("Match");
            scoreVal += 100;
            score.GetComponent<Text>().text = "Score:" + scoreVal;
        }
        else
        {
            Debug.Log("No match");
            if (scoreVal > 0)
            {
                scoreVal -= 10;
                score.GetComponent<Text>().text = "Score:" + scoreVal;
            }
            yield return new WaitForSeconds(1.0f);
            card1.back.SetActive(true);
            card2.back.SetActive(true);
        }
        card1 = null;
        card2 = null;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
