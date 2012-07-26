using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem063 : Problem {
		public EulerProblem063()
			: base(null, null, null) {
				SolutionResponse = 49;
		}


		public override object Run(RunModes runMode, object input, bool Logging) {
			var found = true;
			//1: 1,2,3,4,5,6,7,8,9
			//2: 4,5,6,7,8,9
			//3: 5,6,7,8,9

			var exp = 2;
			var expCount = 9;
			var lastStart = 1;
			BigInteger lowerBound = 10;			
			do {
				var i = lastStart;
				while (GetExp(i, exp) < lowerBound && i <= 9) {
					i++;
				}
				
				if(i<=9) {
					if (Logging) {
						Console.WriteLine(string.Format("{0}:{1}", exp, GetFoundString(i)));
					}
					expCount += 10 - i;
					lastStart = i;
					lowerBound *= 10;
					exp++;
				}
				else {
					found = false;
				}
			} while (found);
			return expCount;
		}

		private string GetFoundString(int i) {
			List<int> found = new List<int>();
			for (int j =i+1; j <= 9; j++) {
				found.Add(j);
			}
			return found.Aggregate(i.ToString(), (cur, n) => cur + "," + n.ToString());
		}

		BigInteger GetExp(int i, int exp) {
			BigInteger temp = i;
			for (int j = 0; j < exp-1; j++) {
				temp *= i;
			}
			return temp;
		}
	}
}
