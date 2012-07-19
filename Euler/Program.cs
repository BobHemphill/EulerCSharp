using System;
using Euler.Problems;

namespace Euler {
	class Program {		
		static void Main(string[] args) {
			new EulerProblemEngine { Logging = true }.Run(new EulerProblem063(), RunModes.Solution, BatchModes.None);
      Console.ReadLine();
		}							    																	
	}
}
