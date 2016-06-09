using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TrueOrFalse
{
    public partial class QuestionCreatePage : ContentPage
    {
        private DataAccess data;
        private Phrases _phrase;
        public QuestionCreatePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            data = new DataAccess();
            
            //this.PhrasesListView.ItemsSource = data.GetListPhrases().Where(p => p.IsCustom == true);
            ListCustomPhrases();
            
        }

        private void ListCustomPhrases() //To list the custom phrases and set the controls
        {
            this.PhrasesListView.ItemsSource = data.GetListPhrases().Where(p => p.IsCustom == true);

            this.DeleteButton.IsVisible = false;
            this._phrase = null;
            this.PhraseEntry.Text = "";
            this.SwitchTrue.IsToggled = false;
        }

        protected void OnSaveButtonClicked(object sender, EventArgs e)
        {
            
            if (this._phrase == null)
            {
                this._phrase = new Phrases
                {
                    Phrase = this.PhraseEntry.Text,
                    IsTrue = this.SwitchTrue.IsToggled,
                    IsCustom = true
                };
                data.Insert(this._phrase);
            }
            else
            {
                this._phrase.Phrase = this.PhraseEntry.Text;
                this._phrase.IsTrue = this.SwitchTrue.IsToggled; 
                data.Update(this._phrase);
            }

            ListCustomPhrases();
        }

        private void PhrasesListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            // Old implementation - This delete the phrase from DB on tap the phrase
            //ListView list = (ListView) sender;
            //Phrases phrase = (Phrases)list.SelectedItem;
            //data.Delete(phrase);
            //ListCustomPhrases();

            // New implementation - If phrase tapped, show in the view controls and allow to change ow delete the phrase.
            ListView list = (ListView)sender;
            this._phrase = (Phrases)list.SelectedItem;
            this.PhraseEntry.Text = this._phrase.Phrase;
            this.SwitchTrue.IsToggled =this._phrase.IsTrue;
            this.DeleteButton.IsVisible = true;
            
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            data.Delete(_phrase);
            ListCustomPhrases();
        }
    }
}
