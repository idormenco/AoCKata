using System;
using System.Buffers;

namespace Kata
{
	public static class IntComputer
	{
		public static int[] IntCodeOld(int[] memmory)
		{
			var shouldStop = false;
			var cursor = 0;
			do
			{
				if (memmory[cursor] == 99)
				{
					shouldStop = true;
					return memmory;
				}

				var instruction = memmory[cursor];
				var a = memmory[memmory[cursor + 1]];
				var b = memmory[memmory[cursor + 2]];

				if (instruction == 1)
				{
					memmory[memmory[cursor + 3]] = a + b;
				}
				if (instruction == 2)
				{
					memmory[memmory[cursor + 3]] = a * b;
				}

				cursor += 4;

			} while (shouldStop == false);


			return memmory;
		}

		public static int[] IntCodeNew(int[] memory, int input, int output)
		{
			var shouldStop = false;
			var cursor = 0;
			do
			{
				if (memory[cursor] == 99)
				{
					shouldStop = true;
					return memory;
				}
				var a = memory[cursor + 1];
				var b = memory[cursor + 2];


				var instruction = DecomposeInstruction(memory, memory[cursor], a, b);

				if (instruction.op == Operations.Sum)
				{
					memory[memory[cursor + 3]] = instruction.param1.Value + instruction.param2.Value;
					cursor += 4;
				}
				if (instruction.op == Operations.Multiply)
				{
					memory[memory[cursor + 3]] = instruction.param1.Value * instruction.param2.Value;
					cursor += 4;
				}

				if (instruction.op == Operations.WriteToOutput)
				{
					output = memory[memory[cursor + 1]];
					cursor += 2;
				}
				if (instruction.op == Operations.ReadFromOutput)
				{
					memory[memory[cursor + 1]] = input;
					cursor += 2;
				}

				if (instruction.op == Operations.JumpIfTrue)
				{
					if (instruction.param1.Value != 0)
					{
						cursor = instruction.param2.Value;
					}
					else
					{
						cursor += 3;
					}
				}


				if (instruction.op == Operations.JumpIfFalse)
				{
					if (instruction.param1.Value == 0)
					{
						cursor = instruction.param2.Value;
					}
					else
					{
						cursor += 3;
					}
				}

				if (instruction.op == Operations.LessThan)
				{
					memory[memory[cursor + 3]] = instruction.param1.Value < instruction.param2.Value ? 1 : 0;
					cursor += 4;
				}
				if (instruction.op == Operations.Equals)
				{
					memory[memory[cursor + 3]] = instruction.param1.Value == instruction.param2.Value ? 1 : 0;
					cursor += 4;
				}
			} while (shouldStop == false);


			return memory;
		}

		private static (Operations op, int? param1, int? param2) DecomposeInstruction(int[] memory, int instruction, int param1Pointer, int param2Pointer)
		{
			var op = (Operations)(instruction % 10);
			var i = (instruction - (int)op) / 100;
			var param1ReadMode = i % 10;
			var param2ReadMode = i / 10;
			if (op == Operations.ReadFromOutput || op == Operations.WriteToOutput)
			{
				return (op, null, null);
			}

			int? param1 = null;
			if (param1ReadMode == 0)
			{
				param1 = memory[param1Pointer];
			}
			else if (param1ReadMode == 1)
			{
				param1 = param1Pointer;
			}
			else
			{
				throw new Exception("param1 read mode ");
			}

			int? param2;
			if (param2ReadMode == 0)
			{
				param2 = memory[param2Pointer];

			}
			else if (param2ReadMode == 1)
			{
				param2 = param2Pointer;
			}
			else
			{
				throw new Exception("param2 read mode ");
			}

			return (op, param1, param2);
		}

		private enum Operations
		{
			None = 0,
			Sum = 1,
			Multiply = 2,
			ReadFromOutput = 3,
			WriteToOutput = 4,
			JumpIfTrue = 5,
			JumpIfFalse = 6,
			LessThan = 7,
			Equals = 8
		}
	}


}