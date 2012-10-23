using System;
using Euler.Problems;

namespace Euler {
	class Program {		
		static void Main(string[] args) {
			new EulerProblemEngine { Logging = true }.Run(new EulerProblem064(), RunModes.Test, BatchModes.None);
      Console.ReadLine();
		}							    																	
	}
}
