using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {
    [SerializeField] private Transform scoreParent;
    [SerializeField] private Transform scoreTemplateImage;
    [SerializeField] private List<NumberSO> numberSOList;

    public void SpawnScore(int score)
    {
        DestroyPreviousScore();
        string scoreString = score.ToString();
        char[] charScoreList = scoreString.ToCharArray();
        foreach (char charScore in charScoreList)
        {
            foreach (NumberSO numberSO in numberSOList)
            {
                if (charScore == numberSO.score)
                {
                    SpawnScoreUnit(numberSO.sprite);
                    break;
                }
            }
        }
    }

    public void DestroyPreviousScore()
    {
        foreach (Transform child in scoreParent)
        {
            if (child != scoreTemplateImage)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void SpawnScoreUnit(Sprite scoreSprite)
    {
        Transform scoreUnitTransform = Instantiate(scoreTemplateImage, scoreParent);
        scoreUnitTransform.GetComponent<Image>().sprite = scoreSprite;
        scoreUnitTransform.gameObject.SetActive(true);
    }

    public void HideScoreTemplate()
    {
        scoreTemplateImage.gameObject.SetActive(false);
    }
}
