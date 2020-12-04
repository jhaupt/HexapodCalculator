//Hexapod Leg Length Calculator
//Implements reverse kinematics analysis of a Stewart Platform from the paper "Kinematic Analysis of a Stewwart Platform Manipulator" by Liu, Fitzgerald, and Lewis
//J. Haupt -- 12/2020

using System;

namespace HexapodCalculator{
	class Program{
		static void Main(string[] args){
			bool run = true;
			
			Hexapod Hex1 = new Hexapod();
		
			Console.WriteLine("\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n~~~Welcome to HexapodCalculator~~~\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			Console.WriteLine("To calculate the leg lengths of a hexapod given platform position and tilt.");
			Console.WriteLine("\nREFER TO FIGURE1.PNG");

			Console.WriteLine("\n\nDefine the dimensions of the hexapod [cm]:");
			Console.Write("Enter the triangle side length of the platform (a): ");
			Hex1.a = double.Parse(Console.ReadLine());
			Console.Write("Enter the long length of the base hexagon (b): ");
			Hex1.b = double.Parse(Console.ReadLine());
			Console.Write("Enter the short of the base hexagon (d): ");
			Hex1.d = double.Parse(Console.ReadLine());
			Console.Write("Enter the leg thread pitch (turns per cm): ");
			Hex1.pitch = double.Parse(Console.ReadLine());

			Console.WriteLine("\nEnter the starting coordinates of the hexapod [degrees, cm]:");
			Console.Write("Platform angle about the x-axis (th_x): ");
			Hex1.th_x = double.Parse(Console.ReadLine());
			Console.Write("Platform angle about the y-axis (th_y): ");
			Hex1.th_y = double.Parse(Console.ReadLine());
			Console.Write("Platform angle about the z-axis (th_z): ");
			Hex1.th_z = double.Parse(Console.ReadLine());
			Console.Write("Platform x position (p_x): ");
			Hex1.p_x = double.Parse(Console.ReadLine());
			Console.Write("Platform y position (p_y): ");
			Hex1.p_y = double.Parse(Console.ReadLine());
			Console.Write("Platform z position (p_z): ");
			Hex1.p_z = double.Parse(Console.ReadLine());

			Hex1.Calc();
			Hex1.Display();
	
			do {
				Console.Write("\n\nNew platform angle about the x-axis (th_x): ");
				Hex1.th_x = double.Parse(Console.ReadLine());
				Console.Write("New platform angle about the y-axis (th_y): ");
				Hex1.th_y = double.Parse(Console.ReadLine());
				Console.Write("New platform angle about the z-axis (th_z): ");
				Hex1.th_z = double.Parse(Console.ReadLine());
				Console.Write("New platform x position (p_x): ");
				Hex1.p_x = double.Parse(Console.ReadLine());
				Console.Write("New platform y position (p_y): ");
				Hex1.p_y = double.Parse(Console.ReadLine());
				Console.Write("New platform z position (p_z): ");
				Hex1.p_z = double.Parse(Console.ReadLine());

				Hex1.Calc();
				Hex1.DisplayDelta();
			} while (run == true); 
			//Add while loop to read in successive changes to above and spit out deltas	

		}//end Main
	}
}
