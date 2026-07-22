using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;
using System.Windows.Input;

namespace Yugen.MotoGP.App.Behaviors;

public sealed class NavigationViewSelectionChangedBehavior : Behavior<NavigationView>
{
    #region DependencyProperties

    public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
        nameof(Command),
        typeof(ICommand),
        typeof(NavigationViewSelectionChangedBehavior),
        new PropertyMetadata(default(ICommand)));

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    #endregion DependencyProperties

    protected override void OnAttached()
    {
        base.OnAttached();

        if (AssociatedObject != null)
        {
            AssociatedObject.SelectionChanged += HandleSelectionChanged;
        }
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();

        if (AssociatedObject != null)
        {
            AssociatedObject.SelectionChanged -= HandleSelectionChanged;
        }
    }

    private void HandleSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        var selectedItem = args.SelectedItem;

        if (Command is not ICommand command ||
            !command.CanExecute(selectedItem))
        {
            return;
        }

        command.Execute(selectedItem);
    }
}