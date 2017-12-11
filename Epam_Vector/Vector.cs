using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam_Log_library;


namespace Epam_Vector
{
    /// <summary>
    /// Class represents a vector
    /// </summary>
    class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public ILogger loger;

        /// <summary>
        /// constructor for vector
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="z">z coordinate</param>
        public Vector (double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            loger = LoggerChoise.GetLogger(ConfigFromFile.GetFormatLogger());
        }
        /// <summary>
        /// Overrided method ToString() for vector
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            try
            {
                return "{ " + X + ", " + Y + ", " + Z +" }";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                loger.Log(ex.Message, levels.error, this);
                return null;
            }
        }
        /// <summary>
        /// method for calculating length 
        /// </summary>
        /// <returns></returns>
        public double Lenght()
        {
            try
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                loger.Log(ex.Message, levels.error, this);
                return 0;
            }
        }
        /// <summary>
        /// Add two vectors
        /// </summary>
        /// <param name="v">vector</param>
        /// <returns></returns>
        public Vector Add (Vector v)
        {
            try
            {
                //example write to log file with loger from Epam_Log_library
                string str = "Add vectors" + this.ToString() + " and " + v.ToString() + " with rezult " + new Vector(X + v.X, Y + v.Y, Z + v.Z).ToString();
                loger.Log(str, levels.info, this);
                return new Vector(X + v.X, Y + v.Y, Z + v.Z);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                loger.Log(ex.Message, levels.error, this);
                return null;
            }
        }
        /// <summary>
        /// Overloaded operator +
        /// </summary>
        /// <param name="v1">vector</param>
        /// <param name="v2">vector</param>
        /// <returns></returns>
        public static Vector operator + (Vector v1, Vector v2)
        {
            try
            {
                return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Substract two vectors
        /// </summary>
        /// <param name="v">vector</param>
        /// <returns></returns>
        public Vector Subs(Vector v)
        {
            try
            {
                return new Vector(X - v.X, Y - v.Y, Z - v.Z);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                loger.Log(ex.Message, levels.error, this);
                return null;
            }
        }
        /// <summary>
        /// Overloaded operator -
        /// </summary>
        /// <param name="v1">vector</param>
        /// <param name="v2">vector</param>
        /// <returns></returns>
        public static Vector operator - (Vector v1, Vector v2)
        {
            try
            {
                return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Scalar multiplication
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public double MultScalar(Vector v)
        {
            try
            {
                return (X * v.X + Y * v.Y + Z * v.Z);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                loger.Log(ex.Message, levels.error, this);
                return 0;
            }
        }
        /// <summary>
        /// Vector multiplication
        /// </summary>
        /// <param name="v">vector</param>
        /// <returns></returns>
        public Vector MultVector(Vector v)
        {
            try
            {
                return new Vector(Y * v.Z - Z * v.Y, Z * v.X - X * v.Z, X * v.Y - Y * v.X);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                loger.Log(ex.Message, levels.error, this);
                return null;
            }
        }
        /// <summary>
        /// Overloaded operator *
        /// </summary>
        /// <param name="v1">vector</param>
        /// <param name="v2">vector</param>
        /// <returns></returns>
        public static Vector operator *(Vector v1, Vector v2)
        {
            try
            {
                return new Vector(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Mixed multiplication
        /// </summary>
        /// <param name="v1">vector</param>
        /// <param name="v2">vector</param>
        /// <returns></returns>
        public double MultMixed(Vector v1, Vector v2)
        {
            try
            {
                return this.MultScalar(v1 * v2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                loger.Log(ex.Message, levels.error, this);
                return 0;
            }
        }
        /// <summary>
        /// Cosinus of the angle between two vectors
        /// </summary>
        /// <param name="v">vector</param>
        /// <returns></returns>
        public double CosAngle(Vector v)
        {
            try
            {
                return this.MultScalar(v) / (this.Lenght() * v.Lenght());
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Divide by zero");
                loger.Log(ex.Message, levels.error, this);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                loger.Log(ex.Message, levels.error, this);
                return 0;
            }
        }
        /// <summary>
        /// Comparison of two vectors
        /// </summary>
        /// <param name="v">vector</param>
        /// <returns></returns>
        public bool isEqual(Vector v)
        {
            try
            {
                return X == v.X && Y == v.Y;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                loger.Log(ex.Message, levels.error, this);
                return false;
            }
        }
    }
}
