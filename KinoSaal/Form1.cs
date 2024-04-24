namespace KinoSaal
{
    public partial class Form1 : Form
    {
        private const int START_X = 5;
        private const int START_Y = 5;

        private const int END_X = 500;
        private const int END_Y = 500;

        private const int SEATS_X = 5;
        private const int SEATS_Y = 5;

        private const int GAB = 5;

        private bool[,] seats;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seats = new bool[SEATS_X, SEATS_Y];

            int seatWidht = ((END_X - START_X) / SEATS_X) - ((SEATS_X - 1) * GAB);
            int seatHeight = ((END_Y - START_Y) / SEATS_Y) - ((SEATS_Y - 1) * GAB);

            for(int x = 0; x < SEATS_X; x++)
            {
                for(int y = 0; y < SEATS_Y; y++)
                {
                    seats[x, y] = true;

                    Button button = new Button();
                    button.Text = (x+1).ToString() + ":" + (y+1).ToString();
                    button.Name = (x).ToString() + ":" + (y).ToString();
                    button.Location = new Point(START_X + (seatWidht * x + GAB), START_Y + (seatHeight * y + GAB));
                    button.Width = seatWidht;
                    button.Height = seatHeight;
                    button.BackColor = Color.Green;

                    button.Click += new EventHandler(ToggleSeat);

                    Controls.Add(button);
                }
            }
        }

        private void ToggleSeat(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string[] parts = button.Name.Split(":");
            int x = int.Parse(parts[0]);
            int y = int.Parse(parts[1]);

            seats[x, y] = !seats[x, y];

            if (seats[x, y])
            {
                button.BackColor = Color.Green;    
            } else
            {
                button.BackColor = Color.Red;
            }
        }
    }
}
    