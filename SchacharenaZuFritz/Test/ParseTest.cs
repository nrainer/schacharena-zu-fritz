using System;
using System.IO;
using System.Reflection;

using NUnit.Framework;
using SchacharenaZuFritz.Logic.Converter;

namespace SchacharenaZuFritz.Test
{
	[TestFixture]
	public class ParseTest
	{
		[Test]
		public void Test1()
		{
			TestInternal(1);
		}
		
		[Test]
		public void Test2()
		{
			TestInternal(2);
		}
		
		[Test]
		public void Test3()
		{
			TestInternal(3);
		}
		
		[Test]
		public void Test4()
		{
			TestInternal(4);
		}
		
		private void TestInternal(int fileIndex)
		{
			string folder = "Test/";
			
			string inputPath = folder + "input" + fileIndex + ".txt";
			string input = File.ReadAllText(inputPath);
			
			string expectedPath = folder + "expected" + fileIndex + ".txt";
			string expected = File.ReadAllText(expectedPath);
			
			string actual = ConverterUtility.ConvertFromSchacharenaToFritz(input);
			Console.WriteLine(actual);
			Assert.AreEqual(expected.Trim(), actual.Trim());
		}
	}
}
