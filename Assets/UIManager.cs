using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private TMP_InputField _inputField1;
    [SerializeField] private TMP_InputField _inputField2;
    [SerializeField] private TMP_InputField _inputField3;

    private void OnEnable()
    {
        _inputField1.onSubmit.AddListener(_gameManager.SetSpeed);
        _inputField2.onSubmit.AddListener(_gameManager.SetDistance);
        _inputField3.onSubmit.AddListener(_gameManager.SetFrequency);
    }

    private void OnDisable()
    {
        _inputField1.onSubmit?.RemoveListener(_gameManager.SetSpeed);
        _inputField2.onSubmit?.RemoveListener(_gameManager.SetDistance);
        _inputField3.onSubmit?.RemoveListener(_gameManager.SetFrequency);
    }
}
