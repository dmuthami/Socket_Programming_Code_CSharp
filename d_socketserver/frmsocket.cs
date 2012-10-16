using System;
using System.Drawing;
using System.Collections;// Access to the Array list
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Threading;								// Sleeping
using System.Net;									// Used to local machine info
using System.Net.Sockets;							// Socket namespace
using MapObjects2;	
using System.Text.RegularExpressions;					
using System.IO;

namespace SocketServer060811
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmsocket : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		public frmsocket()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpgconnect = new System.Windows.Forms.TabPage();
			this.grpcontrols = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.btnclose = new System.Windows.Forms.Button();
			this.btndisconnect = new System.Windows.Forms.Button();
			this.btnconnect = new System.Windows.Forms.Button();
			this.txtport = new System.Windows.Forms.TextBox();
			this.rtberror = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.chkfeedback = new System.Windows.Forms.CheckBox();
			this.lblclients = new System.Windows.Forms.RichTextBox();
			this.rtbmessage = new System.Windows.Forms.RichTextBox();
			this.lbllisten = new System.Windows.Forms.Label();
			this.tpgother = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtdest = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.timer3 = new System.Windows.Forms.Timer(this.components);
			this.tabControl1.SuspendLayout();
			this.tpgconnect.SuspendLayout();
			this.grpcontrols.SuspendLayout();
			this.tpgother.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpgconnect);
			this.tabControl1.Controls.Add(this.tpgother);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(368, 428);
			this.tabControl1.TabIndex = 0;
			// 
			// tpgconnect
			// 
			this.tpgconnect.Controls.Add(this.grpcontrols);
			this.tpgconnect.Controls.Add(this.txtport);
			this.tpgconnect.Controls.Add(this.rtberror);
			this.tpgconnect.Controls.Add(this.label2);
			this.tpgconnect.Controls.Add(this.label1);
			this.tpgconnect.Controls.Add(this.chkfeedback);
			this.tpgconnect.Controls.Add(this.lblclients);
			this.tpgconnect.Controls.Add(this.rtbmessage);
			this.tpgconnect.Controls.Add(this.lbllisten);
			this.tpgconnect.Location = new System.Drawing.Point(4, 22);
			this.tpgconnect.Name = "tpgconnect";
			this.tpgconnect.Size = new System.Drawing.Size(360, 402);
			this.tpgconnect.TabIndex = 0;
			this.tpgconnect.Text = "Connect";
			// 
			// grpcontrols
			// 
			this.grpcontrols.Controls.Add(this.button1);
			this.grpcontrols.Controls.Add(this.btnclose);
			this.grpcontrols.Controls.Add(this.btndisconnect);
			this.grpcontrols.Controls.Add(this.btnconnect);
			this.grpcontrols.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grpcontrols.Location = new System.Drawing.Point(0, 354);
			this.grpcontrols.Name = "grpcontrols";
			this.grpcontrols.Size = new System.Drawing.Size(360, 48);
			this.grpcontrols.TabIndex = 22;
			this.grpcontrols.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(207, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(50, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "button1";
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnclose
			// 
			this.btnclose.Location = new System.Drawing.Point(264, 16);
			this.btnclose.Name = "btnclose";
			this.btnclose.Size = new System.Drawing.Size(88, 24);
			this.btnclose.TabIndex = 2;
			this.btnclose.Text = "Close";
			this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
			// 
			// btndisconnect
			// 
			this.btndisconnect.Enabled = false;
			this.btndisconnect.Location = new System.Drawing.Point(104, 16);
			this.btndisconnect.Name = "btndisconnect";
			this.btndisconnect.Size = new System.Drawing.Size(88, 24);
			this.btndisconnect.TabIndex = 1;
			this.btndisconnect.Text = "Disconnect";
			this.btndisconnect.Click += new System.EventHandler(this.btndisconnect_Click);
			// 
			// btnconnect
			// 
			this.btnconnect.Location = new System.Drawing.Point(8, 16);
			this.btnconnect.Name = "btnconnect";
			this.btnconnect.Size = new System.Drawing.Size(88, 24);
			this.btnconnect.TabIndex = 0;
			this.btnconnect.Text = "Connect";
			this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
			// 
			// txtport
			// 
			this.txtport.Location = new System.Drawing.Point(288, 2);
			this.txtport.Name = "txtport";
			this.txtport.Size = new System.Drawing.Size(64, 20);
			this.txtport.TabIndex = 21;
			// 
			// rtberror
			// 
			this.rtberror.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtberror.Location = new System.Drawing.Point(224, 312);
			this.rtberror.Name = "rtberror";
			this.rtberror.Size = new System.Drawing.Size(128, 16);
			this.rtberror.TabIndex = 20;
			this.rtberror.Text = "";
			this.rtberror.Visible = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(192, 16);
			this.label2.TabIndex = 19;
			this.label2.Text = "Messages";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(216, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 16);
			this.label1.TabIndex = 18;
			this.label1.Text = "Connected clients";
			// 
			// chkfeedback
			// 
			this.chkfeedback.Location = new System.Drawing.Point(224, 332);
			this.chkfeedback.Name = "chkfeedback";
			this.chkfeedback.Size = new System.Drawing.Size(128, 16);
			this.chkfeedback.TabIndex = 17;
			this.chkfeedback.Text = "Send poll";
			// 
			// lblclients
			// 
			this.lblclients.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblclients.Location = new System.Drawing.Point(216, 48);
			this.lblclients.Name = "lblclients";
			this.lblclients.Size = new System.Drawing.Size(136, 280);
			this.lblclients.TabIndex = 16;
			this.lblclients.Text = "";
			// 
			// rtbmessage
			// 
			this.rtbmessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbmessage.Location = new System.Drawing.Point(8, 48);
			this.rtbmessage.Name = "rtbmessage";
			this.rtbmessage.Size = new System.Drawing.Size(200, 296);
			this.rtbmessage.TabIndex = 15;
			this.rtbmessage.Text = "";
			// 
			// lbllisten
			// 
			this.lbllisten.BackColor = System.Drawing.SystemColors.Info;
			this.lbllisten.Location = new System.Drawing.Point(2, 2);
			this.lbllisten.Name = "lbllisten";
			this.lbllisten.Size = new System.Drawing.Size(286, 20);
			this.lbllisten.TabIndex = 14;
			// 
			// tpgother
			// 
			this.tpgother.Controls.Add(this.label4);
			this.tpgother.Controls.Add(this.label3);
			this.tpgother.Controls.Add(this.txtdest);
			this.tpgother.Location = new System.Drawing.Point(4, 22);
			this.tpgother.Name = "tpgother";
			this.tpgother.Size = new System.Drawing.Size(360, 402);
			this.tpgother.TabIndex = 1;
			this.tpgother.Text = "Other";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(344, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Create files";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(344, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "Destination directory";
			// 
			// txtdest
			// 
			this.txtdest.Location = new System.Drawing.Point(8, 24);
			this.txtdest.Name = "txtdest";
			this.txtdest.Size = new System.Drawing.Size(344, 20);
			this.txtdest.TabIndex = 0;
			this.txtdest.Text = "C:\\\\SocketPoles";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// frmsocket
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 428);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "frmsocket";
			this.Text = "SocketServer060811";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.tpgconnect.ResumeLayout(false);
			this.tpgconnect.PerformLayout();
			this.grpcontrols.ResumeLayout(false);
			this.tpgother.ResumeLayout(false);
			this.tpgother.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]

		#region"socket code"
		static void Main(string[] args) 
		{
			Application.Run(new frmsocket());
		}
		#region"private variables"
		private Socket m_mainsocket;
		private int m_port=3333;
		private ArrayList m_arrclients=new ArrayList();
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpgconnect;
		private System.Windows.Forms.TabPage tpgother;
		private System.Windows.Forms.RichTextBox rtberror;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkfeedback;
		private System.Windows.Forms.RichTextBox lblclients;
		private System.Windows.Forms.RichTextBox rtbmessage;
		private System.Windows.Forms.Label lbllisten;
		private System.Windows.Forms.TextBox txtport;
		private System.Windows.Forms.GroupBox grpcontrols;
		private System.Windows.Forms.Button btnconnect;
		private System.Windows.Forms.Button btndisconnect;
		private System.Windows.Forms.Button btnclose;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timer2;
	//an array containng all client connections
		public delegate void ddisplay();
		public System.Threading.Thread tdisplay;
		private System.Windows.Forms.TextBox txtdest;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Timer timer3;
		private System.Windows.Forms.Label label4;/*a thread  */
		private System.DateTime  m_timespan=new DateTime();
		#endregion
		public void m_initsocket()
		{
			try
			{
				//get ip address of local machine
				System.Net.IPAddress m_ipaddress=null;
				string m_hostname="";
				this.m_port=int.Parse(this.txtport.Text) ;
				m_hostname=System.Net.Dns.GetHostName();
				System.Net.IPHostEntry m_ipentry=System.Net.Dns.GetHostByName(m_hostname);
				m_ipaddress=m_ipentry.AddressList[0];
				this.lbllisten.Text ="Listening on:"+m_hostname+" "+m_ipaddress+":"+
					m_port;
				//instantiate socket,bind and listen
				m_mainsocket=new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
				m_mainsocket.Bind(new IPEndPoint(m_ipaddress,m_port));
				// backlog parameter
				/*specifies the number of connections that
				 * can be qued in the network stack */
				m_mainsocket.Listen(4);
				// setup a callback to be notified of connection events
				m_mainsocket.BeginAccept(new AsyncCallback(m_onconnect),m_mainsocket);
			
			

			}
			catch(System.Exception ex)
			{
				try
				{

				}
				catch{}
			

			}
			


		}
		public void m_onconnect(System.IAsyncResult m_ar)
		{
			try
			{
				//call back information called by client on connect
				//get information on the asynchronous operation
				Socket m_mainsocket=(Socket)m_ar.AsyncState;
				//accept the connection and add it up to our list
				//create a worker socket and set up a callback TO receive data
				m_newconnect(m_mainsocket.EndAccept(m_ar));
				//Go back and accept new connections
				m_mainsocket.BeginAccept(new AsyncCallback(m_onconnect),m_mainsocket);
				

			}
			catch{}
		
		}
		/// <summary>
		/// add given connection to our list of clients
		/// we have a new connection(friend)
		/// send a welcome note
		/// set up a callback to receive data
		/// </summary>
		/// <param name="m_socklient"></param>
		/// 
		public void m_newconnect(Socket m_socklient)
		{
			try
			{
				m_clientsoc client=new m_clientsoc(m_socklient);
				try
				{
			   
					//client.soc.Blocking=false;
					//set socket options okay
					client.soc.SetSocketOption(System.Net.Sockets.SocketOptionLevel.Socket,System.Net.Sockets.SocketOptionName.SendTimeout,1000);
					client.soc.SetSocketOption(System.Net.Sockets.SocketOptionLevel.Socket,System.Net.Sockets.SocketOptionName.ReceiveTimeout,1000);
				
					//add the client to our array of clients
					this.m_arrclients.Add(client);
					//MessageBox.Show("client disconnected"+m_client.soc.RemoteEndPoint.ToString());
					//send a welcome message
					//convert to byte array and send
					if(this.chkfeedback.Checked==true)
					{
						//					string m_welcom="good";
						//				    byte[] m_bytesend=System.Text.Encoding.ASCII.GetBytes(m_welcom.ToCharArray());
						//				    client.soc.Send(m_bytesend,m_bytesend.Length,0);
					}
					client.m_receivecallback(this);
					//oh i love this
					//this client has just connected
					m_updatelistbox();
				}
				catch(System.Exception ex){}
			
	   

			}
			catch{}
//				try{System.GC.Collect();}
//				catch{}

		}
		public void m_receiveddata(System.IAsyncResult m_ar)
		{
			try
			{
				m_clientsoc m_client=(m_clientsoc)m_ar.AsyncState;
				try
				{
				
					byte[] m_arrRet=m_client.m_getreceivedata(m_ar);
					//i have commented code to disconnect here
					if(m_arrRet.Length<1)
					{
						//show disconnected client first
						//to avoid accessing an object that is already disposed
						try
						{
							m_rtbmessage="client disconnected"+" "+
								m_client.soc.RemoteEndPoint.ToString();
							m_rtbmessage="\r\n"+m_rtbmessage;

							try
							{
								if(tdisplay.IsAlive==true){tdisplay.Abort();}
							}
							catch(System.Exception ex){}
					
							tdisplay = new System.Threading.Thread(new System.Threading.ThreadStart(this._displayoutput));
							tdisplay.Priority = System.Threading.ThreadPriority.BelowNormal;
							tdisplay.IsBackground=true;
							tdisplay.Start();
						}
						catch(System.Exception ex){string m_str=ex.Message.ToString();}
						//MessageBox.Show("client disconnected"+m_client.soc.RemoteEndPoint.ToString());
						//					m_client.soc.Close();//close disconnected socket
						//					this.m_arrclients.Remove(m_client);//remove the socket from array of client connections
						this.m_updatelistbox();//update connected clients
//						try{System.GC.Collect();}
//						catch{}
						//return;
					}
					else
					{
				
						//send received data to all clients including sender( for echo)
						//set up a receive call back for the client
						m_client.m_receivecallback(this);
						//extract the message
						System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
						//System.Text.Decoder m_decoder =   System.Text.Encoding.UTF8.GetEncoder();
						int m_bytecount=m_arrRet.Length;
						char[] m_char=new char[m_bytecount+1];
						int m_charlen=d.GetChars(m_arrRet,0,m_bytecount,m_char,0);
						System.String m_data=new System.String(m_char);
						//check string in this format-------reqpos|bt0100
				
						string m_reqpos=m_data;
						string[] m_arr=m_reqpos.Split(new char[] {'.'});
						if (m_arr[0].ToString().ToLower()=="rp")
						{
							/*call broadcast function*/
							m_tcpsend(m_reqpos);
							//-----end of string
							//manipulate data and run parsefull str
							this.m_rtbmessage+=m_data;
							//--------------------code to insert data to database

							string msg = "" + 1+ ":";
							try
							{
								try
								{
									if(tdisplay.IsAlive==true){tdisplay.Abort();}
								}
								catch(System.Exception ex){}
								tdisplay = new System.Threading.Thread(new System.Threading.ThreadStart(this._displayoutput));
								tdisplay.Priority = System.Threading.ThreadPriority.BelowNormal;
								tdisplay.IsBackground=true;
								tdisplay.Start();
							}
							catch(System.Exception ex){}
						}
						else
						{
							//manipulate data and run parsefull str
							this.m_rtbmessage+=m_data;
							//--------------------code to insert data to database

							string msg = "" + 1+ ":";
							try
							{
							

								this.ParseFullSTR(msg+m_rtbmessage);
						
							}
							catch(System.Exception ex){}
						
							//end of code
							m_rtbmessage="\r\n"+m_rtbmessage;
							try
							{
								try
								{
									if(tdisplay.IsAlive==true){tdisplay.Abort();}
								}
								catch(System.Exception ex){}
								tdisplay = new System.Threading.Thread(new System.Threading.ThreadStart(this._displayoutput));
								tdisplay.Priority = System.Threading.ThreadPriority.BelowNormal;
								tdisplay.IsBackground=true;
								tdisplay.Start();
							}
							catch(System.Exception ex){}

						}

					}
				
				

				}
				catch(System.Exception ex){}
	
			}
			catch{}
			try{System.GC.Collect();}
				catch{}

		}


		#region"error handlers"
		public  string m_listbox="";
		public  string m_rtbmessage="";
		private void DisplayOutput()
		{
			try
			{
				if(m_rtbmessage.Length>0)
				{this.rtbmessage.AppendText(m_rtbmessage + "\r\n");}
				
				if(m_listbox.Length>0)
				{lblclients.Clear();if(m_listbox.Trim()!="1111"){lblclients.AppendText(m_listbox);}}
				m_listbox="";m_rtbmessage="";
					
			}
			catch(System.Exception ep){string ser=ep.Message.ToString();}
			

		}
		private void _displayoutput()
		{
			try
			{
				this.Invoke(new ddisplay(DisplayOutput), new object[] { });
			}
			catch (System.Exception er) { string ser = er.Message.ToString(); }
		  
		}
		#endregion

		public void m_updatelistbox()
		{
			try
			{
				System.Text.StringBuilder m_sb=new System.Text.StringBuilder("1111"+"\r\n");
				int m_clientkey=0;
				m_clientkey=m_arrclients.Count;
				m_clientkey=0;
				foreach(m_clientsoc m_discOrcon in m_arrclients)
				{
					
					if(m_discOrcon.soc!=null)
					{
						m_clientkey++;
						m_sb.Append(m_clientkey + " - " + m_discOrcon.soc.RemoteEndPoint.ToString()+"\r\n");
						//m_listbox.Items.Add();
//						if(m_discOrcon.soc.Connected)
//						{
//							
//						}

					}
				}
				
				m_listbox=m_sb.ToString();
				try
				{
					try
					{
							if(tdisplay.IsAlive==true){tdisplay.Abort();}
					}
					catch(System.Exception ex){}
					
					tdisplay = new System.Threading.Thread(new System.Threading.ThreadStart(this._displayoutput));
					tdisplay.Priority = System.Threading.ThreadPriority.BelowNormal;
					tdisplay.IsBackground=true;
					tdisplay.Start();
				}
				catch(System.Exception ex){}
			}
			catch{}
			
			
		}
		public void Form1_Load(object sender, System.EventArgs e)
		{
			try
			{
				//restart socket after evry hour
			this.timer1.Enabled=true;
			this.timer1.Interval=300000;/*21600000*//*3600000*/ //refresh socket in 30 min
			this.timer1.Start();
//				this.timer2.Enabled=true;
//				this.timer2.Interval=1000;/*21600000*//*3600000*/ //refresh socket in 30 min
//				this.timer2.Start();
//			

		
			}
			catch(System.Exception ex){MessageBox.Show(ex.Message.ToString());}
			try
			{m_checkdir();}
			catch{}
			
		}
		private void m_checkdir()
		{
			try
			{
				FileInfo m_fileinfo=new FileInfo("C:\\SocketPoles\\trial.txt");
				string m_dirpath=m_fileinfo.Directory.FullName;
				if(!Directory.Exists(m_dirpath))
				{Directory.CreateDirectory(m_dirpath);}
				if(!Directory.Exists(m_dirpath+"\\Backup"))
				{Directory.CreateDirectory(m_dirpath+"\\Backup");}
				if(!Directory.Exists(m_dirpath+"\\Unread"))
				{Directory.CreateDirectory(m_dirpath+"\\Unread");}
				string m_str="cool";
			}
			catch{}
			
		}
		public void btnconnect_Click(object sender, System.EventArgs e)
		{
			m_connect();
		}
		public void m_connect()
		{
			m_con();
		}
		public void m_con()
		{
			try
			{
				m_initsocket();
				//----
				this.btndisconnect.Enabled=true;
				this.btnconnect.Enabled=false;
				this.m_updatelistbox();

			}
			catch(System.Exception ex){MessageBox.Show(ex.Message.ToString());}
		}
		public void btndisconnect_Click(object sender, System.EventArgs e)
		{
			m_disc();
		}
		public void m_disc()
		{
			try
			{
				m_mainsocket.Close();
				//loop the array containing the worker socket and 
				//close those connections
				//then remove worker socket object from the array
				int m_count=this.m_arrclients.Count;
//				for(int kappa=0;kappa<m_count;kappa++)
//				{
//				
//					m_klient=(Socket)m_arrclients[kappa];
//                    m_klient.Close();
//				}
				//m_arrclients.Clear();
			
				//----
				this.btndisconnect.Enabled=false;
				this.btnconnect.Enabled=true;

			}
			catch(System.Exception ex){MessageBox.Show(ex.Message.ToString());}
			try{System.GC.Collect();}
			catch{}
		}
		public void btnclose_Click(object sender, System.EventArgs e)
		{
		  Application.Exit();
		}
		

		#region"isconnected"
		public void m_isconnected()
		{
			try
			{
				
					if(m_mainsocket.Poll(-1,SelectMode.SelectRead))
					{
					MessageBox.Show("Can't read");
					}
					if(m_mainsocket.Poll(-1, SelectMode.SelectWrite))
					{
						MessageBox.Show("Can't write");
					}
					else if (m_mainsocket.Poll(-1, SelectMode.SelectRead))
					{
						MessageBox.Show("Can't read");
						
					}
					else if (m_mainsocket.Poll(-1, SelectMode.SelectError))
					{
						MessageBox.Show("Socket error");
					}
			}
			catch{}
			
		}
	
		public void button1_Click(object sender, System.EventArgs e)
		{
			try{this.m_insert();}
			catch{}
		}
		#endregion

		//class handling client information and buffers

		internal class m_clientsoc
		{
			private Socket m_soc;         //connection to the client
			byte[] m_buffer=new byte[1024]; //receive buffer
			/// <summary>
			/// constructor
			/// </summary>
			/// <param name="soc">client socket connection this object represents</param>
			public  m_clientsoc(Socket soc)
			{
				m_soc=soc;
			}
			//read only access
			public Socket soc
			{
				get{return m_soc;}
			}
			
			/// <summary>
			/// setup the callback for receive data and disconnection
			/// </summary>
			/// <param name="soc"></param>
			public void m_receivecallback(frmsocket frm)
			{
				try
				{
					System.AsyncCallback m_receivedata=new AsyncCallback(frm.m_receiveddata);
					m_soc.BeginReceive(m_buffer,0,m_buffer.Length,SocketFlags.None,m_receivedata,this);

				}
				catch{}
			}
			
			/// <summary>
			/// data has been received and so we shall put it into an array
			/// and return it.
			/// </summary>
			/// <param name="ar"></param>
			/// <returns></returns>
			/// <returns>array of bytes containing the received data</returns>
			public byte[] m_getreceivedata(IAsyncResult m_ar)
			{
				int m_bytesrec=0;
				try
				{m_bytesrec=m_soc.EndReceive(m_ar);}
				catch{}
				byte[] m_byteret=new byte[m_bytesrec];
				Array.Copy(this.m_buffer,m_byteret,m_bytesrec);
				//check if there is any data remaining 
				//and append to m_byteret
				//
				return m_byteret;
			}
			
		}
		#endregion

		#region"WAI"
		private void m_tcpsend(string m_msg)
		{
			try
			{
				//send a small message to do a few tricks
//				string[] m_arr;
//				m_arr=m_msg.Split(new char[] {'t'});
//                m_msg=m_arr[0].ToString();
				int m_count=m_msg.Length;
				m_count=m_count-3;
				m_msg=m_msg.Substring(0,m_count);
				string m_send=m_msg;

				// send strings
//				System.Net.Sockets.NetworkStream m_socnetstream=new NetworkStream(m_mainsocket);
//				//streamwriter to write characters to a network stream
//				System.IO.StreamWriter m_sw=new StreamWriter(m_socnetstream);
//				m_sw.WriteLine(m_msg);
//				m_sw.Flush();
				//dont send bytes
				 //byte[] m_poll=System.Text.Encoding.ASCII.GetBytes(m_msg.ToCharArray());
				//but send strings
				System.Net.Sockets.NetworkStream m_socnetstream;
				System.IO.StreamWriter m_sw;
				
				foreach(m_clientsoc m_discOrcon in this.m_arrclients)
				{
					if(m_discOrcon.soc!=null)
					{
						if(m_discOrcon.soc.Connected)
						{
							m_socnetstream=new NetworkStream(m_discOrcon.soc);
							m_sw=new StreamWriter(m_socnetstream);
							m_sw.WriteLine(m_msg);
							m_sw.Flush();
							
						}

					}
				}
//				foreach(m_clientsoc m_clienttcp in  m_arrclients)
//				{
//					try
//					{
//
//						
//						
//						//m_clienttcp.soc.Send(/*m_arrRet*/m_poll);
//					}
//					catch(System.Exception ex)
//					{
//						try
//						{
//                        //MessageBox.Show("client disconnected"+m_client.soc.RemoteEndPoint.ToString());
//						m_clienttcp.soc.Close();//close disconnected socket
//						this.m_arrclients.Remove(m_clienttcp);//remove the socket from array of client connections
//						
//						return;
//						}
//						catch{}
//						
//
//					}
//				}
				
			}
			catch(System.Exception ex){string m_str=ex.Message.ToString();}
		}
		#endregion

		#region"databasecode"

		#region"private members"
		private ADODB.Connection bConn; //= new ADODB.Connection();
		private ADODB.Connection sConn;// = new ADODB.Connection();
		private ADODB.Connection pConn;// = new ADODB.Connection();
		private System.Windows.Forms.RichTextBox _rtbinit = new System.Windows.Forms.RichTextBox();
		public connectt.con cnn = new connectt.con();
		private  bool m_isinsert=false;
		string m_result="";
		private string dsn = "";
		//--------display error in parsefullstr
		// threading proper for retrieving mail
		public delegate void dretreivemail();
		//marshalling control
		public delegate void dmails();
		public System.Threading.Thread tretreivemail;/*a thread  */
		private string  _err="";
		//-------------------------------
		#endregion

		public void ParseFullSTR(string msg)
		{
			try 
			{
				//MessageBox.Show(msg); 
				Regex mySepChr = new Regex("(\r\n\0)");
				string[] RmcString = mySepChr.Split(msg);

				int RmcCount = Convert.ToInt32(RmcString.Length);
				string[] DataItems;
				string[] splitRmc;
				string[] uidSTR;
				string[] struid;
				Array myARR;
				//--------------davids code goes here
				//msg = "1:$<MSG.Info.ServerLogin>\r\n$DeviceName=BT0101\r\n$Software=steppII_2.3.13_final\r\n$Hardware=STEPPII-55\r\n$LastValidPosition=$GPRMC,071743.307,A,0120.4072,S,03654.9619,E,0.00,309.12,240706,,\r\n$IMEI=353563000048447\r\n$PhoneNumber=\r\n$LocalIP=172.23.211.226\r\n$CmdVersion=2\r\n$SUCCESS\r\n$<end>\r\n\0";
				_rtbinit.Clear();
				_rtbinit.Text = msg;
				string[] _arrinit;
				_arrinit = _rtbinit.Lines;
				string _str;
				char[] _splitChar = { ',' };
				if (_arrinit[0].ToString() == "1:$<MSG.Info.ServerLogin>")
				{
					_str = _arrinit[4];
					string[] _arrgprmc;
					_arrgprmc = _str.Split(_splitChar);
					DataItems = new string[7];
					string _lat; string _long; string _date;
					string _uid;
					_uid = _arrinit[1];
					char[] _splituid = { '=' };
					string[] _arruid; _arruid = _uid.Split(_splituid);
					_uid = _arruid[1];
					
					_arruid = _uid.Split(new char[] { '*' });
					_uid = _arruid[0].Trim();
					_lat = _arrgprmc[3];//_lat =Convert.ToString(Convert.ToDouble( _lat.Substring(0, 2)) + Convert.ToDouble(_lat.Substring(2))/60);
					_long = _arrgprmc[5];// _long = Convert.ToString(Convert.ToDouble(_long.Substring(0, 3)) + Convert.ToDouble(_long.Substring(3))/60);
					_date = "20" + Convert.ToString(_arrgprmc[9]).Substring(4) + "-" + Convert.ToString(_arrgprmc[9]).Substring(2, 2) + "-" + Convert.ToString(_arrgprmc[9]).Substring(0, 2);
					_date += " " + Convert.ToString(_arrgprmc[1]).Substring(0, 2) + ":" + Convert.ToString(_arrgprmc[1]).Substring(2, 2) + ":" + Convert.ToString(_arrgprmc[1]).Substring(4, 2);
					DataItems[0] = _date;
					DataItems[1] = _long;
					DataItems[2] = _lat;
					DataItems[4] = _arrgprmc[4];//S
					DataItems[3] = _arrgprmc[6];//E
//					try{_arrgprmc[7]=Convert.ToDouble(_arrgprmc[7].ToString().Trim())*3.6;}
//					catch{}
					DataItems[5] = _arrgprmc[7];//speed
					DataItems[6] = _arrgprmc[8];//course
					DateTime lastFix = CurrTime(_uid); // get The Latest FixTime
					//This is the new fixtime
					DateTime newFix = Convert.ToDateTime(DataItems.GetValue(0).ToString());
					/*first calculate the location*/
					string Loc = "";
					//try { Loc = location(DataItems); }
					//catch { }
					//location1
					try 
					{
						_lat = DataItems[2];_lat =Convert.ToString(Convert.ToDouble( _lat.Substring(0, 2)) + Convert.ToDouble(_lat.Substring(2))/60);
						_long = DataItems[1];_long = Convert.ToString(Convert.ToDouble(_long.Substring(0, 3)) + Convert.ToDouble(_long.Substring(3))/60);
						string LonZone = DataItems.GetValue(3).ToString();
						string LatZone = DataItems.GetValue(4).ToString();
						if (LonZone =="W") { _long = "-" + _long; }
						if (LatZone == "S") { _lat = "-" + _lat; } 
						DataItems[1]=_long; 
						DataItems[2]=_lat;

						//return text
						//Loc = location2(Convert.ToDouble(_long), Convert.ToDouble(_lat));
					}
					catch { }
					//pass string to create file
					try
					{
						string m_str="";
						m_str=_uid+"|"+DataItems[0].ToString()+"|";
						m_timespan=System.DateTime.Now;
						m_str+=m_timespan.Year.ToString()+"-"+m_timespan.Month.ToString()+"-"+m_timespan.Day.ToString()+" ";
						m_str+=m_timespan.Hour.ToString()+":"+m_timespan.Minute.ToString()+":"+m_timespan.Second.ToString()+"|";
						m_str+=DataItems[5].ToString()+"|";//speed
						m_str+=DataItems[6].ToString()+"|";//course
						m_str+=DataItems[1].ToString()+"|";//lon
						m_str+=DataItems[2].ToString()+"|";//lat
						this.m_createfiles(m_str,_uid);
					}
					catch{}
					

					splitRmc = null;
					uidSTR = null;
					DataItems = null;
					myARR = null;

					//GC.Collect();

				}
				else
				{
					//-----------------
					string _lat; string _long; 

					for (int i = 0; i < RmcCount; i++)
					{
						try
						{
							//MessageBox.Show(RmcString.GetValue(i).ToString());

							string singleRmcSTR = RmcString.GetValue(i).ToString();

							//Since We have parsed the Full STR and obtained a string
							//We now Want to split it further so that we can get
							//the unit id from the RMC 

							char[] splitChar = { '$' };
							char[] splitIDChar = { '\\' };
							//char[] splitComaChar = { ',' };
							//string[] splitRmc = singleRmcSTR.Split(splitChar);
							splitRmc = singleRmcSTR.Split(splitChar);
							//string[] uidSTR = splitRmc.GetValue(0).ToString().Split(splitIDChar);
							uidSTR = splitRmc.GetValue(1).ToString().Split(splitIDChar);


							string UID = "";
							//the UID is the second element of the array
							//only when its the first time time packets 
							//are being sent otherwise its the first element

							try { UID = uidSTR.GetValue(1).ToString(); }
							catch { UID = uidSTR.GetValue(0).ToString(); }

							struid = UID.Split(new Char[] { ',' });

							UID = struid[0].Trim();
							struid = UID.Split(new char[] { '*' });
							UID = struid[0].Trim();
							//string strh = UID.Split(splitComaChar);
							string RMC = splitRmc.GetValue(2).ToString();

							//Array myARR = RmcArray(RMC);
							myARR = RmcArray(RMC);

							//string[] DataItems = RequiredDataItemsOnly(myARR);
							DataItems = RequiredDataItemsOnly(myARR);
						
							//now Lets update the Database

							DateTime lastFix = CurrTime(UID); // get The Latest FixTime
							//This is the new fixtime
							DateTime newFix = Convert.ToDateTime(DataItems.GetValue(0).ToString());
							/*first calculate the location*/
							string Loc = "";
							//location1
							//try { Loc = location(DataItems); }
							//catch { }
							//location1
							try
							{
								_lat = DataItems[2]; _lat = Convert.ToString(Convert.ToDouble(_lat.Substring(0, 2)) + Convert.ToDouble(_lat.Substring(2)) / 60);
								_long = DataItems[1]; _long = Convert.ToString(Convert.ToDouble(_long.Substring(0, 3)) + Convert.ToDouble(_long.Substring(3)) / 60);
								string LonZone = DataItems.GetValue(3).ToString();
								string LatZone = DataItems.GetValue(4).ToString();
								if (LonZone =="W") { _long = "-" + _long; }
								if (LatZone == "S") { _lat = "-" + _lat; } 
								DataItems[1]=_long; 
								DataItems[2]=_lat;

								//return text
								//Loc = location2(Convert.ToDouble(_long), Convert.ToDouble(_lat));
							}
							catch { }
							try
							{
								string m_str="";
								m_str=UID+"|"+DataItems[0].ToString()+"|";
								m_timespan=System.DateTime.Now;
								m_str+=m_timespan.Year.ToString()+"-"+m_timespan.Month.ToString()+"-"+m_timespan.Day.ToString()+" ";
								m_str+=m_timespan.Hour.ToString()+":"+m_timespan.Minute.ToString()+":"+m_timespan.Second.ToString()+"|";
								m_str+=DataItems[5].ToString()+"|";//speed
								m_str+=DataItems[6].ToString()+"|";//course
								m_str+=DataItems[1].ToString()+"|";//lon
								m_str+=DataItems[2].ToString()+"|";//lat
								this.m_createfiles(m_str,UID);
							}
							catch{}

							splitRmc = null;
							uidSTR = null;
							DataItems = null;
							myARR = null;

							GC.Collect();
							GC.WaitForPendingFinalizers();

						}
						catch (Exception EX)
						{
							//An exception occurs because of the method we
							//have used to split the string
							//MessageBox.Show(EX.Message.ToString()); 
							splitRmc = null;
							uidSTR = null;
							DataItems = null;
							myARR = null;

							GC.Collect();
							GC.WaitForPendingFinalizers();

						}

					}
					RmcString = null;
				}

			}
			catch (System.Exception ex) 
			{}


		}

		public Array RmcArray(string rmcSTR)
		{
			char[] sepONE = { ',' };
			//string smsBody = fullSTR.GetValue(1).ToString();
			Array sBody = rmcSTR.Split(sepONE);

			for (int i = 0; i < sBody.Length; i++)
			{
				//MessageBox.Show(sBody.GetValue(i).ToString());
			}

			return sBody; 
		  
		 
		}
		public string[] RequiredDataItemsOnly(Array rawData)
		{
			/*
			string Sender = rawData.GetValue(1).ToString();
			char[] sepChar = { '"' };
			Array sArr = Sender.Split(sepChar);
			Sender = sArr.GetValue(1).ToString();
			*/

			string fTime = rawData.GetValue(1).ToString();
			string sec = Mid(fTime, 0, 2) + ":" + Mid(fTime, 2, 2) + ":" + Mid(fTime, 4, 2);
			fTime = sec;
			string fDate = rawData.GetValue(9).ToString();
			int tmpDate = Convert.ToInt32(fDate);
			if (tmpDate == 0)
			{
				/*
				char[] sepTwo = { '/' };
				string t = rawData.GetValue(3).ToString();
				int mLen = t.Length;
				t = Mid(t, 1, (mLen - 1));
				Array tD = t.Split(sepTwo);
				fDate = 2000 + Convert.ToInt32(tD.GetValue(0).ToString()) + "-" +
					tD.GetValue(1).ToString() + "-" + tD.GetValue(2).ToString();
				 */
				fDate = DateTime.Now.ToShortDateString();  
			}
			else
			{
				string fD = 2000 + Convert.ToInt32(Mid(fDate, 4, 2)) + "-" +
					Mid(fDate, 2, 2) + "-" + Mid(fDate, 0, 2);
				fDate = fD;
			}
			string Lon = rawData.GetValue(5).ToString();
			string LonZone = rawData.GetValue(6).ToString();
			string Lat = rawData.GetValue(3).ToString();
			string LatZone = rawData.GetValue(4).ToString();
			string Speed = rawData.GetValue(7).ToString();
//			try{Speed = Convert.ToString(Convert.ToDouble(Speed.ToString().Trim())*3.6);}
//			catch{}
			string Course = rawData.GetValue(8).ToString();  
			//we also need to add a speed value
			string[] tmpArr = {fDate + " " + fTime, Lon, Lat, LonZone, LatZone,Speed,Course};
			/*
			for (int x = 0; x < tmpArr.Length; x++)
			{
				MessageBox.Show(tmpArr.GetValue(x).ToString()); 
			}
			*/
			return tmpArr;
		}

		public string mRight(string mySTR, int length)
		{
			string MyString = mySTR;// txtTemp.Text;    
			string tmpstr = MyString.Substring(MyString.Length - length, length);
			return tmpstr;
		}
		public string mLeft(string mySTR, int length)
		{
			string myString = mySTR;
			string tempstr = myString.Substring(0, length);
			return tempstr;
		}
		public string Mid(string mySTR, int startIndex, int length)
		{
			string MyString = mySTR;// txtTemp.Text; 
			string tmpstr = MyString.Substring(startIndex, length);
			return tmpstr;
		}
		#region"error handlers"

		private void DisplayError()
		{
			try
			{
				this.rtberror.AppendText(_err + "\r\n");
					  
			}
			catch(System.Exception ep){string ser=ep.Message.ToString();}
			

		}
		private void _displayerror()
		{
			try
			{
				this.Invoke(new dmails(DisplayError), new object[] { });
			}
			catch (System.Exception er) { string ser = er.Message.ToString(); }
		  
		}
		#endregion

		#region Odbc Functions
		private bool IsPortAvailable()
		{
			try
			{
				pConn = new ADODB.Connection();
				string Constr = "DSN=ports;Server=localhost;Database=ports;UID=postgres;PWD=postgres;";
				pConn.ConnectionString = Constr;
				pConn.Mode = ADODB.ConnectModeEnum.adModeReadWrite;
				pConn.Open(null, null, null, 0);
				return true;
			}
			catch(Exception EX)
			{
				//MessageBox.Show(EX.ToString());
				return false;
			}

		}
		private bool SmsLogIsAvailable()
		{
			try
			{
				sConn = new ADODB.Connection();
				string cnnSTR = "DSN=SmsLog;Server=localhost;Initial Catalog=SmsLog;UID=postgres;PWD=postgres;";
				sConn.ConnectionString = cnnSTR;
				sConn.Mode = ADODB.ConnectModeEnum.adModeReadWrite;
				sConn.Open(null, null, null, 0);
				return true;
			}
			catch
			{
				return false;
			}

		}
		private bool BlueBaseIsAvailable()
		{
			try
			{
				bConn = new ADODB.Connection();
				string cnnSTR = "DSN="+dsn+";Server=localhost;Initial Catalog=dbase;UID=postgres;PWD=postgres;";
				bConn.ConnectionString = cnnSTR;
				bConn.Mode = ADODB.ConnectModeEnum.adModeReadWrite;
				bConn.Open(null, null, null, 0);
				return true;
			}
			catch(Exception ex)
			{
				//MessageBox.Show(ex.ToString());
				return false;
			}
		}
		private void killBlueBase() 
		{
			try 
			{
				bConn.Close();
				bConn = null; }
			catch (System.Exception ex) { string ser = ex.Message.ToString(); }
		
		}
		private void killSmsLog() 
		{
			try 
			{
				sConn.Close();
				sConn = null;}
			catch (System.Exception ex) { string ser = ex.Message.ToString(); }
		   
		}
		private void killports()
		{
			try 
			{
				pConn.Close();
				pConn = null;}
			catch (System.Exception ex) { string ser = ex.Message.ToString(); }
		   
		}
//		public void AcquirePort()
//		{
//			try 
//			{
//				if (IsPortAvailable())
//				  {
//					  try
//					  {
//						  string sqlSTR = "Select * from portid";
//						  ADODB.Recordset RST = new ADODB.Recordset();
//						  RST.Open(sqlSTR, pConn, ADODB.CursorTypeEnum.adOpenKeyset 
//							  , ADODB.LockTypeEnum.adLockOptimistic, 0);
//						  int count = RST.RecordCount;
//						  portArray = new string[count];
//						  if (RST.EOF == false)
//						  {
//							  int i = 0;
//							  while (RST.EOF == false)
//							  {
//								  Application.DoEvents();
//								  //RST.MoveFirst();
//								  portArray[i] = RST.Fields["portid"].Value.ToString();
//								  //MessageBox.Show(portArray[i].ToString());
//								  i = i + 1;
//								  RST.MoveNext();
//                            
//							  }
//						  }
//						  try { RST.Close(); }
//						  catch { }
//                  
//					  }
//					  catch(Exception EX)
//					  {
//						  MessageBox.Show(EX.Message.ToString());
//					  }
//					  finally
//					  {
//						  killports();
//					  }
//
//				  } 
//			}
//			catch (System.Exception ex) { string ser = ex.Message.ToString(); }
//           
//		}
		private bool IdExists(string UID)
		{

			bool found = false;
			if (BlueBaseIsAvailable())
			{
				try
				{
					string sqlSTR = "Select * from current_loc where lower(unitid) ='"
						+ UID.ToLower() + "'";
					//string sqlSTR = "Select * from current_loc where lower(unitid) ='bt0101'";
					ADODB.Recordset RST = new ADODB.Recordset();

					RST.Open(sqlSTR, bConn, ADODB.CursorTypeEnum.adOpenDynamic
						, ADODB.LockTypeEnum.adLockOptimistic, 0);

					if (RST.EOF == false)
					{
						found = true;
					}
					else { found = false; }
					try 
					{ 
						RST.Close();
						RST = null;
					}
					catch { }
				}
				catch (Exception EX)
				{
					//MessageBox.Show(EX.Message.ToString());
				}
				finally
				{
					killBlueBase();
				}

			}
			return found;
		}   
		private void AddNew(string ID,string[] record,string Loc)
		{
			bool sb = true;
			if (BlueBaseIsAvailable()/*sb == true*/)
			{
				try
				{

//					string fixtime = record.GetValue(0).ToString();
//					string Lon = record.GetValue(1).ToString();
//					string Lat = record.GetValue(2).ToString();
//
//					string LonZone = record.GetValue(3).ToString();
//					string LatZone = record.GetValue(4).ToString();
//
//					int latDegrees = (int)Convert.ToDouble(Lat) / 100;
//					double latMunites = Convert.ToDouble(Lat);
//					latMunites = latMunites - (latDegrees * 100);
//					double tmpLat = latDegrees + (latMunites / 60);
//
//					int lonDegrees = (int)Convert.ToDouble(Lon) / 100;
//					double lonMunites = Convert.ToDouble(Lon);
//					lonMunites = lonMunites - (lonDegrees * 100);
//					double tmpLon = lonDegrees + (lonMunites / 60);
//
//					if (LatZone.Equals("S"))
//					{
//						tmpLat = tmpLat * (-1);
//					}
//
//					if (LonZone.Equals("W"))
//					{
//						tmpLon = tmpLon * (-1);
//					}

					string Lon ="";string Lat ="";
					Lon = record[1].ToString();
					Lat = record[2].ToString();


					string theGeom = "GeometryFromText('POINT (" +
						Lon + " " + Lat + ")',-1)";

					string dbTime = DateTime.UtcNow.ToString();


					/*String sqlSTR = "Insert INTO Current_Loc(UnitId,RecTime,FixTime,dbTime,TransTime,Speed,Course,Text,gpsFix) values ('" +
						ID + "','" + dbTime + "','" + fixtime + "','" + dbTime + "','" + fixtime +"','"+record.GetValue(5).ToString() + 
						"','" + record.GetValue(6).ToString() +"','" + Loc + "'," + theGeom + ")";*/
					//----some really bad code

					//-------done with
					String sqlSTR = "Insert INTO Current_Loc(UnitId,FixTime,Speed,Course,Text,gpsFix) values ('" +
						ID + "','" + record[0] + "','"  +record[5].ToString() +
						"','" + record[6].ToString() + "','" + Loc + "'," + theGeom + ");";

					//ADODB.Recordset RST = new ADODB.Recordset();

					//RST.Open(sqlSTR, bConn, ADODB.CursorTypeEnum.adOpenDynamic
					//    , ADODB.LockTypeEnum.adLockOptimistic, 0);
					//string se = cnn.conn(dsn);
					m_result = cnn.execcute(sqlSTR);
//					if (result!="true")
//					{
//						_err = result;
//						tretreivemail = new System.Threading.Thread(new System.Threading.ThreadStart(this._displayerror));
//						tretreivemail.Priority = System.Threading.ThreadPriority.BelowNormal;
//						tretreivemail.Start();
//					}
					//cnn.shut();
					//System.GC.Collect();
				}
				catch (Exception EX)
				{
					//MessageBox.Show(EX.Message.ToString());
				}
				finally
				{
					killBlueBase();
				}
			}
		}
		private void UpdateArchive(string ID,string[] record,string Loc)
		{
			bool sb = true;
			if (/*BlueBaseIsAvailable()*/sb == true)
			{
				try
				{

					string fixtime = record.GetValue(0).ToString();
					string Lon = record.GetValue(1).ToString();
					string Lat = record.GetValue(2).ToString();

//					string LonZone = record.GetValue(3).ToString();
//					string LatZone = record.GetValue(4).ToString();
//
//
//					int latDegrees = (int)Convert.ToDouble(Lat) / 100;
//					double latMunites = Convert.ToDouble(Lat);
//					latMunites = latMunites - (latDegrees * 100);
//					double tmpLat = latDegrees + (latMunites / 60);
//
//					int lonDegrees = (int)Convert.ToDouble(Lon) / 100;
//					double lonMunites = Convert.ToDouble(Lon);
//					lonMunites = lonMunites - (lonDegrees * 100);
//					double tmpLon = lonDegrees + (lonMunites / 60);
//
//					if (LatZone.Equals("S"))
//					{
//						tmpLat = tmpLat * (-1);
//					}
//
//					if (LonZone.Equals("W"))
//					{
//						tmpLon = tmpLon * (-1);
//					}
				
					Lon = record[1].ToString();
					Lat = record[2].ToString();


					string theGeom = "GeometryFromText('POINT (" +
						Lon + " " + Lat + ")',-1)";
					/*
					String sqlSTR = "Insert INTO Archive_Loc(UnitId,FixTime,gpsFix) values ('" +
						ID + "','" + fixtime + "'," + theGeom + ")";
					*/

					string dbTime = DateTime.UtcNow.ToString();


					String sqlSTR = "Insert INTO archive_Loc(UnitId,RecTime,FixTime,dbTime,TransTime,Speed,Course,Text,gpsFix) values ('" +
						ID + "','" + record[4]+ "','" + record[0] + "','" + record[4] + "','" +  record[0]+ "','" +  record[5].ToString() +
						"','" +  record[6].ToString() + "','" + Loc + "'," + theGeom + ");";
				
					m_result = cnn.execcute(sqlSTR);
//					if (result != "true")
//					{
//						_err = result;
//						tretreivemail = new System.Threading.Thread(new System.Threading.ThreadStart(this._displayerror));
//						tretreivemail.Priority = System.Threading.ThreadPriority.BelowNormal;
//						tretreivemail.Start();
//					}
					//ADODB.Recordset RST = new ADODB.Recordset();

					//RST.Open(sqlSTR, bConn, ADODB.CursorTypeEnum.adOpenDynamic
					//    , ADODB.LockTypeEnum.adLockOptimistic, 0);
					//try { RST.Close(); }
					//catch { }
					//RST = null;
					//cnn.shut();
					//System.GC.Collect();
				}
				catch (Exception EX)
				{
					//MessageBox.Show(EX.Message.ToString());
				}
				finally
				{
					//killBlueBase();
				}
			}
		}
		private void UpdateCurrent(string ID,string[] record,string Loc)
		{
			try { }
			catch (System.Exception ex) { string ser = ex.Message.ToString(); }
			bool sb = true;
			if (/*BlueBaseIsAvailable()*/sb == true)
			{
				try
				{
//					string fixtime = record.GetValue(0).ToString();
//					string Lon = record.GetValue(1).ToString();
//					string Lat = record.GetValue(2).ToString();
//
//					string LonZone = record.GetValue(3).ToString();
//					string LatZone = record.GetValue(4).ToString();
//
//					int latDegrees = (int)Convert.ToDouble(Lat) / 100;
//					double latMunites = Convert.ToDouble(Lat);
//					latMunites = latMunites - (latDegrees * 100);
//					double tmpLat = latDegrees + (latMunites / 60);
//
//					int lonDegrees = (int)Convert.ToDouble(Lon) / 100;
//					double lonMunites = Convert.ToDouble(Lon);
//					lonMunites = lonMunites - (lonDegrees * 100);
//					double tmpLon = lonDegrees + (lonMunites / 60);
//
//					if (LatZone.Equals("S"))
//					{
//						tmpLat = tmpLat * (-1);
//					}
//
//					if (LonZone.Equals("W"))
//					{
//						tmpLon = tmpLon * (-1);
//					}
				string Lon ="";string Lat ="";
					Lon = record[1].ToString();
					Lat = record[2].ToString();


					string theGeom = "GeometryFromText('POINT (" +
						Lon + " " + Lat + ")',-1)";
					/*
					String sqlSTR = "Insert INTO Current_Loc(UnitId,FixTime,gpsFix) values ('" +
						ID + "','" + fixtime + "'," + theGeom + ")";
					 */

					string dbTime = DateTime.UtcNow.ToString();

					String sqlSTR = "Update Current_Loc Set fixtime ='" +
						record[0] + "',RecTime ='" + record[4]  + "',transtime ='" +
						record[0]  + "',dbTime = '" + record[4]  + "',gpsFix = " +
						theGeom + ",Speed = '" + record[5] .ToString() +
						"',Course = '" + record[6] .ToString() + "',Text ='" +
						Loc + "' where UnitID ='" + ID + "';";
					//string se = cnn.conn(dsn);
					m_result = cnn.execcute(sqlSTR);
//					if (result != "true")
//					{
//						_err = result;
//						tretreivemail = new System.Threading.Thread(new System.Threading.ThreadStart(this._displayerror));
//						tretreivemail.Priority = System.Threading.ThreadPriority.BelowNormal;
//						tretreivemail.Start();
//					}
					//cnn.shut();
					//System.GC.Collect();
				}
				catch (Exception EX)
				{
					//MessageBox.Show(EX.Message.ToString());
				}
				finally
				{
					//killBlueBase();
				}
			}
		}
		private DateTime CurrTime(string UID)
		{

			DateTime tempDate = Convert.ToDateTime("01/01/01");
			bool sb=true;
			if (/**/BlueBaseIsAvailable())
			{
				try
				{
					string sqlSTR = "Select * from Current_Loc where Unitid ='"
						+ UID + "'";

					ADODB.Recordset RST = new ADODB.Recordset();
					/*
					RST.Open(sqlSTR,bConn,ADODB.CursorTypeEnum.adOpenDynamic,
						ADODB.LockTypeEnum.adLockOptimistic,0);
					*/
					RST.Open(sqlSTR, bConn, ADODB.CursorTypeEnum.adOpenDynamic
						, ADODB.LockTypeEnum.adLockOptimistic, 0);

					if (RST.EOF == false)
					{
						RST.MoveFirst();
						tempDate = Convert.ToDateTime(RST.Fields["fixtime"].Value.ToString());
					}
					try { RST.Close(); }
					catch { }
				}
				catch (Exception EX)
				{
					//MessageBox.Show(EX.Message.ToString());
				}
				finally
				{
					killBlueBase();
				}
			}
			return tempDate;
		}
		#endregion

		#region MapObjects Functions
		private string location(string[] record)
		{
			double tmpLon = 0d;
			double tmpLat = 0d;
			try
			{
				string fixtime = record.GetValue(0).ToString();
				string Lon = record.GetValue(1).ToString();
				string Lat = record.GetValue(2).ToString();

				string LonZone = record.GetValue(3).ToString();
				string LatZone = record.GetValue(4).ToString();

				int latDegrees = (int)Convert.ToDouble(Lat) / 100;
				double latMunites = Convert.ToDouble(Lat);
				latMunites = latMunites - (latDegrees * 100);
				tmpLat = latDegrees + (latMunites / 60);

				int lonDegrees = (int)Convert.ToDouble(Lon) / 100;
				double lonMunites = Convert.ToDouble(Lon);
				lonMunites = lonMunites - (lonDegrees * 100);
				tmpLon = lonDegrees + (lonMunites / 60);

				if (LatZone.Equals("S"))
				{
					tmpLat = tmpLat * (-1);
				}

				if (LonZone.Equals("W"))
				{
					tmpLon = tmpLon * (-1);
				}


				Lon = tmpLon.ToString();
				Lat = tmpLat.ToString();
			}
			catch (System.Exception ex) { string ser = ex.Message.ToString(); }

			return distToPoi(tmpLon, tmpLat);
		}
		private string distToPoi(double Lon, double Lat)
		{
			string myLoc = "";
			if (BlueBaseIsAvailable())
			{
				try
				{
					MapObjects2.Point PoiX = new MapObjects2.Point();
					GeoCoordSys pcsGEO = new GeoCoordSys();
					ProjCoordSys pcsUTM = new ProjCoordSys();

					PoiX.X = Lon; PoiX.Y = Lat;
					/*
					object Poi = toObject(PoiX);
					object geo = geoObject(pcsGEO);
			 
					*/
					object PoiOne = pcsUTM.Transform(pcsGEO, PoiX, 0, 0);
					PoiX = (MapObjects2.Point)PoiOne;

					int tempLen = 1000000;
					string tempTown = "";

					ADODB.Recordset RST = new ADODB.Recordset();
					string sqlSTR = "SELECT town_name,the_geom FROM major_townsutm WHERE the_geom && 'BOX3D(" +
						(Lon - 0.5) + " " + (Lat - 0.5) + "," + (Lon + 0.5) + " " + (Lat + 0.5) +
						") '::box3d AND distance( the_geom, GeometryFromText( 'POINT(" + Lon + " " + Lat +
						")', -1 ) ) < 0.5";

					string sqlSTROther = "SELECT town_name,the_geom FROM major_townsutm WHERE the_geom && 'BOX3D(" +
						(Lon - 6) + " " + (Lat - 6) + "," + (Lon + 6) + " " + (Lat + 6) +
						") '::box3d AND distance( the_geom, GeometryFromText( 'POINT(" + Lon + " " + Lat +
						")', -1 ) ) < 7";

					RST.Open(sqlSTR, bConn, ADODB.CursorTypeEnum.adOpenDynamic,
						ADODB.LockTypeEnum.adLockBatchOptimistic, 0);

					if (RST.EOF == true)
					{
						try { RST.Close(); }
						catch { }
						RST.Open(sqlSTROther, bConn, ADODB.CursorTypeEnum.adOpenDynamic,
							ADODB.LockTypeEnum.adLockBatchOptimistic, 0);
					}

					if (RST.EOF == false)
					{
						RST.MoveFirst();
						while (RST.EOF == false)
						{
							string Coord = RST.Fields["the_geom"].Value.ToString();
							int Len = Coord.Length;
							Coord = mRight(Coord, (Len - 14));
							Len = Coord.Length;
							Coord = Mid(Coord, 0, (Len - 1));

							char[] SepChar = { ' ' };
							Array coordArray = Coord.Split(SepChar);

							double xlon = Convert.ToDouble(coordArray.GetValue(0).ToString());
							double xlat = Convert.ToDouble(coordArray.GetValue(1).ToString());

							MapObjects2.Point PoiY = new MapObjects2.Point();
							PoiY.X = xlon; PoiY.Y = xlat;


							object PoiTwo = pcsUTM.Transform(pcsGEO, PoiY, 0, 0);

							PoiY = (MapObjects2.Point)PoiTwo;

							double xLen = PoiY.DistanceTo(PoiX) / 1000;

							//MessageBox.Show(xLen.ToString());
							if (xLen < tempLen)
							{
								tempLen = Convert.ToInt32(xLen);
								tempTown = RST.Fields["town_name"].Value.ToString();
							}

							PoiY = null;
							coordArray = null;

							RST.MoveNext();
						}
						RST.Close();
						RST = null;
					
					}
					if (tempLen != 1000000)
					{
						myLoc = tempLen.ToString() + "Km From " + tempTown;
					}
					else
					{
						myLoc = "--------------";
					}
				}
				catch { myLoc = "--------------"; }
				finally
				{
					killBlueBase();
				}
			}
			return myLoc;
		}
		static object toObject(MapObjects2.Point poi)
		{
			return (object)poi;
		}
		static object geoObject(GeoCoordSys geo)
		{
			return (object)geo;
		}
		#endregion

		#region"geocode function"
		public string location2(double _lon,double _lat)
		{
			string m_str = "--------------";
			try 
			{
				bool _is = BlueBaseIsAvailable();
				if (_is==true )
				{
					Geocode _geo = new Geocode("KRoads", " major_townsutm", this.bConn, _lon, _lat);
					m_str = _geo.getAddress()+_geo.getRoadName();
				
				}
				return m_str;
		   
			}
			catch(System.Exception zx)
			{return m_str;}
		  
		}
		#endregion

		public void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				m_disc();
				m_con();
				
			}
			catch{}
		}

		
		#endregion

		#region"create files"
		private FileInfo m_fic;
		/// <summary>
		/// format of string unitid|fixtime|dbtime|speed|course|lon|lat
		/// </summary>
		/// <param name="m_pole"> string to be inserted</param>
		/// <param name="m_uid">unitid to
		///create file with a unitid as passed as a parameter</param>
		
		private void m_createfiles(string m_pole,string m_uid)
		{
			try
			{  string m_filename="";string m_path="";string m_destpath="";
			   System.DateTime m_date=new DateTime();
			   m_date=System.DateTime.Now;
			   m_filename=m_uid+m_date.Year+m_date.Month +m_date.Day+m_date.Hour+m_date.Minute+m_date.Second+m_date.Millisecond;
			   m_path=Application.StartupPath + "\\m_in\\"+m_filename+".ssa";
			   m_destpath=Application.StartupPath + "\\m_out\\"+m_filename+".ssa";

			   //create new file only once
			   m_fic=new FileInfo(m_path);
				if (!m_fic.Exists) 
				{
					//Create a file to write to.
					using (StreamWriter m_sw = m_fic.CreateText()) 
					{
						m_sw.WriteLine(m_pole);
						m_sw.Close();
					}	
					
				}
			  
			
			   //transfer file to folder specified
				
				try{
					m_fic.MoveTo(this.txtdest.Text.Trim().ToString()+"\\"+m_filename+".ssa");
					//File.Move(m_path,this.txtdest.Text.Trim().ToString()+"\\"+m_filename+".ssa");
				   }
				catch(System.Exception ex)
				{
					try{
						m_fic.MoveTo(m_destpath);
						//File.Move(m_path,m_destpath);
					}
					catch{}
				}
			  
			   System.GC.Collect();//force garbage collection of all generations

			}
			catch{}
	   
	 
		}
		#endregion

		#region"insert into db"
		public delegate void ddownload();
		public System.Threading.Thread tdownload;
		private void m_insert()
		{
			
//			timer2.Stop();
//			timer2.Enabled =false;
			try
			{
				dsn="BlueBaseV2";
				//dsn="dbase";
				string se = cnn.conn(dsn);
				if(se=="true")
				{
					try
					{
						DirectoryInfo dir = new DirectoryInfo("C:\\SocketPoles");
						
						FileInfo[] fileList = dir.GetFiles(); 
						System.IO.StreamReader  m_sr;
						string m_input="";
						string[] m_arr;
						string[] m_dataitems=new string[7];;
						string m_loc="----------";
						DateTime lastFix ;
						DateTime newFix;
						string m_file="";string m_dir="";
						foreach(FileInfo f in fileList)
						{
							try
							{
								// open file for read
								m_file=f.Name;
								m_dir=f.DirectoryName ;
								m_sr = new StreamReader(m_dir+"\\"+m_file);
								m_input=m_sr.ReadLine();
								m_sr.Close();

							
								m_arr=m_input.Split(new char[] {'|'});
								//format of string unitid|fixtime|dbtime|speed|course|lon|lat
								m_dataitems[5]=m_arr[3].ToString();;//speed
								m_dataitems[6]=m_arr[4].ToString();//course
								m_dataitems[1]=m_arr[5].ToString();//lon ;
								m_dataitems[2]=m_arr[6].ToString();//lat
								m_dataitems[0]=m_arr[1].ToString();//date
								m_dataitems[3]=m_arr[0].ToString();//unitid
								m_dataitems[4]=m_arr[2].ToString();//dbtime
								try{m_loc = location2(Convert.ToDouble(m_dataitems[1]), Convert.ToDouble(m_dataitems[2]));}
								catch{}
								
								lastFix = CurrTime(m_dataitems[3].ToString()); // get The Latest FixTime
								//This is the new fixtime
								newFix = Convert.ToDateTime(m_dataitems[0].ToString());
								m_result = "";
								if (IdExists(m_dataitems[3]))
								{
									//Not a new unit
									if (newFix > lastFix)
									{
										//New fix
										UpdateCurrent(m_dataitems[3], m_dataitems, m_loc); //Update Current Loc
										UpdateArchive(m_dataitems[3], m_dataitems, m_loc); //Update Archive Loc
									}
									else
									{
										//An Old Fix
										UpdateArchive(m_dataitems[3], m_dataitems, m_loc); //Update Archive Loc
									}
								}
								else
								{
									//New Unit
									AddNew(m_dataitems[3], m_dataitems, m_loc); // Add to current loc
									UpdateArchive(m_dataitems[3], m_dataitems, m_loc); // Add To Archive loc

								}
							}
							catch(System.Exception ex){string nb="";}
							try
							{
								FileInfo m_fimove;
								if(m_result=="true")
								{
									m_fimove=new FileInfo(m_dir+"\\"+m_file);
									m_fimove.MoveTo("C:\\SocketPoles\\Backup\\"+m_file);
									//File.Move(m_dir+"\\"+m_file,"C:\\SocketPoles\\Backup\\"+m_file);
								}
								else
								{
									m_fimove=new FileInfo(m_dir+"\\"+m_file);
									m_fimove.MoveTo("C:\\SocketPoles\\Unread\\"+m_file);
									//File.Move(m_dir+"\\"+m_file,"C:\\SocketPoles\\Unread\\"+m_file);
								}
								System.GC.Collect();
							}
							catch{}
										
							System.Windows.Forms.Application.DoEvents();
						}
						dir = null;
					}
					catch(System.Exception qa){}
					

				}

				
			}
			catch{}
			finally{/*timer2.Interval=1000;*/
					 cnn.shut();
					 
				   }
		}
		private void m_download()
		{
			try
			{
				this.Invoke(new ddownload(m_insert), new object[] { });
			}
			catch (System.Exception er) { string ser = er.Message.ToString(); }
			try{System.GC.Collect();}
			catch{}
		  
		}
		private void timer2_Tick(object sender, System.EventArgs e)
		{
			try
			{   
				if (!tdownload.IsAlive)
				{
					timer2.Interval=150000;
					tdownload = new System.Threading.Thread(new System.Threading.ThreadStart(m_download));
					tdownload.Priority = System.Threading.ThreadPriority.BelowNormal;
					tdownload.IsBackground=true;
					tdownload.Start();
				{}
				}
				else
				{timer2.Interval=150000;}
				
			
				
				

			}
			catch(System.Exception ex)
			{
				try
				{
					tdownload = new System.Threading.Thread(new System.Threading.ThreadStart(m_download));
					tdownload.Priority = System.Threading.ThreadPriority.BelowNormal;
					tdownload.IsBackground=true;
					tdownload.Start();
				}
				catch{}
			};
			

		}

		#endregion

				
	}
}
														
