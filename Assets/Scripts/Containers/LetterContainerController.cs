using UnityEngine;
using UnityEngine.UI;
using TMPro;

//This class to control the letter container in each set of letters
public class LetterContainerController : MonoBehaviour
{
    [SerializeField] Image containerImage;
    [SerializeField] TextMeshProUGUI containerText;

    public void SetContainerColor(Color color) => containerImage.color = color;
    public void SetContainerText(string letter) => containerText.text = letter;
    public void ClearContainer()
    {
        SetContainerColor(ColorDataStore.GetWrongLetterColor());
        containerText.text = "";
    }
}
