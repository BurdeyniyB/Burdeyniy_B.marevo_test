using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private string SceneName;
        private Button PlayButton;

        void Start()
        {
            PlayButton = GetComponent<Button>();
            PlayButton.onClick.AddListener (Task);
        }

        public void Task()
        {
            SceneManager.LoadScene(SceneName);
        }

    }
