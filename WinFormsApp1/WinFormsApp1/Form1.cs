using System.CodeDom.Compiler;
using System.Security.Policy;
using static WinFormsApp1.Manager;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        #region properties 
        Manager manager;
        SocketManager socket;
        bool clicked = false;
        #endregion
        public Form1()
        {
            InitializeComponent();
            setGame();
            manager =  new Manager(panelChessBoard,txtPlayer,picBoxPlayer);
            socket = new SocketManager();
            manager.MarkedGame += Manager_MarkedGame;
            manager.EndedGame += Manager_EndedGame;
            manager.newGameTime += Manager_newGameTime;
            
            DrawChessBoard();
            SettimeProgress();

        }
        // Cai dat game de nguoi dung bam vao nut CONNECT dau tien
        public void setGame()
        {
            menuToolStripMenuItem.Enabled = false;// MENU
            panelChessBoard.Enabled = false;// MAIN PANEL
        }
        private void Manager_newGameTime(object? sender, EventArgs e)
        {
            timerProgess.Stop();
            progressTime.Value = CONS.Min;
        }

        private void Manager_EndedGame(object? sender, EventArgs e)
        {
            timerProgess.Stop();
        }

        private void Manager_MarkedGame(object? sender, eventMarkedGame e)
        {
            progressTime.Value= 0;
            timerProgess.Start();
            panelChessBoard.Enabled = false;
            undoToolStripMenuItem1.Enabled = true;
            try
            {
                socket.Send(new SocketData((int)SocketData.SocketCommand.SEND_POINT, "", e.Point));
                Listen();
            }
            catch (Exception)
            {

            }
            
        }

        public void DrawChessBoard()
        {
            manager.DrawBoardChess();
        }
        public void NewGame()
        {
            manager.NewGame();
            
        }
        private void newGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewGame();
            undoToolStripMenuItem1.Enabled = false;
            try
            {
                socket.Send(new SocketData((int)SocketData.SocketCommand.NEW_GAME, "", new Point()));
            }
            catch (Exception)
            {

            }
        }

        private void quitToolStripMenuItem1_Click(object sender, EventArgs e)
        {            
            this.Close();
            
        }

        private void timerProgess_Tick(object sender, EventArgs e)
        {
            progressTime.PerformStep();  
            if(progressTime.Value >= progressTime.Maximum)
            {
                timerProgess.Stop();
                manager.endGame();
            }
        }


        public void SettimeProgress()
        {
            timerProgess.Interval = CONS.Interval;
            progressTime.Maximum = CONS.Max;
            progressTime.Minimum = CONS.Min;
            progressTime.Step = CONS.Step;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ban co muon thoat khong", "Thong bao", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketData.SocketCommand.QUIT, "", new Point()));
                }
                catch (Exception)
                {

                }
                socket.Client1.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            }
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                socket.Send(new SocketData((int)SocketData.SocketCommand.UNDO, "Nguoi choi con lai muon Undo", new Point()));
                Listen();
            }
            catch (Exception)
            {

            }
        }
       
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(clicked == false)
            {
                clicked = true;
                socket.IP = txtLAN.Text;
                if (!socket.Connect())
                {
                    socket.CreateServer();
                    panelChessBoard.Enabled = true;
                    menuToolStripMenuItem.Enabled = true;
                    undoToolStripMenuItem1.Enabled = false;
                    
                }
                else
                {
                    panelChessBoard.Enabled= false;
                    menuToolStripMenuItem.Enabled = true;
                    undoToolStripMenuItem1.Enabled = false;
                    Listen();          
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtLAN.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            if(string.IsNullOrEmpty(txtLAN.Text) )
            {
                txtLAN.Text = socket.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Ethernet);
            }
        }
        /*public bool Listen()
        {
            object datatemp = new object();
            if(socket.Receive(datatemp) == true)
            {
                string data = datatemp.ToString();
                MessageBox.Show(data, "Thong bao");
                return true;
            }
            return false;
        }*/
        public void Listen()
        {
            Thread listenData = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Receive();
                    ProcessData(data);
                }
                catch (Exception)
                {

                }
            });     
            listenData.IsBackground = true;
            listenData.Start();
        }
        public void ProcessData(SocketData data)
        {
            switch(data.Command)
            {
                // ============SEND POINT==============
                case (int)SocketData.SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        panelChessBoard.Enabled = true;
                        undoToolStripMenuItem1.Enabled  = false;
                        progressTime.Value= 0;
                        timerProgess.Start();
                        manager.otherMarkedButton(data.Point);                                           
                    }));
                    break;

                    // ================NEW GAME============
                case (int)SocketData.SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        panelChessBoard.Enabled = false;
                        undoToolStripMenuItem1.Enabled = false;
                    }));                   
                    break;
                    // -----------QUIT--------
                case (int)SocketData.SocketCommand.QUIT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        socket.Client1.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                        timerProgess.Stop();
                        MessageBox.Show("Nguoi choi thoat game!!!", data.Message);
                    }));
                    break;
                    // --------UNDO----------
                case (int)SocketData.SocketCommand.UNDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        DialogResult dl = MessageBox.Show(data.Message, "NOTIFY", MessageBoxButtons.YesNo);
                        if (dl == DialogResult.Yes)
                        {
                            manager.Undo();
                            panelChessBoard.Enabled = false;
                            
                            socket.Send(new SocketData((int)SocketData.SocketCommand.UNDOREVERSE, "", new Point()));
                        }
                        else
                        {
                            socket.Send(new SocketData((int)SocketData.SocketCommand.NOTIFY, "KHONG DONG Y", new Point()));
                        }
                    }));
                    break;
                   // ==============UNDOREVERSE============
                case (int)SocketData.SocketCommand.UNDOREVERSE:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        manager.Undo();
                        panelChessBoard.Enabled=true;
                       
                    }));
                    break;
                    //==============NOTIFY===============
                case (int)SocketData.SocketCommand.NOTIFY:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show(data.Message);
                    }));
                    break;
              
            }
            Listen();
        }
    }
}