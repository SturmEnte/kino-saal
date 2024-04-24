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
        private const int INFO_PERCENTAGE = 13;

        private bool[,] seats;
        private Label[] maxFreeLabels;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seats = new bool[SEATS_Y, SEATS_X];
            maxFreeLabels = new Label[SEATS_Y];

            GroupBox maxFreeGroupBox = new GroupBox();
            GroupBox seatsGroupBox = new GroupBox();

            const int WIDTH = END_X - START_X;
            const int INFO_WIDTH = WIDTH / 100 * INFO_PERCENTAGE;
            const int SEATS_WIDTH = WIDTH - INFO_WIDTH - GAB;
            const int HEIGHT = END_Y - START_Y;

            maxFreeGroupBox.Width = INFO_WIDTH;
            maxFreeGroupBox.Height = HEIGHT;
            maxFreeGroupBox.Location = new Point(START_X, START_Y);
            maxFreeGroupBox.Text = "Max.";
            
            seatsGroupBox.Width = SEATS_WIDTH;
            seatsGroupBox.Height = Height;
            seatsGroupBox.Location = new Point(START_X + INFO_WIDTH + GAB);
            seatsGroupBox.Text = "Sitze";

            int seatWidht = (SEATS_WIDTH / SEATS_X) - ((SEATS_X - 1) * GAB);
            int seatHeight = (HEIGHT / SEATS_Y) - ((SEATS_Y - 1) * GAB);

            Controls.Add(maxFreeGroupBox);
            Controls.Add(seatsGroupBox);

            for(int y = 0; y < SEATS_Y; y++)
            {

                Label label = new Label();
                label.Text = "#";
                label.Location = new Point((START_X + INFO_WIDTH) / 2 - label.Width / 2 , HEIGHT / SEATS_Y * (y + 1) - label.Height / 2);
                maxFreeGroupBox.Controls.Add(label);
                maxFreeLabels[y] = label;

                for(int x = 0; x < SEATS_X; x++)
                {
                    seats[x, y] = true;

                    Button button = new Button();
                    button.Text = (y+1).ToString() + ":" + (x+1).ToString();
                    button.Name = (y).ToString() + ":" + (x).ToString();
                    button.Location = new Point(START_X + (seatWidht * x + GAB), START_Y + (seatHeight * y + GAB));
                    button.Width = seatWidht;
                    button.Height = seatHeight;
                    button.BackColor = Color.Green;

                    button.Click += new EventHandler(ToggleSeat);

                    //Controls.Add(button);
                    seatsGroupBox.Controls.Add(button);
                }
            }
        }

        private void ToggleSeat(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string[] parts = button.Name.Split(":");
            int x = int.Parse(parts[1]);
            int y = int.Parse(parts[0]);

            seats[y, x] = !seats[y, x];

            if (seats[y, x])
            {
                button.BackColor = Color.Green;    
            } else
            {
                button.BackColor = Color.Red;
            }
        }
    }
}
    