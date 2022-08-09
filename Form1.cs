namespace PlayTagWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            playField = new PlayTag.RandomField();
            InitializeButtons();  
            setClickForButtons();
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.R)
            {
                removeClickForButtons();
                playField.Reset();                                
                setClickForButtons();
                DisplayField();
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            removeClickForButtons();
            playField.Reset();
            setClickForButtons();
            DisplayField();            
        }
        private void ClickButton1(object sender, EventArgs e)
        {
            removeClickForButtons();            
            this.playField.swapNumberByJ(playField.indexJ0 - 1);
            this.buttons[playField.indexI0, playField.indexJ0].Text = "";
            this.buttons[playField.indexI0, playField.indexJ0 + 1].Text = 
                this.playField.getNumber(playField.indexI0,playField.indexJ0 + 1).ToString();            
            setClickForButtons();
            Check();
        }
        private void ClickButton2(object sender, EventArgs e)
        {
            removeClickForButtons();
            this.playField.swapNumberByI(playField.indexI0 + 1);
            this.buttons[playField.indexI0, playField.indexJ0].Text = "";
            this.buttons[playField.indexI0 - 1, playField.indexJ0].Text =
                this.playField.getNumber(playField.indexI0 - 1, playField.indexJ0).ToString();
            setClickForButtons();
            Check();
        }
        private void ClickButton3(object sender, EventArgs e)
        {
            removeClickForButtons();
            this.playField.swapNumberByJ(playField.indexJ0 + 1);
            this.buttons[playField.indexI0, playField.indexJ0].Text = "";
            this.buttons[playField.indexI0, playField.indexJ0 - 1].Text =
                this.playField.getNumber(playField.indexI0, playField.indexJ0 - 1).ToString();
            setClickForButtons();
            Check();
        }
        private void ClickButton4(object sender, EventArgs e)
        {
            removeClickForButtons();
            this.playField.swapNumberByI(playField.indexI0 - 1);
            this.buttons[playField.indexI0, playField.indexJ0].Text = "";
            this.buttons[playField.indexI0 + 1, playField.indexJ0].Text =
                this.playField.getNumber(playField.indexI0 + 1, playField.indexJ0 ).ToString();
            setClickForButtons();
            Check();
        }
        #endregion

        #region Functions        
        private void Check()
        {
            if(playField.checkedField1() || playField.checkedField2())
                MessageBox.Show("You Win!");
        }
        private void setClickForButtons()
        {
            if (playField.indexI0 + 1 < 4)
                buttons[playField.indexI0 + 1, playField.indexJ0].Click += ClickButton2;
            if(playField.indexI0 - 1 > -1)
                buttons[playField.indexI0 - 1, playField.indexJ0].Click += ClickButton4;
            if (playField.indexJ0 + 1 < 4)
                buttons[playField.indexI0, playField.indexJ0 + 1].Click += ClickButton3;
            if (playField.indexJ0 - 1 > -1)
                buttons[playField.indexI0, playField.indexJ0 - 1].Click += ClickButton1;
        }

        private void removeClickForButtons()
        {
            if (playField.indexI0 + 1 < 4)
                buttons[playField.indexI0 + 1, playField.indexJ0].Click -= ClickButton2;
            if (playField.indexI0 - 1 > -1)
                buttons[playField.indexI0 - 1, playField.indexJ0].Click -= ClickButton4;
            if (playField.indexJ0 + 1 < 4)
                buttons[playField.indexI0, playField.indexJ0 + 1].Click -= ClickButton3;
            if (playField.indexJ0 - 1 > -1)
                buttons[playField.indexI0, playField.indexJ0 - 1].Click -= ClickButton1;
        }

        private void DisplayField()
        {
            this.tableLayoutPanel1.SuspendLayout();

            for (int i = 0; i < rang; i++)
                for (int j = 0; j < rang; j++)
                {
                    this.buttons[i, j].Text = this.playField.getNumber(i, j).ToString();
                }
            this.buttons[playField.indexI0, playField.indexJ0].Text = "";
            this.tableLayoutPanel1.ResumeLayout();
        }

        private void InitializeButtons()
        {
            this.buttons = new Button[rang,rang];            
            for(int i = 0; i < rang; i++)            
                for(int j = 0; j < rang; j++)
                { 
                    this.buttons[i,j] = new Button();                
                    this.buttons[i,j].Name = $"btn{i + 4 * j}";
                    this.buttons[i,j].Text = this.playField.getNumber(i,j).ToString(); //$"{i + 4 * j}"
                    this.buttons[i,j].Font = new Font(this.buttons[i,j].Font.Name, 16);
                    this.buttons[i,j].Dock = DockStyle.Fill;
                    this.buttons[i,j].Margin = new Padding(0);
                    this.buttons[i,j].Padding = new Padding(0);
                    this.buttons[i,j].FlatAppearance.BorderSize = 0;
                    this.buttons[i,j].FlatStyle = FlatStyle.Flat;                
                }            
            this.buttons[playField.indexI0, playField.indexJ0].Text = "";
            this.tableLayoutPanel1.SuspendLayout();

            for(int i = 0; i < rang; i++)            
                for(int j = 0; j < rang; j++)
                    this.tableLayoutPanel1.Controls.Add(this.buttons[i,j], j, i);
            
            this.tableLayoutPanel1.ResumeLayout();

            //this.tableLayoutPanel1.Controls.GetChildIndex(this.buttons[0]);
        }
        #endregion

        private PlayTag.RandomField playField;
        private Button[,] buttons;
        private const int rang = 4;

        
    }   


//    
//    displayInfo();
//    playField.displayField();

//            while (true)
//            {
//                ConsoleKeyInfo inputKey = Console.ReadKey(true);
//                if (inputKey.Key == ConsoleKey.Escape) break;

//                if (inputKey.KeyChar == 'w' || inputKey.Key == ConsoleKey.UpArrow)
//                    playField.swapNumberByI(playField.indexI0 + 1);
//                if (inputKey.KeyChar == 's' || inputKey.Key == ConsoleKey.DownArrow)
//                    playField.swapNumberByI(playField.indexI0 - 1);
//                if (inputKey.KeyChar == 'a' || inputKey.Key == ConsoleKey.LeftArrow)
//                    playField.swapNumberByJ(playField.indexJ0 + 1);
//                if (inputKey.KeyChar == 'd' || inputKey.Key == ConsoleKey.RightArrow)
//                    playField.swapNumberByJ(playField.indexJ0 - 1);

//                Console.Clear();
//                displayInfo();

//                playField.displayField();

//                if (playField.checkedField1() || playField.checkedField2())
//                {
//                    Console.WriteLine("You win!");
//                    break;
//                }
//            }

//            void displayInfo()
//            {
//                  Console.WriteLine("Play tag");
//                  Console.WriteLine("Esc - exit");
//                  Console.WriteLine("W A S D or Arrowes - control\n");
//            }
}