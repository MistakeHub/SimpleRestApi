using SimpleRestAPI.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace SimpleApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
         
            InitializeComponent();
          
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[1].Name = "Title";
            dataGridView1.Columns[2].Name = "Genres";
            dataGridView1.Columns[3].Name = "Categories";
            dataGridView1.Columns[4].Name = "StartTime";
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            HttpClient httpclient = new HttpClient();
            Film? film = await httpclient.GetFromJsonAsync<Film?>($"https://localhost:7093/GetFilm/{numericUpDown1.Value}");
            if (film != null)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add(film.Id, film.Title, string.Join(",", film.Genres.Select(v => v.Title)), string.Join(",", film.Categories.Select(v => v.Title)), film.StartTime);

            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            HttpClient httpclient = new HttpClient();

            List<Film?> films = await httpclient.GetFromJsonAsync<List<Film?>>("https://localhost:7093/GetAllFilms");
            dataGridView1.Rows.Clear();
            foreach (var film in films)
            {
              
                dataGridView1.Rows.Add(film.Id, film.Title, string.Join(",", film.Genres.Select(v => v.Title)), string.Join(",", film.Categories.Select(v => v.Title)), film.StartTime);

            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            HttpClient httpclient = new HttpClient();
            var genres = new List<Genre> { new Genre() { Title = "Horror" } };
            var categories = new List<Category> { new Category() { Title = "Rated-R" } };
            var tickets = new List<Ticket> { new Ticket() { OwnerName = "Alex", PlaceNumber = 3, Price = 14.0 } };
            Film film = new Film { Genres = genres, Categories = categories, Tickets = tickets, StartTime = new DateTime(2023, 7, 23), Title = "Random Horror" };
            using var response = await httpclient.PostAsJsonAsync("https://localhost:7093/AddFilm", film);
            bool result = await response.Content.ReadFromJsonAsync<bool>();
            MessageBox.Show($"Элемент {(result? "":"не")} был добавлен");

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            HttpClient httpclient = new HttpClient();
            var genres = new List<Genre> { new Genre() { Title = "Thrillers" } };
            var categories = new List<Category> { new Category() { Title = "Rated-L" } };
            var tickets = new List<Ticket> { new Ticket() { OwnerName = "Alex", PlaceNumber = 3, Price = 14.0 } };
            Film film = new Film { Genres = genres, Categories = categories, Tickets = tickets, StartTime = new DateTime(2024, 7, 23), Title = "Random Thriller" };
            using var response = await httpclient.PutAsJsonAsync("https://localhost:7093/UpdateFilm", film);
            bool result = await response.Content.ReadFromJsonAsync<bool>();
            MessageBox.Show($"Элемент {(result ? "" : "не")} был обновлён");
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            HttpClient httpclient = new HttpClient();

            using var response = await httpclient.DeleteAsync($"https://localhost:7093/DeleteFilm/{numericUpDown1.Value}");
            bool result = await response.Content.ReadFromJsonAsync<bool>();
            MessageBox.Show($"Элемент {(result ? "" : "не")} был удалён");
        }
    }
}