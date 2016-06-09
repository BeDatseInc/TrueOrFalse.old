using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TrueOrFalse
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            CreatePhrases.CreateOriginalPhrases();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuestionsPage());
        }

        private void TapGestureRecognizer_OnPlusButtonTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuestionCreatePage(), false);
        }
    }
}
