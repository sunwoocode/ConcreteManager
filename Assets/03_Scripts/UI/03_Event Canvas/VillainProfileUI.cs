using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VillainProfileUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI content;
    [SerializeField] private Image image;

    public void ShowVillainProfileUI()
    {
        if (content == null || image == null) return;

        if (UIManager.Instance.isVillainIconClicked == false)
        {
            this.gameObject.SetActive(true);
            UIManager.Instance.isVillainIconClicked = true;
        }
        else
        {
            this.gameObject.SetActive(false);
            UIManager.Instance.isVillainIconClicked = false;
        }

        content.text = VillainList.Instance.VillainDataList[0].VillainName
                       + "\n\n\n\n\n\n\n\n\n"
                       + VillainList.Instance.VillainDataList[0].attackType + "\n"
                       + VillainList.Instance.VillainDataList[0].str + "\n"
                       + VillainList.Instance.VillainDataList[0].itg + "\n"
                       + VillainList.Instance.VillainDataList[0].sight + "\n";
        image.sprite = VillainList.Instance.VillainDataList[0].icon;
    }
}
