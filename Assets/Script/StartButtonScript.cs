using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
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
        //im so level scene
    }
}

