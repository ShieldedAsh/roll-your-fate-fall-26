using UnityEngine;
using UnityEngine.UI;
public class ExitButton : MonoBehaviour
{
    [SerializeField]
    private Button button;

    private void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Application.Quit();
    }
}
