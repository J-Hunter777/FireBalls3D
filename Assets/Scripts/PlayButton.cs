using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Button))]

    public class PlayButton : MonoBehaviour 
	{ public void Start()
		{
			Button button = GetComponent<Button>();
			button.onClick.AddListener(OnButtonClicked);
		}

        private void OnButtonClicked() =>
			Debug.Log("Play Button was clicked");

    }
}
