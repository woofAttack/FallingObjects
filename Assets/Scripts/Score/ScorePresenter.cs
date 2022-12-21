using System;
using UnityEngine;

public class ScorePresenter
{
    private IScoreView _view;
    private Score _model;

    public ScorePresenter(Score model, IScoreView view)
    {
        _model = model ?? throw new ArgumentNullException(nameof(model));
        _view = view ?? throw new ArgumentNullException(nameof(view));
    }

    public void Enable()
    {
        _model.OnChange += _view.SetScoreText;
    }

    public void Disable()
    {
        _model.OnChange -= _view.SetScoreText;
    }
}
