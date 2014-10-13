using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text;
using System.Windows.Media;

namespace hangman
{
    public partial class game : PhoneApplicationPage
    {
        int []alpha;
        int wr_moves, rt_moves;
        String d_hang;
        private StringBuilder sb;
        game_play gp;
        //var gp;

        public game()
        {
            InitializeComponent();
            alpha = new int[26];
            d_hang = "hangman";
            hidden_text.Text = "-------";
            sb = new StringBuilder(hidden_text.Text);
            rt_moves = 0;
            wr_moves = 0;
            //gp = PhoneApplicationService.Current.State["gplay"];
        }

        private void on_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var obj = sender as Button;
            char ch = 'a';
            bool right = false;

            if (obj != null)
                ch = obj.Content.ToString()[0];

            for (int i = 0; i < d_hang.Length; i++)
                if (ch == d_hang[i])
                {
                    is_right(ch, sender);
                    right = true;
                }

            if (!right)
                is_wrong(sender);

        }

        private void is_wrong(object sender)
        {
            Button obj = sender as Button;
            obj.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 63, 32));
            wr_moves++;
            if (wr_moves > 3)
            {
                //display_hang(wr_moves);
                sb = new StringBuilder(d_hang);
                hidden_text.Text = sb.ToString();
                loose_pop.IsOpen = true;
            }

            //else
                //display_hang(wr_moves);
        }

        private void is_right(char p, object sender)
        {
            Button obj = sender as Button;
            obj.Foreground = new SolidColorBrush(Color.FromArgb(255, 113, 255, 82));
            for (int i = 0; i < d_hang.Length; i++)
                if (d_hang[i] == p && hidden_text.Text[i] == '-')
                {
                    rt_moves++;
                    display_hidden(i, p);
                }
            if (rt_moves == d_hang.Length)
                win_pop.IsOpen = true;
        }

        private void display_hidden(int i, char p)
        {
            sb = new StringBuilder(hidden_text.Text);
            sb[i] = p;
            hidden_text.Text = sb.ToString();
        }

        private void display_hang(int wr_moves)
        {
            throw new NotImplementedException();
        }

        private void next(object sender, System.Windows.Input.GestureEventArgs e)
        {

            NavigationService.Navigate(new Uri("/game.xaml?Refresh=true", UriKind.Relative));
            win_pop.IsOpen = false;
        }

        private void restart(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //gp.score = 0;
            //gp.word = "hellboy";

            NavigationService.Navigate(new Uri("/game.xaml?Refresh=true", UriKind.Relative));
            loose_pop.IsOpen = false;
        }




    }
}