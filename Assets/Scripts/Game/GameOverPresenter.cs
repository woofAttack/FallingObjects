using System;

public class GameOverPresenter
{
    private Game _game;
    private GameOverView _view;

    public GameOverPresenter(Game game, GameOverView view)
    {
        _game = game ?? throw new System.ArgumentNullException(nameof(game));
        _view = view ?? throw new System.ArgumentNullException(nameof(view));
    }

    public void Enable()
    {
        _game.OnEnd += _view.HideOtherUI;
        _game.OnEnd += _view.Show;
    }

    public void Disable()
    {
        _game.OnEnd -= _view.HideOtherUI;
        _game.OnEnd -= _view.Show;
    }
}