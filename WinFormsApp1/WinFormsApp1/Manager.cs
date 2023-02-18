using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Manager
    {
        #region Properties
        Panel chessBoardPanel;
        List<Player> listPlayer;
        int CurrentPlayer;
        TextBox playerName;
        PictureBox picturePlayer;
        List<List<Button>> listButton;
        System.Windows.Forms.Timer timertimer;
        private Panel panelChessBoard;
        private TextBox txtPlayer;
        private PictureBox picBoxPlayer;
        private System.Windows.Forms.Timer timerProgess;
        private Button temp;
        private Stack<Button> checkedButton;
        public event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add { endedGame += value; }
            remove { endedGame -= value; }
        }
        public event EventHandler<eventMarkedGame> markedGame;
        public event EventHandler<eventMarkedGame> MarkedGame
        {
            add { markedGame += value; }
            remove { markedGame -= value; }
        }
        public event EventHandler newGameTime;
        public event EventHandler NewGameTime
        {
            add { newGameTime += value; }
            remove { newGameTime -= value; }
        }
        #endregion
        public class eventMarkedGame : EventArgs
        {
            Point point;

            public Point Point { get => point; set => point=value; }

            public eventMarkedGame(Point point)
            {
                this.point = point;
            }
        }

        #region Itinalize
        public Manager(Panel chessBoard, TextBox playerName, PictureBox picturePlayer)
        {
            this.chessBoardPanel = chessBoard;
            this.picturePlayer = picturePlayer;
            this.playerName  = playerName;
            checkedButton = new Stack<Button>();
            listPlayer = new List<Player>()
            {
                new Player("PlayerFirst",Image.FromFile(Application.StartupPath+"\\Resources\\IconX.png")),
                new Player("PlayerSecond",Image.FromFile(Application.StartupPath+"\\Resources\\IconY.jpg"))
            };
            CurrentPlayer = 1;

            changePlayer();

        }   

        #endregion
        #region Method
        internal List<Player> ListPlayer { get => listPlayer; set => listPlayer=value; }
        public TextBox PlayerName { get => playerName; set => playerName=value; }
        public PictureBox PicturePlayer { get => picturePlayer; set => picturePlayer=value; }
        public Panel ChessBoardPanel { get => chessBoardPanel; set => chessBoardPanel=value; }
        public List<List<Button>> ListButton { get => listButton; set => listButton=value; }
        public Stack<Button> CheckedButton { get => checkedButton; set => checkedButton=value; }

        public void DrawBoardChess()
        {
            listButton = new List<List<Button>>();
            Button OldButton = new Button() { Location = new Point(0, 0), Width = CONS.BOX_WIDTH, Height = CONS.BOX_HEIGHT , BackgroundImageLayout = ImageLayout.Stretch };
            OldButton.Click += Btn_Click;
            
            for (int i = 0; i< CONS.BOARD_WIDTH; i++)
            {              
                List<Button> list = new List<Button>();
                for (int j = 0; j< CONS.BOARD_HEIGHT; j++)
                {                                    
                    Button btn = new Button()
                    {
                        Width = CONS.BOX_WIDTH,
                        Height = CONS.BOX_HEIGHT,
                        Location = new Point(OldButton.Location.X+CONS.BOX_WIDTH, OldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()
                    };
                    list.Add(btn);                 
                    btn.Click += Btn_Click;
                    chessBoardPanel.Controls.Add(btn);
                    Button temp = new Button() { Location = new Point(btn.Location.X,btn.Location.Y)};
                    OldButton = temp;
                }
                listButton.Add(list);
                Point point = new Point(0, OldButton.Location.Y + CONS.BOX_HEIGHT);
                OldButton.Location = point;             
            }
        }

        public void endGame()
        {
            
            chessBoardPanel.Enabled = false;
            if(CurrentPlayer == 1)
            {
                MessageBox.Show("Nguoi choi thu nhat thang", "End game");
            }else
            {
                MessageBox.Show("Nguoi choi thu hai thang", "End game");
            }
            
        }
        private bool isEndGame(Button btn)
        {
            return isEndHorizontal(btn) || isEndVertical(btn) || isEndPrimaryDiagonol(btn) || isEndSubDiagonol(btn);
        }
        private Point getLocationButton(Button btn)
        {
            int horizontal = int.Parse(btn.Tag.ToString());
            int vertical = listButton[horizontal].IndexOf(btn);
            Point loca = new Point(horizontal, vertical);
            return loca;
        }
        private bool isEndHorizontal(Button btn)
        {
            Point loca = getLocationButton(btn);
            int countLeft = 0;
            int countRight = 0;

            for (int i = loca.Y-1; i >= 0 ; i--)
            {
                if (listButton[loca.X][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else
                    break;
            }
            for (int i = loca.Y+1; i < listButton[loca.X].Count; i++)
            {
                if (listButton[loca.X][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else
                    break;
            }
            if (countLeft+countRight >= 4)
            {
                return true;
            }
            return false;
        }
        private bool isEndVertical(Button btn)
        {
            Point loca = getLocationButton(btn);
            int countTop = 0;
            int countBottom = 0;

            for(int i = loca.X - 1; i>= 0;i--)
            {
                if (listButton[i][loca.Y].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            for (int i = loca.X + 1; i < listButton.Count; i++)
            {
                if (listButton[i][loca.Y].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            if (countTop+countBottom >= 4)
            {
                return true;
            }
            return false;
        }
        private bool isEndPrimaryDiagonol(Button btn)
        {
            Point loca = getLocationButton(btn);
            int countTopLeft = 0;
            int countBottomRight = 0;

            for(int i = 1; i <= loca.X && i <= loca.Y;i++)
            {
                if (listButton[loca.X-i][loca.Y-i].BackgroundImage == btn.BackgroundImage)
                {
                    countTopLeft++;
                }
                else
                    break;
            }
            for (int i = 1; i < listButton.Count-loca.X && i < listButton[loca.X].Count-loca.Y; i++)
            {
                if (listButton[loca.X+i][loca.Y+i].BackgroundImage == btn.BackgroundImage)
                {
                    countTopLeft++;
                }
                else
                    break;
            }
            if (countTopLeft+countBottomRight >= 4)
                return true;
            return false;
        }
        private bool isEndSubDiagonol(Button btn)
        {
            Point loca = getLocationButton(btn);
            int countTopRight = 0;
            int countBottomLeft = 0;
            for (int i = 1; i <= loca.X && i < listButton[loca.X].Count - loca.Y; i++)
            {
                if (listButton[loca.X-i][loca.Y+i].BackgroundImage == btn.BackgroundImage)
                {
                    countTopRight++;
                }
                else
                    break;
            }
            for (int i = 1; i < listButton.Count-loca.X && i < loca.Y; i++)
            {
                if (listButton[loca.X+i][loca.Y-i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottomLeft++;
                }
                else
                    break;
            }
            if (countBottomLeft + countTopRight >= 4)
                return true;

            return false;
        }


        private void Btn_Click(object sender, EventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null) return;
            Point point = getLocationButton(btn);
            if (markedGame != null)
            {
                markedGame(this, new eventMarkedGame(point));
            }
            
            
            if (btn != null)
            {
               
                if (btn.BackgroundImage != null)
                    return;
                checkedButton.Push(btn);
                changeImage(btn);
                changePlayer();
                if(isEndGame(btn))
                {
                    endedGame(this,new EventArgs());
                    endGame();
                }
            }  
            if(checkAllBbutton() == false)
            {
                MessageBox.Show("Hoa", "End game");
            }
        }
        public void otherMarkedButton(Point point)
        {
            Button btn = listButton[point.X][point.Y];
            
            if (btn != null)
            {
                if (btn.BackgroundImage != null)
                    return;
                checkedButton.Push(btn);
                changeImage(btn);
                changePlayer();
                if (isEndGame(btn))
                {
                    endedGame(this, new EventArgs());
                    endGame();
                }
            }
            if (checkAllBbutton() == false)
            {
                MessageBox.Show("Hoa", "End game");
            }
        }
        private void changeImage(Button btn)
        {
            btn.BackgroundImage = listPlayer[CurrentPlayer].Mark;          
        }
        private void changePlayer()
        {           
                CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
                PlayerName.Text = listPlayer[CurrentPlayer].Name;
                PicturePlayer.BackgroundImage = listPlayer[CurrentPlayer].Mark;           
        }
        private void changePlayerNewGame()
        {
            CurrentPlayer = 0;
            PlayerName.Text = listPlayer[CurrentPlayer].Name;
            PicturePlayer.BackgroundImage = listPlayer[CurrentPlayer].Mark;
        }
        public void NewGame()
        {
            newGameTime(this, new EventArgs());
            changePlayerNewGame();
            chessBoardPanel.Enabled = true;
            for(int i = 0; i< listButton.Count; i++)
            {
                for(int j=0; j < listButton[i].Count;j++)
                {
                    listButton[i][j].BackgroundImage= null;
                }
            }           
            checkedButton.Clear();
        }
        public void Undo()
        {
            if(checkedButton.Count != 0)
            {
                Button btn = checkedButton.Pop();
                if (btn != null)
                {
                    btn.BackgroundImage = null;
                    changePlayer();
                }
            }
        }
        public bool checkAllBbutton()//Kiem tra xem tat ca cac o da duoc danh
        {
            for(int i= 0; i<listButton.Count;i++)
            {
                for(int j = 0; j<listButton[i].Count;j++)
                {
                    if (listButton[i][j].BackgroundImage == null)
                        return true;
                }
            }
            return false;
        }
    }
        #endregion
}

