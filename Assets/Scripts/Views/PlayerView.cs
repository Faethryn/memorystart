using Memory.Views;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;

public class PlayerView : ViewBaseClass<Player>
{
    [SerializeField]
    private TextMeshProUGUI _playerNameText;
    [SerializeField]
    private TextMeshProUGUI _playerScore;
    [SerializeField]
    private TextMeshProUGUI _playerIsActive;

    [SerializeField]
    private TextMeshProUGUI _playerElapsedTime;


  

    protected override void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals(nameof(Model.Name)))
        {
            _playerNameText.text = Model.Name;
        }
        if (e.PropertyName.Equals(nameof(Model.Score)))
        {
            _playerScore.text = Model.Score.ToString();
        }
        if (e.PropertyName.Equals(nameof(Model.IsActive)))
        {
            
            _playerIsActive.text = Model.IsActive.ToString();
        }
        if (e.PropertyName.Equals(nameof(Model.Elapsed)))
        {
            _playerElapsedTime.text = Model.Elapsed.ToString();
        }
    }

    private void Update()
    {
        if (Model.IsActive)
        {
            Model.Elapsed += Time.deltaTime;
        }
    }

}
