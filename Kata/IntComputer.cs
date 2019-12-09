using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
	public static class IntComputer
	{
		public static long[] IntCodeOld(long[] memmory)
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

		private static void WriteToMemory(Dictionary<long, long> dictionary, long index, long value)
		{
			if (dictionary.ContainsKey(index))
			{
				dictionary[index] = value;
			}
			else
			{
				dictionary.Add(index, value);
			}
		}

		private static long ReadFromMemory(Dictionary<long, long> dictionary, long idx)
		{
			if (dictionary.ContainsKey(idx))
				return dictionary[idx];

			dictionary.Add(idx, 0);
			return dictionary[idx];
		}


		public static (State state, Dictionary<long, long> memory, long cursor, Queue<long> inputMemory, Queue<long> output) IntCodeNew(long[] baseMemory, Queue<long> inputMemory, long cursor)
		{


			var shouldStop = false;
			long relativeBase = 0;
			var memory = baseMemory.Select((l, i) => new { idx = (long)i, val = l }).ToDictionary(x => x.idx, y => y.val);

			Queue<long> output = new Queue<long>();

			do
			{
				var operation = ReadFromMemory(memory, cursor);
				if (operation == 99)
				{
					return (State.Stop, memory, cursor, inputMemory, output);
				}

				var param1 = ReadFromMemory(memory, cursor + 1);
				var param2 = ReadFromMemory(memory, cursor + 2);
				var outputIdx = ReadFromMemory(memory, cursor + 3);

				var instruction = DecomposeInstruction(memory, operation, relativeBase, param1, param2, outputIdx);

				if (instruction.op == Operations.Sum)
				{
					DecomposeInstruction3Params(memory, relativeBase, operation, param1, param2, outputIdx, (a, b) => a + b);

					cursor += 4;
				}
				if (instruction.op == Operations.Multiply)
				{
					DecomposeInstruction3Params(memory, relativeBase, operation, param1, param2, outputIdx, (a, b) => a * b);
					cursor += 4;
				}

				if (instruction.op == Operations.WriteToOutput)
				{
					output.Enqueue(instruction.param1.Value);
					cursor += 2;
				}

				if (instruction.op == Operations.ReadFromInput)
				{
					if (inputMemory.Count == 0)
					{
						return (State.Pause, memory, cursor, inputMemory, output);
					}

					WriteToMemory(memory, instruction.param2.Value, inputMemory.Dequeue());
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
					DecomposeInstruction3Params(memory, relativeBase, operation, param1, param2, outputIdx, (a, b) => a < b ? 1 : 0);
					cursor += 4;
				}

				if (instruction.op == Operations.Equals)
				{
					DecomposeInstruction3Params(memory, relativeBase, operation, param1, param2, outputIdx, (a, b) => a == b ? 1 : 0);
					cursor += 4;
				}

				if (instruction.op == Operations.AdjustRelativeBase)
				{
					relativeBase += instruction.param1.Value;
					cursor += 2;
				}
			} while (shouldStop == false);


			return (State.Stop, memory, cursor, inputMemory, output);
		}

		private static (Operations op, long? param1, long? param2, ReadWriteMode writeMode) DecomposeInstruction(Dictionary<long, long> memory, long instruction, long baseIndex, long param1Pointer, long param2Pointer, long outputIndex)
		{
			long ReadFromMemory(Dictionary<long, long> dictionary, long l)
			{
				if (dictionary.ContainsKey(l))
					return dictionary[l];

				dictionary.Add(l, 0);
				return dictionary[l];
			}

			var op = (Operations)GetNthDigit(instruction, 0);
			var i = (instruction - (long)op) / 100;
			var param1ReadMode = GetNthDigit(instruction, 2);
			var param2ReadMode = GetNthDigit(instruction, 3);
			var outputReadMode = (ReadWriteMode)GetNthDigit(instruction, 4);

			long? param1 = null;
			if (param1ReadMode == 0)
			{
				param1 = ReadFromMemory(memory, param1Pointer);
			}
			else if (param1ReadMode == 1)
			{
				param1 = param1Pointer;
			}
			else if (param1ReadMode == 2)
			{
				param1 = ReadFromMemory(memory, baseIndex + param1Pointer);
			}
			else
			{
				throw new Exception("param1 read mode ");
			}

			if (op == Operations.AdjustRelativeBase || op == Operations.WriteToOutput || op == Operations.ReadFromInput)
			{
				return (op, param1, baseIndex + param1Pointer,ReadWriteMode.Direct);
			}

			long? param2;
			if (param2ReadMode == 0)
			{
				param2 = memory[param2Pointer];
			}
			else if (param2ReadMode == 1)
			{
				param2 = param2Pointer;
			}
			else if (param2ReadMode == 2)
			{
				param2 = ReadFromMemory(memory, baseIndex + param2Pointer);
			}
			else
			{
				throw new Exception("param2 read mode ");
			}


			return (op, param1, param2, ReadWriteMode.Direct);
		}

		private static int DecomposeInstruction3Params(Dictionary<long, long> memory, long baseIndex, long instruction, long param1, long param2, long output, Func<long, long, long> func)
		{
			var op = (Operations)GetNthDigit(instruction, 0);

			var param1ReadMode = (ReadWriteMode)GetNthDigit(instruction, 2);
			var param2ReadMode = (ReadWriteMode)GetNthDigit(instruction, 3);
			var outputWriteMode = (ReadWriteMode)GetNthDigit(instruction, 4);

			if (param1ReadMode == ReadWriteMode.Pointer)
			{
				param1 = ReadFromMemory(memory, param1);
			}

			if (param1ReadMode == ReadWriteMode.Relative)
			{
				param1 = ReadFromMemory(memory, param1 + baseIndex);
			}

			if (param2ReadMode == ReadWriteMode.Pointer)
			{
				param2 = ReadFromMemory(memory, param2);
			}

			if (param2ReadMode == ReadWriteMode.Relative)
			{
				param2 = ReadFromMemory(memory, param2 + baseIndex);
			}


			var result = func(param1, param2);

			if (outputWriteMode == ReadWriteMode.Pointer)
			{
				WriteToMemory(memory, output, result);
			}

			if (outputWriteMode == ReadWriteMode.Relative)
			{
				WriteToMemory(memory, baseIndex + output, result);
			}


			return 4;
		}

		private enum Operations
		{
			None = 0,
			Sum = 1,
			Multiply = 2,
			ReadFromInput = 3,
			WriteToOutput = 4,
			JumpIfTrue = 5,
			JumpIfFalse = 6,
			LessThan = 7,
			Equals = 8,
			AdjustRelativeBase = 9
		}

		public enum State
		{
			Pause = 1,
			Stop = 0,
			Ready = 2
		}

		public enum ReadWriteMode
		{
			None = -1,
			Pointer = 0,
			Direct = 1,
			Relative = 2,
		}

		public static long GetNthDigit(long value, int n)
		{
			if (n < 0) throw new ArgumentException();
			if (value < 0) throw new ArgumentException();

			while (n-- > 0)
			{
				value /= 10;
			}

			long digit = value % 10;
			return digit;
		}
	}


}