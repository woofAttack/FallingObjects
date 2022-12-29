using System;

public class HealthPresenter
{
    private HealthView _view;
    private Health _model;

    public HealthPresenter(Health model, HealthView view)
    {
        _model = model ?? throw new ArgumentNullException(nameof(model));
        _view = view ?? throw new ArgumentNullException(nameof(view));
    }

    public void Enable()
    {
        _model.OnChange += _view.SetCurrentValue;
        _model.OnReduce += _view.BrakeHeartByOne;
    }

    public void Disable()
    {
        _model.OnChange -= _view.SetCurrentValue;
        _model.OnReduce -= _view.BrakeHeartByOne;
    }
}