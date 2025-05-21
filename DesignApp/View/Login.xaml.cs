using DesignApp.Model;
using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DesignApp.View;

public partial class Login : ContentPage, INotifyPropertyChanged
{
    private bool _showPassword;
    public bool ShowPassword
    {
        get => _showPassword;
        set
        {
            if (_showPassword != value)
            {
                _showPassword = value;
                OnPropertyChanged(nameof(ShowPassword));
            }
        }
    }
    public bool FirstNameNull { get => _firstNameNull; set { _firstNameNull = value; OnPropertyChanged(nameof(FirstNameNull)); } }
    public bool LastNameNull { get => _lastNameNull; set { _lastNameNull = value; OnPropertyChanged(nameof(LastNameNull)); } }
    public bool UserNameNull { get => _userNameNull; set { _userNameNull = value; OnPropertyChanged(nameof(UserNameNull)); } }
    public bool EmailNull { get => _emailNull; set { _emailNull = value; OnPropertyChanged(nameof(EmailNull)); } }
    public bool Mismatch { get => _mismatch; set { _mismatch = value; OnPropertyChanged(nameof(Mismatch)); } }
    private bool _dobNull, _passNull, _passConfirmNull;
    public bool DobNull { get => _dobNull; set { _dobNull = value; OnPropertyChanged(nameof(DobNull)); } }
    public bool PassNull { get => _passNull; set { _passNull = value; OnPropertyChanged(nameof(PassNull)); } }
    public bool PassConfirmNull { get => _passConfirmNull; set { _passConfirmNull = value; OnPropertyChanged(nameof(PassConfirmNull)); } }

    private bool _firstNameNull;
    private bool _mismatch;
    private bool _lastNameNull;
    private bool _userNameNull;
    private bool _emailNull;
    public bool SignUpLayout { get; private set; }
    public bool LoginLayout { get; private set; }
    public bool pageOneValid { get; private set; }
    public bool pageTwoValid { get; private set; }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    public Login()
    {

        InitializeComponent();
        if (Preferences.Get("isSignedUp", false))
        {
            SignUpLayout = false;
            LoginLayout = true;
        }
        else
        {
            SignUpLayout = true;
            LoginLayout = false;
        }
        Pages = new List<LoginModel>
        {
            new LoginModel { PageOne = true, PageTwo = false, PageThree = false },
            new LoginModel { PageOne = false, PageTwo = true, PageThree = false , DateOfBirth = DateTime.Now.Date},
            new LoginModel { PageOne = false, PageTwo = false, PageThree = true }
        };
        ShowPassword = true;
        FormSlider.PositionChanged += FormSlider_PositionChanged;

        UpdateButtons(FormSlider.Position);
        this.BindingContext = this;
    }

    private void UpdateButtons(int position)
    {
        int lastIndex = Pages?.Count - 1 ?? 0;

        // Hide Back button on first page
        BackButton.IsVisible = position != 0;

        // Change Next button text to Submit on last page
        if (position == lastIndex)
        {
            NextButton.Text = "Submit";
            NextButton.IsEnabled = false;
            NextButton.BackgroundColor = (Color)Application.Current.Resources["Gray100"];
            NextButton.TextColor = (Color)Application.Current.Resources["Gray300"];
        }
        else
        {
            NextButton.Text = "Next";
            NextButton.IsEnabled = true;
            NextButton.BackgroundColor = (Color)Application.Current.Resources["Primary"];
            NextButton.TextColor = (Color)Application.Current.Resources["White"];
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        DummyEntry.Focus();
        int currentIndex = FormSlider.Position;
        if (currentIndex > 0)
        {
            FormSlider.Position = currentIndex - 1;
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        int currentIndex = FormSlider.Position;
        int lastIndex = Pages?.Count - 1 ?? 0;
        if (!HasEmptyRequiredFields(Pages, currentIndex))
        {
            if (currentIndex < lastIndex)
            {
                FormSlider.Position = currentIndex + 1;
            }
            else
            {
                Application.Current.MainPage = new AppShell();
            }
        }
    }

    private bool HasEmptyRequiredFields(IEnumerable<LoginModel> pages, int no)
    {

        foreach (var page in pages)
        {
            if (page.PageOne && no == 0)
            {
                var firstName = (page.FirstName ?? "").Trim();
                var lastName = (page.LastName ?? "").Trim();
                var userName = (page.UserName ?? "").Trim();
                var email = (page.Email ?? "").Trim();

                Preferences.Set("FirstName", firstName);
                Preferences.Set("LastName", lastName);
                Preferences.Set("UserName", userName);
                Preferences.Set("Email", email);

                FirstNameNull = string.IsNullOrWhiteSpace(firstName);
                LastNameNull = string.IsNullOrWhiteSpace(lastName);
                UserNameNull = string.IsNullOrWhiteSpace(userName);
                EmailNull = string.IsNullOrWhiteSpace(email);

                if (FirstNameNull || LastNameNull || UserNameNull || EmailNull)
                    return true;

                pageOneValid = true;
            }

            if (page.PageTwo && no == 1)
            {
                var dob = page.DateOfBirth.Date.ToString("yyyy-MM-dd");
                var passcode = (page.Passcode ?? "").Trim();
                var passcodeConfirm = (page.Passcodeconfirm ?? "").Trim();

                Preferences.Set("DateOfBirth", dob);
                Preferences.Set("Passcode", passcode);
                Preferences.Set("PasscodeConfirm", passcodeConfirm);

                DobNull = page.DateOfBirth.Date == DateTime.Now.Date;
                PassNull = string.IsNullOrWhiteSpace(passcode);
                PassConfirmNull = string.IsNullOrWhiteSpace(passcodeConfirm);
                if (passcode != passcodeConfirm)
                {
                    Mismatch = true;
                    return true;
                }
                if (DobNull || PassNull || PassConfirmNull)
                    return true;

                pageTwoValid = true;
            }
        }

        // If both pages were valid (usually after final page submit), set isLoggedIn
        if (pageOneValid && pageTwoValid)
        {
            Preferences.Set("isSignedUp", true);
        }

        return false;
    }


    private void FormSlider_PositionChanged(object sender, PositionChangedEventArgs e)
    {
        UpdateButtons(e.CurrentPosition);
    }

    private async void PassCode_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (entry != null && entry.Text.Length == 4)
        {
            string enteredPasscode = entry.Text.Trim();
            string savedPasscode = Preferences.Get("Passcode", string.Empty);

            if (enteredPasscode == savedPasscode)
            {
                PasscodeSuccessLable.IsVisible = true;
                await Task.Delay(1000);
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                // Passcode mismatch - show error
                PasscodeErrorLabel.IsVisible = true;
                PasscodeErrorLabel.Text = "* Incorrect Passcode";
            }
        }
        else
        {
            // Hide error when text is less than 4 digits
            PasscodeErrorLabel.IsVisible = false;
        }
    }

    private void AgreementCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (FormSlider.Position == Pages.Count - 1)
        {
            if (e.Value) // checked
            {
                NextButton.IsEnabled = true;
                NextButton.BackgroundColor = (Color)Application.Current.Resources["Primary"];
                NextButton.TextColor = (Color)Application.Current.Resources["White"];
            }
            else // unchecked
            {
                NextButton.IsEnabled = false;
                NextButton.BackgroundColor = (Color)Application.Current.Resources["Gray100"];
                NextButton.TextColor = (Color)Application.Current.Resources["Gray300"];
            }
        }
    }

    private void PasswordChk_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        ShowPassword = !e.Value;
    }
}