using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;

namespace ProjectStudio;

public partial class MainWindow : Window
{
    private const string FullName = "Гайсина Арина Аделевна";

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Login_Click(object? sender, RoutedEventArgs e)
    {
        if (LoginBox.Text == "admin" && PasswordInput.Text == "123")
        {
            ErrorText.Text = "";
            ProfileButton.Content = FullName;
            ProfileName.Text = FullName;
            LoginPanel.IsVisible = false;
            MainPanel.IsVisible = true;
            Open(OverviewPage, OverviewButton);
        }
        else
        {
            ErrorText.Text = "Неверный логин или пароль";
        }
    }

    private void Logout_Click(object? sender, RoutedEventArgs e)
    {
        LoginBox.Text = "";
        PasswordInput.Text = "";
        MainPanel.IsVisible = false;
        LoginPanel.IsVisible = true;
    }

    private void Open(Control page, Button button)
    {
        OverviewPage.IsVisible = false;
        ProjectsPage.IsVisible = false;
        TasksPage.IsVisible = false;
        CalendarPage.IsVisible = false;
        TeamPage.IsVisible = false;
        SettingsPage.IsVisible = false;
        ProfilePage.IsVisible = false;

        OverviewButton.Background = Brushes.Transparent;
        ProjectsButton.Background = Brushes.Transparent;
        TasksButton.Background = Brushes.Transparent;
        CalendarButton.Background = Brushes.Transparent;
        TeamButton.Background = Brushes.Transparent;
        SettingsButton.Background = Brushes.Transparent;
        ProfileButton.Background = Brushes.Transparent;

        page.IsVisible = true;
        button.Background = new SolidColorBrush(Color.Parse("#406A55E6"));
    }

    private void Overview_Click(object? sender, RoutedEventArgs e) => Open(OverviewPage, OverviewButton);
    private void Projects_Click(object? sender, RoutedEventArgs e) => Open(ProjectsPage, ProjectsButton);
    private void Tasks_Click(object? sender, RoutedEventArgs e) => Open(TasksPage, TasksButton);
    private void Calendar_Click(object? sender, RoutedEventArgs e) => Open(CalendarPage, CalendarButton);
    private void Team_Click(object? sender, RoutedEventArgs e) => Open(TeamPage, TeamButton);
    private void Settings_Click(object? sender, RoutedEventArgs e) => Open(SettingsPage, SettingsButton);
    private void Profile_Click(object? sender, RoutedEventArgs e) => Open(ProfilePage, ProfileButton);

    private void Theme_Click(object? sender, RoutedEventArgs e)
    {
        if (ThemeSwitch.IsChecked == true)
            Application.Current!.RequestedThemeVariant = ThemeVariant.Dark;
        else
            Application.Current!.RequestedThemeVariant = ThemeVariant.Light;
    }

    private void AddTask_Click(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NewTaskBox.Text))
            return;

        TasksList.Children.Add(new CheckBox { Content = NewTaskBox.Text });
        NewTaskBox.Text = "";
    }
}