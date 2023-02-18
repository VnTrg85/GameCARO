using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    [Serializable]
    public class SocketData
    {
        
        private Point point;
        private int command;
        private string message;

        public SocketData()
        {

        }
        public SocketData(int command, string message, Point point)
        {
            this.Command = command;
            this.Message = message;
            this.Point = point;
        }

        public Point Point { get => point; set => point=value; }
        public int Command { get => command; set => command=value; }
        public string Message { get => message; set => message=value; }

        public enum SocketCommand
        {
            SEND_POINT,
            NEW_GAME,
            QUIT,
            UNDO,
            UNDOREVERSE,
            NOTIFY
        }
    }
}
