using System;
using System.Collections.Generic;

namespace Euler.Problems {
	class EulerProblem064 : Problem {
		public EulerProblem064()
			: base(13, 4, 10000) {
			SolutionResponse = null;
		}


		public override object Run(RunModes runMode, object input, bool Logging) {
			var oddPeriodCount = 0;
			var upperBound = (int)input;
			var startA0 = 1;
			for (var i = 2; i <= upperBound; i++) {
				if (GetPeriod(i, ref startA0).PeriodLength % 2 == 1) oddPeriodCount++;
			}

			return oddPeriodCount;
		}

		SquareRootPeriod GetPeriod(int findSqrRootOf, ref int startA0) {
			if ((startA0 + 1) * (startA0 + 1) <= findSqrRootOf) startA0++;

			var period = new SquareRootPeriod { A0 = startA0 };
			return IncreasePeriod(findSqrRootOf, findSqrRootOf-(startA0*startA0), period);
		}

		SquareRootPeriod IncreasePeriod(int findSqrRootOf, int remainder, SquareRootPeriod period) {

			return period;
		}

		class SquareRootPeriod : List<int> {
			int? periodLength;
			public int PeriodLength {
				get {
					if (!periodLength.HasValue) {
						periodLength = GetPeriodLength();
					}
					return periodLength.Value;
				}
			}

			public int A0 { get; set; }

			private int GetPeriodLength() {
				throw new NotImplementedException();
			}
		}
	}
}