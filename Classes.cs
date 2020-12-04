using System;

namespace HexapodCalculator{
	class Hexapod{
		private const double sqrt3 = 1.7320508;		//The value of sqrt(3)
		private const double rads60 = Math.PI/3;	//The value of 60 degrees in rads
		public double a;
		public double b;
		public double d;
		public double th_x;
		public double th_y;
		public double th_z;
		public double p_x;
		public double p_y;
		public double p_z;
		public double pitch;
		public double L1;
		public double L2;
		public double L3;
		public double L4;
		public double L5;
		public double L6;
		public double L1prev;
		public double L2prev;
		public double L3prev;
		public double L4prev;
		public double L5prev;
		public double L6prev;
		
		public void Calc(){
			//Convert degrees to rads:
			th_x = th_x*(Math.PI/180);
			th_y = th_y*(Math.PI/180);
			th_z = th_z*(Math.PI/180);

			//Calc prelminary eqs. 2-10:
			double X_T1 = p_x + (a/sqrt3)*( (Math.Sin(th_x)*Math.Sin(th_y)*Math.Sin(th_z+rads60)) + (Math.Cos(th_y)*Math.Cos(th_z+rads60)) );
			double Y_T1 = p_y + (a/sqrt3)*( Math.Cos(th_x)*Math.Sin(th_z + rads60) );
			double Z_T1 = p_z + (a/sqrt3)*( (Math.Sin(th_x)*Math.Cos(th_y)*Math.Sin(th_z+rads60)) - (Math.Sin(th_y)*Math.Cos(th_z+rads60)) );
			double X_T2 = p_x - (a/sqrt3)*( (Math.Sin(th_x)*Math.Sin(th_y)*Math.Sin(th_z)) + (Math.Cos(th_y)*Math.Cos(th_z)) );
			double Y_T2 = p_y - (a/sqrt3)*Math.Cos(th_x)*Math.Sin(th_z);
			double Z_T2 = p_z - (a/sqrt3)*( (Math.Sin(th_x)*Math.Cos(th_y)*Math.Sin(th_z)) - (Math.Sin(th_y)*Math.Cos(th_z)) );
			double X_T3 = p_x + (a/sqrt3)*( (Math.Sin(th_x)*Math.Sin(th_y)*Math.Sin(th_z - rads60)) + (Math.Cos(th_y)*Math.Cos(th_z-rads60)) );
			double Y_T3 = p_y + (a/sqrt3)*Math.Cos(th_x)*Math.Sin(th_z-rads60);
			double Z_T3 = p_z + (a/sqrt3)*( (Math.Sin(th_x)*Math.Cos(th_y)*Math.Sin(th_z-rads60)) - (Math.Sin(th_y)*Math.Cos(th_z-rads60)) );
			
			//Calc leg lengths, eqs. 11-16
			L1 = Math.Sqrt( Math.Pow(X_T1-(d/(2*sqrt3))-(b/sqrt3),2) + Math.Pow(Y_T1-(d/2),2) + Math.Pow(Z_T1,2));
			L2 = Math.Sqrt( Math.Pow(X_T1-(d/(2*sqrt3))+(b/(2*sqrt3)),2) + Math.Pow(Y_T1-(d/2)-(b/2),2) + Math.Pow(Z_T1,2));
			L3 = Math.Sqrt( Math.Pow(X_T2+(d/sqrt3)+(b/(2*sqrt3)),2) + Math.Pow(Y_T2-(b/2),2) + Math.Pow(Z_T2,2));
			L4 = Math.Sqrt( Math.Pow(X_T2+(d/sqrt3)+(b/(2*sqrt3)),2) + Math.Pow(Y_T2+(b/2),2) + Math.Pow(Z_T2,2));
			L5 = Math.Sqrt( Math.Pow(X_T3-(d/(2*sqrt3))+(b/(2*sqrt3)),2) + Math.Pow(Y_T3+(b/2)+(d/2),2) + Math.Pow(Z_T3,2));
			L6 = Math.Sqrt( Math.Pow(X_T3-(d/(2*sqrt3))-(b/sqrt3),2) + Math.Pow(Y_T3+(d/2),2) + Math.Pow(Z_T3,2));
		}

		public void Display(){
			Console.WriteLine("\nLeg lengths:");
			Console.WriteLine("L1 = {0}cm", L1);
			Console.WriteLine("L2 = {0}cm", L2);
			Console.WriteLine("L3 = {0}cm", L3);
			Console.WriteLine("L4 = {0}cm", L4);
			Console.WriteLine("L5 = {0}cm", L5);
			Console.WriteLine("L6 = {0}cm", L6);
			L1prev = L1;
			L2prev = L2;
			L3prev = L3;
			L4prev = L4;
			L5prev = L5;
			L6prev = L6;
		}

		public void DisplayDelta(){
			Console.WriteLine("\nDeltas: ");
			Console.WriteLine("L1_delta = {0} (that's {1} turns)", L1-L1prev, (L1-L1prev)*pitch);
			Console.WriteLine("L2_delta = {0} (that's {1} turns)", L2-L2prev, (L2-L2prev)*pitch);
			Console.WriteLine("L3_delta = {0} (that's {1} turns)", L3-L3prev, (L3-L3prev)*pitch);
			Console.WriteLine("L4_delta = {0} (that's {1} turns)", L4-L4prev, (L4-L4prev)*pitch);
			Console.WriteLine("L5_delta = {0} (that's {1} turns)", L5-L5prev, (L5-L5prev)*pitch);
			Console.WriteLine("L6_delta = {0} (that's {1} turns)", L6-L6prev, (L6-L6prev)*pitch);
			Console.WriteLine("\nNew leg lengths:");
			Console.Write("L1 = ");
			Console.WriteLine(L1);
			Console.Write("L2 = ");
			Console.WriteLine(L2);
			Console.Write("L3 = ");
			Console.WriteLine(L3);
			Console.Write("L4 = ");
			Console.WriteLine(L4);
			Console.Write("L5 = ");
			Console.WriteLine(L5);
			Console.Write("L6 = ");
			Console.WriteLine(L6);
		}
	}
}
