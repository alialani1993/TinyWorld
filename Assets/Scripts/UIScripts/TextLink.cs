using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TextLink : MonoBehaviour
{
    [TextArea, Tooltip("Paste the link in here")]
    public string link;

    public void Link()
    {
        Application.OpenURL(link);
    }
}
