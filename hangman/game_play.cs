using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    class game_play
    {
        int score, level, high_score, w, wp1, wp2, solved;
        String word;
        Boolean conTnue;

        public game_play()
        {

        }

        private String set_word(int i)
        {
            Random rnd = new Random();
            wp2 = wp1;
            wp1 = w;
            
            Boolean goOn;
            do{

                w = rnd.Next(10);
                goOn = (w == wp1 || w == wp2) ? true : false;
            }while(goOn);

            return parse_word(w);
            
        }

        private string parse_word(int w)
        {
            throw new NotImplementedException();
        }


        private void new_config()
        {
            Windows.Storage.ApplicationDataContainer settins = Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localfolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            settins.Values["level"] = level;
            settins.Values["score"] = 0;
            settins.Values["high_score"] = 0;
            settins.Values["conTnue"] = true;
            settins.Values["solved"] = 0;
            settins.Values["word"] = set_word(1);
        }
    }
}
