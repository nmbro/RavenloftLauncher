using System;

namespace NWNBrowser
{
    public class ServerStatus
    {
        private MainForm _form;
        private GameServerInfo.GameServer _server;

        public ServerStatus(string ip, int port, MainForm form)
        {
            form.txtServerIP.Text = ip + ":" + port.ToString();

            this._server = new GameServerInfo.GameServer(ip, port, GameServerInfo.GameType.NeverwinterNights);
            this._form = form;
        }

        public void CheckServer()
        {
            this.check();
        }

        private void check()
        {
            try
            {
                this._server.QueryServer();

                if (this._server.IsOnline)
                {
                    string maxplayers = _server.Parameters["maxplayers"];
                    string currentplayers = _server.Parameters["numplayers"]; ;


                    this._form.txtServerStatus.Text = "Online";
                    this._form.txtPlayers.Text = currentplayers + "/" + maxplayers;
                }
                else
                {
                    this._form.txtServerStatus.Text = "Offline";
                    this._form.txtPlayers.Text = "N/A";
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
