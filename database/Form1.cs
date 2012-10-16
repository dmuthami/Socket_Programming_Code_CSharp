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

namespace database
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;

		public Form1()
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
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 262);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.timer2.Interval=100;
				timer2.Enabled=true;
				timer2.Start();

			}
			catch{}
		}

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
		public System.Threading.Thread tretreivemail;
		private System.Windows.Forms.Timer timer2;/*a thread  */
		private string  _err="";
		//-------------------------------
		#endregion

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
					DefaultNamespace.Geocode _geo = new DefaultNamespace.Geocode("KRoads", " major_townsutm", this.bConn, _lon, _lat);
					m_str = _geo.getAddress()+_geo.getRoadName();
                
				}
				return m_str;
           
			}
			catch(System.Exception zx)
			{return m_str;}
          
		}
		#endregion

	
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
			finally
			{/*timer2.Interval=1000;*/
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
					try{tdownload.Abort();}
					catch{}
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
					try{tdownload.Abort();}
					catch{}
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
