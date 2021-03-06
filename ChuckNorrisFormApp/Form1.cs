
using ChuckNorrisAPI;

namespace ChuckNorrisFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }       

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            // label is blank until the button is clicked.
            jokeText.Text = "";

            // add categories to category combo box
            IEnumerable<string> categories = await ChuckNorrisClient.GetCategories();
            foreach (var category in categories)
            {
                categoryComboBox.Items.Add(category);
            }
        }

        // new joke text is generated upon button click
        private async void button1_Click(object sender, EventArgs e)
        {
            Joke j = await ChuckNorrisClient.GetRandomJoke();
            jokeText.Text = j.JokeText;
        }
    }
}