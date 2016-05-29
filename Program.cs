
using System;
using System.Text;
using System.Timers;

namespace ConsoleFifteen
{
	class Program
	{
		private static int [,] arr = new int [4,4];
		private static Timer tim = new Timer();
		private static DateTime time = DateTime.Now;
		
		public static void Main(string[] args)
		{
			NewGame();
			tim.Elapsed += delegate {Raskl();};
			tim.Interval = 1000;
			Console.TreatControlCAsInput = true;
			ConsoleKeyInfo cki = new ConsoleKeyInfo();
			do
			{
				if (Console.KeyAvailable)
				{
					cki = Console.ReadKey(true);
					if (cki.Key == ConsoleKey.Home)
					{
						NewGame();
					}
					if (tim.Enabled)
					{
						int x = 0;
						int y = 0;
						if (cki.Key == ConsoleKey.LeftArrow)
						{
							x = -1;
							if((cki.Modifiers & ConsoleModifiers.Shift) != 0) x = -3;
		         			if((cki.Modifiers & ConsoleModifiers.Control) != 0) x = -2;
		         			Move(x, y);
						}
						if (cki.Key == ConsoleKey.RightArrow)
						{
							x = 1;
							if((cki.Modifiers & ConsoleModifiers.Shift) != 0) x = 3;
		         			if((cki.Modifiers & ConsoleModifiers.Control) != 0) x = 2;
		         			Move(x, y);
						}
						if (cki.Key == ConsoleKey.UpArrow)
						{
							y = -1;
							if((cki.Modifiers & ConsoleModifiers.Shift) != 0) y = -3;
		         			if((cki.Modifiers & ConsoleModifiers.Control) != 0) y = -2;
		         			Move(x, y);
						}
						if (cki.Key == ConsoleKey.DownArrow)
						{
							y = 1;
							if((cki.Modifiers & ConsoleModifiers.Shift) != 0) y = 3;
		         			if((cki.Modifiers & ConsoleModifiers.Control) != 0) y = 2;
		         			Move(x, y);
						}
					}
				}
			} while (cki.Key != ConsoleKey.Escape);
		}
		
		private static void NewGame()
		{
			tim.Start();
			time = DateTime.Now;
			Random r = new Random();
			bool flag = false;
			int tmp;
			tmp = r.Next(16);
			for (int i=0;i<=3;i++){
				for (int j=0;j<=3;j++){
					if ((i != 0) || (j != 0)){
						do {
							flag = false;
							tmp = r.Next(16);
							for (int k=0;k<=i;k++){
								if (k<i){
									for (int l=0;l<=3;l++){
										if (arr [k,l] == tmp) {flag = true;}
									}
								} else {
									for (int l=0;l<j;l++){
										if (arr [k,l] == tmp) {flag = true;}
									}
								}
							}
						}
						while (flag == true);
					}
					arr [i,j] = tmp;
				}
			}
			Raskl();
		}
		
		private static void Raskl(){
			string ot = "                             ";
			Console.Clear();
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write(ot + Encoding.GetEncoding(866).GetString(new byte[] {201, 205, 205, 205, 205, 209, 205, 205, 205, 205, 209, 205, 205, 205, 205, 209, 205, 205, 205, 205, 187}));
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine(" " + ((TimeSpan)(DateTime.Now - time)).ToString(@"hh\:mm\:ss"));
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			for (int i=0;i<=3;i++){
				Console.WriteLine(ot + Encoding.GetEncoding(866).GetString(new byte[] {186, 32, 32, 32, 32, 179, 32, 32, 32, 32, 179, 32, 32, 32, 32, 179, 32, 32, 32, 32, 186}));
				Console.Write(ot + Encoding.GetEncoding(866).GetString(new byte[] {186}));
				for (int j=0;j<=3;j++){
					if ((arr [i,j] < 10) && (arr [i,j] != 0))
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("  " + arr [i,j].ToString());
						Console.ForegroundColor = ConsoleColor.DarkGreen;
					}
					else
					{
						if (arr [i,j] == 0)
						{
							Console.Write("   ");
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write(" " + arr [i,j].ToString());
							Console.ForegroundColor = ConsoleColor.DarkGreen;
						}
					}
					if (j < 3) Console.Write(" " + Encoding.GetEncoding(866).GetString(new byte[] {179}));
						else Console.Write(" ");
				}
				Console.Write(Encoding.GetEncoding(866).GetString(new byte[] {186}));
				Console.WriteLine("");
				Console.WriteLine(ot + Encoding.GetEncoding(866).GetString(new byte[] {186, 32, 32, 32, 32, 179, 32, 32, 32, 32, 179, 32, 32, 32, 32, 179, 32, 32, 32, 32, 186}));
				if (i < 3) Console.WriteLine(ot + Encoding.GetEncoding(866).GetString(new byte[] {199, 196, 196, 196, 196, 197, 196, 196, 196, 196, 197, 196, 196, 196, 196, 197, 196, 196, 196, 196, 182}));
			}
			Console.WriteLine(ot + Encoding.GetEncoding(866).GetString(new byte[] {200, 205, 205, 205, 205, 207, 205, 205, 205, 205, 207, 205, 205, 205, 205, 207, 205, 205, 205, 205, 188}));
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine(ot + "(" + Encoding.GetEncoding(866).GetString(new byte[] {24, 25, 26, 27}) + ")___________Move");
			Console.WriteLine(ot + "(CTRL+" + Encoding.GetEncoding(866).GetString(new byte[] {24, 25, 26, 27}) + ")____Move 2");
			Console.WriteLine(ot + "(SHIFT+" + Encoding.GetEncoding(866).GetString(new byte[] {24, 25, 26, 27}) + ")___Move 3");
			Console.WriteLine(ot + "(Home)_______New game");
			Console.WriteLine(ot + "(Esc)____________Exit");
		}
		
		private static bool Prov(){
			int pr = 1;
			bool ver = true;
			for (int i=0;i<=3;i++){
				for (int j=0;j<=3;j++){
					if (((arr[i,j] != pr) && (pr < 14)) || (arr[3,3] != 0)) ver = false;
					pr++;
				}
			}
			return ver;
		}
		
		private static void Move(int xn, int yn)
		{
			int x = 0;
			int y = 0;
			for (int i=0;i<=3;i++){
				for (int j=0;j<=3;j++){
					if (arr[i,j] == 0)
					{
						x = j;
						y = i;
					}
				}
			}
			x -= xn; 
			y -= yn;
			if ((x >= 0 && x <= 3) && (y >= 0 && y <= 3))
			{
				int arrx = 0;
				int arry = 0;
				int ar0x = 0;
				int ar0y = 0;
				
				for (int i=0;i<=3;i++){
					for (int j=0;j<=3;j++){
						if (arr[i,j] == arr[y,x]){
							arrx = i;
							arry = j;
							break;
						}
					}
				}
				for (int i=0;i<=3;i++){
					for (int j=0;j<=3;j++){
						if (arr[i,j] == 0){
							ar0x = i;
							ar0y = j;
							break;
						}
					}
				}
				if (arrx == ar0x){
					if (ar0y > arry){
						for (int i=ar0y;i>arry;i--){
							arr[arrx,i] = arr[arrx,i-1];
						}
					}
					if (ar0y < arry){
						for (int i=ar0y;i<arry;i++){
							arr[arrx,i] = arr[arrx,i+1];
						}
					}
					arr[arrx,arry] = 0;
				}
				if (arry == ar0y){
					if (ar0x > arrx){
						for (int i=ar0x;i>arrx;i--){
							arr[i,arry] = arr[i-1,arry];
						}
					}
					if (ar0x < arrx){
						for (int i=ar0x;i<arrx;i++){
							arr[i,arry] = arr[i+1,arry];
						}
					}
					arr[arrx,arry] = 0;
				}
				Raskl();
				if (Prov())	tim.Stop();
			}
		}
	}
}