using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueOrFalse
{
    static class CreatePhrases
    {

        static List<Phrases> originalPhrases = new List<Phrases>
        {
            new Phrases
            {
                Phrase = "Risotto is a common Italian rice dish.",
                IsTrue = true,
                IsCustom = false
            },
            new Phrases
            {
                Phrase = "Godfather: Part II (1974) was the only film sequel to win an Academy Award for best picture.",
                IsTrue = false,
                IsCustom = false
            },
            new Phrases
            {
                Phrase = "The thigh bone (femur) is the largest bone in the human body.",
                IsTrue = true,
                IsCustom = false
            },
            new Phrases
            {
                Phrase = "The prefix \"mega-\" represents one million.",
                IsTrue = true,
                IsCustom = false
            },
            new Phrases
            {
                Phrase = "\"Cost\" is one of the \"4 C's\" of diamond grading.",
                IsTrue = false,
                IsCustom = false
            },
            new Phrases
            {
                Phrase = "In Shakespeare's play, Hamlet commits suicide.",
                IsTrue = false,
                IsCustom = false
            },
            new Phrases
            {
                Phrase = "The mint julep is the signature drink of the Kentucky Derby of horseracing.",
                IsTrue = true,
                IsCustom = false
            },
            new Phrases
            {
                Phrase = "Hurricanes and typhoons are the same thing.",
                IsTrue = true,
                IsCustom = false
            },
            new Phrases
            {
                Phrase = "An American was the first man in space.",
                IsTrue = false,
                IsCustom = false
            },
            new Phrases
            {
                Phrase = "The \"Forbidden City\" is in Beijing.",
                IsTrue = true,
                IsCustom = false
            }
        };

        public static void CreateOriginalPhrases()
        {
            DataAccess data = new DataAccess();

            if (data.GetListPhrases().Count == 0)
            {
                foreach (var phrase in originalPhrases)
                {
                    data.Insert(phrase);
                }
            }
            
        }
    }
}
