using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI vName;
    [SerializeField] private TextMeshProUGUI vInfo;
    [SerializeField] private Image vImage;

    public void ShowVillainProfileUI()
    {
        if (vName == null || vInfo == null || vImage == null) return;

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

        vName.text = VillainList.Instance.VillainDataList[0].vName;
        vImage.sprite = VillainList.Instance.VillainDataList[0].icon;
        vInfo.text = VillainList.Instance.VillainDataList[0].goal + "\n\n"
                       + VillainList.Instance.VillainDataList[0].combat + "\n\n"
                       + VillainList.Instance.VillainDataList[0].weakness + "\n\n";
    }
}
