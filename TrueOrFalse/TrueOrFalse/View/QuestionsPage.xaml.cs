using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TrueOrFalse
{
    public partial class QuestionsPage : ContentPage
    {
        private int num = 0;
        private int index = 0;
        private int right = 0;
        private bool isTrue;
        private DataAccess data;
        private List<Phrases> list;
        private Random random;
        public QuestionsPage()
        {

            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            data = new DataAccess();
            num = data.Count();
            list = data.GetListPhrases(num);

            random = new Random();
            LoadPhrase();
        }

        void LoadPhrase()
        {

            int i = random.Next(list.Count);
            if (index < num)
            {
                QuestionLabel.Text = list[i].Phrase;
                isTrue = list[i].IsTrue;
                list.RemoveAt(i);
                //index++;
            }

        }
        private async void Button_OnClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "True" && isTrue == true) // Todo - Tentar simplificar depois
            {
                await DisplayAlert(AppResources.Strings.Tittle, "Very good, right answer", AppResources.Strings.Okay);
                right++;
            }
            else if (button.Text == "False" && isTrue == false)
            {
                await DisplayAlert(AppResources.Strings.Tittle, "Very good, right answer", AppResources.Strings.Okay);
                right++;
            }
            else
            {
                await DisplayAlert(AppResources.Strings.Tittle, "So bad, wrong answer", AppResources.Strings.Okay);
            }
            index++;
            if (index >= num)
            {
                await DisplayAlert(AppResources.Strings.Tittle, String.Format("You got {0} question{1}", right, right > 1 ? "s" : ""), AppResources.Strings.Okay);

                await Navigation.PopAsync();
            }
            else
            {
                LoadPhrase();
            }

        }

        private void QuestionsPage_OnSizeChanged(object sender, EventArgs e)
        {
            TrueButton.HeightRequest = FalseButton.HeightRequest = Height / 2;
            TrueButton.WidthRequest = FalseButton.WidthRequest = (Width - (Padding.Left + Padding.Right)) / 2;

        }

    }
}
