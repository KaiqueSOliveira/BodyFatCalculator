using System;


namespace BfCalculator
{
	
	class BfCalculator 
	{
		
			public static double Man (double abs, double neck, double height)
			{
				
				double bf = double.NaN;
				
				bf = 495/(1.0324 - (0.19077*(Math.Log10(abs - neck)))+(0.15456*(Math.Log10(height))))-450;
				
				return bf;
			}
			
			public static double Woman (double abs, double neck, double height , double hip)
			{
				
				double bf = double.NaN;
				
				bf = 495/(1.29579 - (0.35004*(Math.Log10(abs + hip - neck)))+(0.22100*(Math.Log10(height))))-450;
				
				return bf;
			}
	}
	
	class Program
	{
		static void Main (string[] args)
		{
			bool endApp = false;
			double bf = 0; 
			
			Console.WriteLine("-------------------");
			Console.WriteLine("-------------------");
			Console.WriteLine("Body Fat Calculator");
			Console.WriteLine("-------------------");
			Console.WriteLine("-------------------");
			
			while(!endApp)
			{
				
				string absInput = "";
				string neckInput = "";
				string heightInput = "";
				string hipInput = "";
			
				Console.WriteLine("What is your gender? w/m");
				string gen = Console.ReadLine();
				
				double abs = 0;
				while (!double.TryParse(absInput, out abs))
				{
					Console.WriteLine("Type your abs mesure");
					absInput = Console.ReadLine();
				}
				
				double neck = 0;
				while (!double.TryParse(neckInput, out neck))
				{
					Console.WriteLine("Type your neck mesure");
					neckInput = Console.ReadLine();
				}
			
				double height = 0;
				while (!double.TryParse(heightInput, out height))
				{
					Console.WriteLine("Type your height mesure");
					heightInput = Console.ReadLine();
				} 	
				
				if (gen == "w")
				{
					double hip = 0;
					while (!double.TryParse(hipInput, out hip))
					{
						Console.WriteLine("Type your hip mesure");
						hipInput = Console.ReadLine();
					}	
					
					try
					{
						bf = BfCalculator.Woman(abs, neck, height, hip);
						Console.WriteLine(String.Format("Your bf is {0}%",bf));
					}
					catch (Exception e)					
					{
						Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
					}
				}
				else
				{
					try
					{
						bf = BfCalculator.Man(abs,neck,height);
						Console.WriteLine(String.Format("Your bf is {0}%",bf));
					}
					catch (Exception e)
					{
						Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
					}
				}
				
				Console.WriteLine("Again? y/n");
				string anws = Console.ReadLine();
				
				if (anws == "n")
				{
					endApp = true;
				}				
			}
			
			return;
			
		}
		
	}
}