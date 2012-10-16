using System;
//using System.Collections.Generic;
using System.Text;

namespace DefaultNamespace
{
    public struct Position
    {
        private double x;
        private double y;
        private double z;
        public Position(double x, double y, double z)
        {    // constructor
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double X
        {                   // property
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

    }

    public class Geocode
    {
        public Geocode()
        {
        }
        public string roadsTableName = "";
        public string pointsTableName = "";
        public ADODB.Connection odbcDatabaseConnection;
        public double Lon;
        public double Lat;
        public Geocode(string roadsTableName, string pointsTableName,
        ADODB.Connection odbcDatabaseConnection, double Lon,
        double Lat)
        {
            this.roadsTableName = roadsTableName;
            this.pointsTableName = pointsTableName;
            this.odbcDatabaseConnection = odbcDatabaseConnection;
            this.Lon = Lon; this.Lat = Lat;
        }

        public string getRoadName()
        {
            try 
            {
                Position PoiX = new Position();
                PoiX.X = Lat; PoiX.Y = Lon;

                double tempLen = 1000000;
                string tempTown = "";

                ADODB.Recordset RST = new ADODB.Recordset();
                /* string sqlSTR = "SELECT name,the_geom FROM " + this.roadsTableName +" WHERE the_geom && 'BOX3D(" +
                     (Lon - 0.1) + " " + (Lat - 0.1) + "," + (Lon + 0.1) + " " + (Lat + 0.1) +
                     ") '::box3d AND distance( the_geom, GeometryFromText( 'POINT(" + Lon + " " + Lat +
                     ")', -1 ) ) < 0.11";

                 string sqlSTROther = "SELECT name,the_geom FROM " + this.roadsTableName + " WHERE the_geom && 'BOX3D(" +
                     (Lon - 1) + " " + (Lat - 1) + "," + (Lon + 1) + " " + (Lat + 1) +
                     ") '::box3d AND distance( the_geom, GeometryFromText( 'POINT(" + Lon + " " + Lat +
                     ")', -1 ) ) < 1.1";*/
                string sqlSTR = "SELECT rd_name,the_geom FROM kRoads WHERE the_geom && 'BOX3D(" +
                     (Lon - 0.1) + " " + (Lat - 0.1) + "," + (Lon + 0.1) + " " + (Lat + 0.1) +
                     ") '::box3d AND distance( the_geom, GeometryFromText( 'POINT(" + Lon + " " + Lat +
                     ")', -1 ) ) < 0.11";

                string sqlSTROther = "SELECT rd_name,the_geom FROM kRoads WHERE the_geom && 'BOX3D(" +
                    (Lon - 1) + " " + (Lat - 1) + "," + (Lon + 1) + " " + (Lat + 1) +
                    ") '::box3d AND distance( the_geom, GeometryFromText( 'POINT(" + Lon + " " + Lat +
                    ")', -1 ) ) < 1.1";

                RST.Open(sqlSTR, this.odbcDatabaseConnection, ADODB.CursorTypeEnum.adOpenDynamic,
                    ADODB.LockTypeEnum.adLockBatchOptimistic, 0);

                if (RST.EOF == true)
                {
                    try { RST.Close(); }
                    catch { }
                    RST.Open(sqlSTROther, this.odbcDatabaseConnection, ADODB.CursorTypeEnum.adOpenDynamic,
                        ADODB.LockTypeEnum.adLockBatchOptimistic, 0);
                }

                if (RST.EOF == false)
                {
                    RST.MoveFirst();
                    while (RST.EOF == false)
                    {
                        /*we are no longer dealing with a single point we are 
                         * dealind with a line string*/
                        string Coord = RST.Fields["the_geom"].Value.ToString();
                        int Len = Coord.Length;
                        Coord = Right(Coord, (Len - 25));
                        Len = Coord.Length;
                        Coord = Mid(Coord, 0, (Len - 2));

                        char[] SepChar = { ',' };
                        Array pointArray = Coord.Split(SepChar);

                        /*lets loop through the line string*/
                        for (int p = 0; p < pointArray.Length; p++)
                        {
                            try
                            {
                                char[] pointSep = { ' ' };
                                Array coordArray = pointArray.GetValue(p).ToString().Split(pointSep);
                                double xlon = Convert.ToDouble(coordArray.GetValue(0).ToString());
                                double xlat = Convert.ToDouble(coordArray.GetValue(1).ToString());

                                Position PoiY = new Position();
                                PoiY.X = xlat; PoiY.Y = xlon;

                                Calculations calc = new Calculations();
                                double xLen = 10000001;
                                try { xLen = calc.CalculateDistace(PoiX, PoiY); }
                                catch { }
                                calc = null;

                                //MessageBox.Show(xLen.ToString());
                                if (xLen < tempLen)
                                {
                                    tempLen = xLen;
                                    if (tempLen > 0.5)
                                    { tempTown = " Along Unknown Road"; }
                                    else
                                    { tempTown = " Along " + RST.Fields["rd_name"].Value.ToString(); }
                                }

                                //PoiY = null;
                                coordArray = null;
                                //Application.DoEvents();
                            }
                            catch { }
                        }
                        //Application.DoEvents();
                        RST.MoveNext();
                    }
                    RST.Close();
                    RST = null;
                }
                if (tempLen != 1000000)
                {
                    return tempTown;
                }
                else
                {
                    return " ";
                }
            }
            catch (System.Exception qw) { return " "; }
           
        }
        public string getAddress()
        {
            try
            {
                Position PoiX = new Position();

                PoiX.X = Lat; PoiX.Y = Lon;

                double tempLen = 1000000;
                string tempTown = "";

                ADODB.Recordset RST = new ADODB.Recordset();
                string sqlSTR = "SELECT name,the_geom FROM mergedpoints WHERE the_geom && 'BOX3D(" +
                    (Lon - 0.5) + " " + (Lat - 0.5) + "," + (Lon + 0.5) + " " + (Lat + 0.5) +
                    ") '::box3d AND distance( the_geom, GeometryFromText( 'POINT(" + Lon + " " + Lat +
                    ")', -1 ) ) < 0.5";

                string sqlSTROther = "SELECT name,the_geom FROM mergedpoints WHERE the_geom && 'BOX3D(" +
                    (Lon - 6) + " " + (Lat - 6) + "," + (Lon + 6) + " " + (Lat + 6) +
                    ") '::box3d AND distance( the_geom, GeometryFromText( 'POINT(" + Lon + " " + Lat +
                    ")', -1 ) ) < 7";

                RST.Open(sqlSTR, this.odbcDatabaseConnection, ADODB.CursorTypeEnum.adOpenDynamic,
                    ADODB.LockTypeEnum.adLockBatchOptimistic, 0);

                if (RST.EOF == true)
                {
                    try { RST.Close(); }
                    catch { }
                    RST.Open(sqlSTROther, this.odbcDatabaseConnection, ADODB.CursorTypeEnum.adOpenDynamic,
                        ADODB.LockTypeEnum.adLockBatchOptimistic, 0);
                }

                if (RST.EOF == false)
                {
                    RST.MoveFirst();
                    while (RST.EOF == false)
                    {
                        string Coord = RST.Fields["the_geom"].Value.ToString();
                        int Len = Coord.Length;
                        Coord = Right(Coord, (Len - 14));
                        Len = Coord.Length;
                        Coord = Mid(Coord, 0, (Len - 1));

                        char[] SepChar = { ' ' };
                        Array coordArray = Coord.Split(SepChar);

                        double xlon = Convert.ToDouble(coordArray.GetValue(0).ToString());
                        double xlat = Convert.ToDouble(coordArray.GetValue(1).ToString());

                        Position PoiY = new Position();
                        PoiY.X = xlat; PoiY.Y = xlon;

                        Calculations calc = new Calculations();
                        double xLen = calc.CalculateDistace(PoiX, PoiY);

                        //MessageBox.Show(xLen.ToString());
                        if (xLen < tempLen)
                        {
                            tempLen = xLen;
                            tempTown = RST.Fields["name"].Value.ToString();
                        }

                        //PoiY = null;
                        coordArray = null;
                        RST.MoveNext();
                    }
                    RST.Close();
                    RST = null;
                }
                if (tempLen != 1000000)
                {
                    string retVal = Decimal.Round((decimal)tempLen, 3).ToString();
                    return retVal + "Km From " + tempTown;
                }
                else
                {
                    return " ";
                }
            }
            catch (System.Exception qw) { return " "; }
           
        }

        private string Right(string STR, int length)
        {
            string MyString = STR;// txtTemp.Text;    
            string tmpstr = MyString.Substring(MyString.Length - length, length);
            return tmpstr;
        }

        private string Mid(string STR, int startIndex, int length)
        {
            string MyString = STR;// txtTemp.Text; 
            string tmpstr = MyString.Substring(startIndex, length);
            return tmpstr;
        }
    }
}
