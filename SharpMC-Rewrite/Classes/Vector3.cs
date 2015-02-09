﻿using System;
using System.Net;

namespace SharpMCRewrite
{
    public class Vector3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3 (double _X, double _Y, double _Z)
        {
            X = _X;
            Y = _Y;
            Z = _Z;
        }

        public string GetString()
        {
            return X + ", " + Y + ", " + Z;
        }

        public void ConvertToNetwork()
        {
            X = HostToNetworkOrder (X);
            Y = HostToNetworkOrder (Y);
            Z = HostToNetworkOrder (Z);
        }

        public void ConvertToHost()
        {
            X = NetworkToHostOrder (X);
            Y = NetworkToHostOrder (Y);
            Z = NetworkToHostOrder (Z);
        }

        private double HostToNetworkOrder(double d)
        {
            byte[] data = BitConverter.GetBytes(d);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }
            return BitConverter.ToDouble(data, 0);
        }

        private double NetworkToHostOrder(double d)
        {
            byte[] data = BitConverter.GetBytes(d);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(data);
            return BitConverter.ToDouble(data, 0);
        }
            
        public double DistanceBetween(Vector3 other)
        {
            return Math.Sqrt(Square(other.X - X) +
                Square(other.Y - Y) +
                Square(other.Z - Z));
        }

        private double Square(double num)
        {
            return num * num;
        }

    }

    public class INTVector3
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public INTVector3 (int _X, int _Y, int _Z)
        {
            X = _X;
            Y = _Y;
            Z = _Z;
        }
    }
}
