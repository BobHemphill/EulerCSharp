using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem062 : Problem {
		public EulerProblem062()
			: base(null, null, null) {
				SolutionResponse = (long)127035954683;
		}

		public static Dictionary<int, Dictionary<PermutationKey, List<long>>> CubesPermutationDictionary = new Dictionary<int, Dictionary<PermutationKey, List<long>>>();

		public override object Run(RunModes runMode, object input, bool Logging) {
			var currentSeed = 345;
			while (true) {
				var nextSeed = SeedCubes(currentSeed);


				if (Logging) {
					Console.WriteLine(string.Format("Starting Seed:{0}...\n", currentSeed));
				}
				foreach (var kvp in CubesPermutationDictionary[currentSeed]) {
					if (kvp.Value.Count == 5) return kvp.Value.Min();
				}
				
				if (Logging) {
					Console.WriteLine(string.Format("Ending Seed:{0}\nNext Seed{1}...\n", currentSeed, nextSeed));
					Console.ReadLine();
				}
				currentSeed = nextSeed;
			}
		}

		int SeedCubes(int seed) {
			var cube = (long)Math.Pow(seed, 3);
			var length = cube.ToString().Length;
			int tempLength;
			int tempSeed = seed;
			CubesPermutationDictionary.Add(tempSeed, new Dictionary<PermutationKey, List<long>>());
			do {
				var tempCube = (long)Math.Pow(seed, 3);
				tempLength = tempCube.ToString().Length;
				if (tempLength == length)
					AddCubeToDictionary(tempSeed, tempCube);
				seed++;
			} while (tempLength == length);
			return seed;
		}

		void AddCubeToDictionary(int seed, long cube) {
			var key = Permutations.CreateKey(cube);
			if (CubesPermutationDictionary[seed].ContainsKey(key)) {
				CubesPermutationDictionary[seed][key].Add(cube);
			}
			else {
				CubesPermutationDictionary[seed].Add(key, new List<long> { cube });
			}
		}
	}
}
