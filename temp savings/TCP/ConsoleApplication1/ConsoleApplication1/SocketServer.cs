/*
 * Created by SharpDevelop.
 * User: Jayan Nair
 * Date: 7/13/2004
 * Time: 2:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace DefaultNamespace
{
	/// <summary>
	/// Description of SocketServer.	
	/// </summary>
	public class SocketServer : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RichTextBox richTextBoxReceivedMsg;
		private System.Windows.Forms.TextBox textBoxPort;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxMsg;
		private System.Windows.Forms.Button buttonStopListen;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox richTextBoxSendMsg;
		private System.Windows.Forms.TextBox textBoxIP;
		private System.Windows.Forms.Button buttonStartListen;
		private System.Windows.Forms.Button buttonSendMsg;
		private System.Windows.Forms.Button buttonClose;
		
		
		const int MAX_CLIENTS = 10;
		
		public AsyncCallback pfnWorkerCallBack ;
		private  Socket m_mainSocket;
		private  Socket [] m_workerSocket = new Socket[10];
		private int m_clientCount = 0;
		
		public SocketServer()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			// Display the local IP address on the GUI
			textBoxIP.Text = GetIP();
		}
		
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Run(new SocketServer());
		}
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSendMsg = new System.Windows.Forms.Button();
            this.buttonStartListen = new System.Windows.Forms.Button();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.richTextBoxSendMsg = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStopListen = new System.Windows.Forms.Button();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.richTextBoxReceivedMsg = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(385, 268);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(106, 27);
            this.buttonClose.TabIndex = 11;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // buttonSendMsg
            // 
            this.buttonSendMsg.Location = new System.Drawing.Point(19, 222);
            this.buttonSendMsg.Name = "buttonSendMsg";
            this.buttonSendMsg.Size = new System.Drawing.Size(231, 27);
            this.buttonSendMsg.TabIndex = 7;
            this.buttonSendMsg.Text = "Send Message";
            this.buttonSendMsg.Click += new System.EventHandler(this.ButtonSendMsgClick);
            // 
            // buttonStartListen
            // 
            this.buttonStartListen.BackColor = System.Drawing.Color.Blue;
            this.buttonStartListen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartListen.ForeColor = System.Drawing.Color.Yellow;
            this.buttonStartListen.Location = new System.Drawing.Point(272, 18);
            this.buttonStartListen.Name = "buttonStartListen";
            this.buttonStartListen.Size = new System.Drawing.Size(106, 47);
            this.buttonStartListen.TabIndex = 4;
            this.buttonStartListen.Text = "Start Listening";
            this.buttonStartListen.UseVisualStyleBackColor = false;
            this.buttonStartListen.Click += new System.EventHandler(this.ButtonStartListenClick);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(106, 18);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.ReadOnly = true;
            this.textBoxIP.Size = new System.Drawing.Size(144, 22);
            this.textBoxIP.TabIndex = 12;
            // 
            // richTextBoxSendMsg
            // 
            this.richTextBoxSendMsg.Location = new System.Drawing.Point(19, 100);
            this.richTextBoxSendMsg.Name = "richTextBoxSendMsg";
            this.richTextBoxSendMsg.Size = new System.Drawing.Size(231, 120);
            this.richTextBoxSendMsg.TabIndex = 6;
            this.richTextBoxSendMsg.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port";
            // 
            // buttonStopListen
            // 
            this.buttonStopListen.BackColor = System.Drawing.Color.Red;
            this.buttonStopListen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStopListen.ForeColor = System.Drawing.Color.Yellow;
            this.buttonStopListen.Location = new System.Drawing.Point(385, 18);
            this.buttonStopListen.Name = "buttonStopListen";
            this.buttonStopListen.Size = new System.Drawing.Size(106, 47);
            this.buttonStopListen.TabIndex = 5;
            this.buttonStopListen.Text = "Stop Listening";
            this.buttonStopListen.UseVisualStyleBackColor = false;
            this.buttonStopListen.Click += new System.EventHandler(this.ButtonStopListenClick);
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMsg.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxMsg.Location = new System.Drawing.Point(144, 277);
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.ReadOnly = true;
            this.textBoxMsg.Size = new System.Drawing.Size(230, 15);
            this.textBoxMsg.TabIndex = 14;
            this.textBoxMsg.Text = "None";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Broadcast Message To Clients";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(260, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Message Received From Clients";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(106, 46);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(48, 22);
            this.textBoxPort.TabIndex = 0;
            this.textBoxPort.Text = "8000";
            // 
            // richTextBoxReceivedMsg
            // 
            this.richTextBoxReceivedMsg.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBoxReceivedMsg.Location = new System.Drawing.Point(260, 100);
            this.richTextBoxReceivedMsg.Name = "richTextBoxReceivedMsg";
            this.richTextBoxReceivedMsg.ReadOnly = true;
            this.richTextBoxReceivedMsg.Size = new System.Drawing.Size(231, 149);
            this.richTextBoxReceivedMsg.TabIndex = 9;
            this.richTextBoxReceivedMsg.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server IP";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Status Message:";
            // 
            // SocketServer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(503, 346);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBoxReceivedMsg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSendMsg);
            this.Controls.Add(this.richTextBoxSendMsg);
            this.Controls.Add(this.buttonStopListen);
            this.Controls.Add(this.buttonStartListen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPort);
            this.Name = "SocketServer";
            this.Text = "SocketServer";
            this.Load += new System.EventHandler(this.SocketServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		void ButtonStartListenClick(object sender, System.EventArgs e)
		{
			try
			{
				// Check the port value
				if(textBoxPort.Text == ""){
					MessageBox.Show("Please enter a Port Number");
					return;
				}
				string portStr = textBoxPort.Text;
				int port = System.Convert.ToInt32(portStr);
				// Create the listening socket...
				m_mainSocket = new Socket(AddressFamily.InterNetwork, 
				                          SocketType.Stream, 
				                          ProtocolType.Tcp);
				IPEndPoint ipLocal = new IPEndPoint (IPAddress.Any, port);
				// Bind to local IP Address...
				m_mainSocket.Bind( ipLocal );
				// Start listening...
				m_mainSocket.Listen (4);
				// Create the call back for any client connections...
				m_mainSocket.BeginAccept(new AsyncCallback (OnClientConnect), null);
				
				UpdateControls(true);
				
			}
			catch(SocketException se)
			{
				MessageBox.Show ( se.Message );
			}

		}
		private void UpdateControls( bool listening ) 
		{
			buttonStartListen.Enabled 	= !listening;
			buttonStopListen.Enabled 	= listening;
		}	
		// This is the call back function, which will be invoked when a client is connected
		public void OnClientConnect(IAsyncResult asyn)
		{
			try
			{
				// Here we complete/end the BeginAccept() asynchronous call
				// by calling EndAccept() - which returns the reference to
				// a new Socket object
				m_workerSocket[m_clientCount] = m_mainSocket.EndAccept (asyn);
				// Let the worker Socket do the further processing for the 
				// just connected client
				WaitForData(m_workerSocket[m_clientCount]);
				// Now increment the client count
				++m_clientCount;
				// Display this client connection as a status message on the GUI	
				String str = String.Format("Client # {0} connected", m_clientCount);
                this.Invoke((MethodInvoker)delegate
                {
                    this.textBoxMsg.Text = str;
                });
				
								
				// Since the main Socket is now free, it can go back and wait for
				// other clients who are attempting to connect
				m_mainSocket.BeginAccept(new AsyncCallback ( OnClientConnect ),null);
			}
			catch(ObjectDisposedException)
			{
				System.Diagnostics.Debugger.Log(0,"1","\n OnClientConnection: Socket has been closed\n");
			}
			catch(SocketException se)
			{
				MessageBox.Show ( se.Message );
			}
			
		}
		public class SocketPacket
		{
			public System.Net.Sockets.Socket m_currentSocket;
			public byte[] dataBuffer = new byte[1];
		}
		// Start waiting for data from the client
		public void WaitForData(System.Net.Sockets.Socket soc)
		{
			try
			{
				if  ( pfnWorkerCallBack == null ){		
					// Specify the call back function which is to be 
					// invoked when there is any write activity by the 
					// connected client
					pfnWorkerCallBack = new AsyncCallback (OnDataReceived);
				}
				SocketPacket theSocPkt = new SocketPacket ();
				theSocPkt.m_currentSocket 	= soc;
				// Start receiving any data written by the connected client
				// asynchronously
				soc .BeginReceive (theSocPkt.dataBuffer, 0, 
				                   theSocPkt.dataBuffer.Length,
				                   SocketFlags.None,
				                   pfnWorkerCallBack,
				                   theSocPkt);
			}
			catch(SocketException se)
			{
				MessageBox.Show (se.Message );
			}

		}
		// This the call back function which will be invoked when the socket
		// detects any client writing of data on the stream
		public  void OnDataReceived(IAsyncResult asyn)
		{
			try
			{
				SocketPacket socketData = (SocketPacket)asyn.AsyncState ;

				int iRx  = 0 ;
				// Complete the BeginReceive() asynchronous call by EndReceive() method
				// which will return the number of characters written to the stream 
				// by the client
				iRx = socketData.m_currentSocket.EndReceive (asyn);
				char[] chars = new char[iRx +  1];
				System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
				int charLen = d.GetChars(socketData.dataBuffer, 
				                         0, iRx, chars, 0);
				//System.String szData = new System.String(chars);
				//richTextBoxReceivedMsg.AppendText(szData);

                System.String szData = new System.String(chars);
                this.Invoke((MethodInvoker)delegate
                {
                    this.richTextBoxReceivedMsg.AppendText(szData);
                });
	
				// Continue the waiting for data on the Socket
				WaitForData( socketData.m_currentSocket );
			}
			catch (ObjectDisposedException )
			{
				System.Diagnostics.Debugger.Log(0,"1","\nOnDataReceived: Socket has been closed\n");
			}
			catch(SocketException se)
			{
				MessageBox.Show (se.Message );
			}
		}
		void ButtonSendMsgClick(object sender, System.EventArgs e)
		{
			try
			{
				Object objData = richTextBoxSendMsg.Text;
				byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString ());
				for(int i = 0; i < m_clientCount; i++){
					if(m_workerSocket[i] != null){
						if(m_workerSocket[i].Connected){
							m_workerSocket[i].Send (byData);
						}
					}
				}
				
			}
			catch(SocketException se)
			{
				MessageBox.Show (se.Message );
			}
		}
		
		void ButtonStopListenClick(object sender, System.EventArgs e)
		{
			CloseSockets();			
			UpdateControls(false);
		}
	
	   String GetIP()
	   {	   
	   		String strHostName = Dns.GetHostName();
		
		   	// Find host by name
		   	IPHostEntry iphostentry = Dns.GetHostByName(strHostName);
		
		   	// Grab the first IP addresses
		   	String IPStr = "";
		   	foreach(IPAddress ipaddress in iphostentry.AddressList){
		        IPStr = ipaddress.ToString();
		   		return IPStr;
		   	}
		   	return IPStr;
	   }
	   void ButtonCloseClick(object sender, System.EventArgs e)
	   {
	   		CloseSockets();
	   		Close();
	   }
	   void CloseSockets()
	   {
	   		if(m_mainSocket != null){
	   			m_mainSocket.Close();
	   		}
			for(int i = 0; i < m_clientCount; i++){
				if(m_workerSocket[i] != null){
					m_workerSocket[i].Close();
					m_workerSocket[i] = null;
				}
			}	
	   }

        private void SocketServer_Load(object sender, EventArgs e)
        {

        }
    }
}
